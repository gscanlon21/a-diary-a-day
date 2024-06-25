using Amazon.S3;
using Amazon.S3.Model;
using Core.Code.Helpers;
using Core.Consts;
using Core.Models.Options;
using Core.Models.User;
using Data;
using Data.Entities.Newsletter;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Api.Controllers;

/// <summary>
/// User helpers.
/// </summary>
[ApiController]
[Route("[controller]")]
public class UserController(UserRepo userRepo, CoreContext context, IOptions<DigitalOceanSettings> digitalOceanOptions) : ControllerBase
{
    /// <summary>
    /// Get the user.
    /// </summary>
    [HttpGet("User")]
    public async Task<User?> GetUser(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        return await userRepo.GetUser(email, token);
    }

    /// <summary>
    /// Get the user's past workouts.
    /// </summary>
    [HttpPost("UploadImage")]
    public async Task<IActionResult> UploadImage([FromForm] Components type = Components.None, [FromForm] string email = UserConsts.DemoUser, [FromForm] string token = UserConsts.DemoToken, [FromForm] IFormFile? image = null)
    {
        if (type == Components.None)
        {
            return BadRequest("Invalid Type");
        }

        if (image == null || image.Length == 0)
        {
            return BadRequest("Invalid Image");
        }

        var user = await userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return BadRequest("Invalid User");
        }

        var userComponent = await context.UserComponents.FirstOrDefaultAsync(c => c.UserId == user.Id && c.Component == type);
        if (userComponent != null && userComponent.LastUpload < DateHelpers.Today)
        {
            var prefix = $"moods/{user.Uid}";
            var key = $"{prefix}-{type}";
            var client = new AmazonS3Client(digitalOceanOptions.Value.AWSS3AccessKey, digitalOceanOptions.Value.AWSS3SecretKey, new AmazonS3Config()
            {
                ServiceURL = digitalOceanOptions.Value.CDNLink
            });

            var request = new PutObjectRequest()
            {
                BucketName = digitalOceanOptions.Value.CDNBucket,
                Key = key,
                CannedACL = S3CannedACL.PublicRead,
                InputStream = image.OpenReadStream(),
            };
            request.Metadata.Add("Cache-Control", "public, max-age=86400");
            await client.PutObjectAsync(request);

            userComponent.LastUpload = DateHelpers.Today;
        }
        else if (userComponent == null)
        {
            context.Add(new UserComponent(user.Id, type));
        }

        await context.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Get the user's past workouts.
    /// </summary>
    [HttpGet("Workouts")]
    public async Task<IList<UserEmail>?> GetWorkouts(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        var user = await userRepo.GetUser(email, token);
        if (user == null)
        {
            return null;
        }

        return await userRepo.GetPastWorkouts(user);
    }
}
