using Amazon.S3;
using Amazon.S3.Model;
using Core.Code.Helpers;
using Core.Consts;
using Core.Models.Options;
using Data;
using Data.Entities.User;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace Api.Controllers;

/// <summary>
/// User helpers.
/// </summary>
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;
    private readonly Lazy<AmazonS3Client> _client;
    private readonly IOptions<DigitalOceanSettings> _digitalOceanOptions;

    public UserController(CoreContext context, UserRepo userRepo, IOptions<DigitalOceanSettings> digitalOceanOptions)
    {
        _context = context;
        _userRepo = userRepo;
        _digitalOceanOptions = digitalOceanOptions;
        _client = new Lazy<AmazonS3Client>(() => new AmazonS3Client(digitalOceanOptions.Value.AWSS3AccessKey, digitalOceanOptions.Value.AWSS3SecretKey, new AmazonS3Config()
        {
            ServiceURL = digitalOceanOptions.Value.CDNLink
        }));
    }

    /// <summary>
    /// Get the user.
    /// </summary>
    [HttpGet("User")]
    public async Task<User?> GetUser(string email = UserConsts.DemoUser, string token = UserConsts.DemoToken)
    {
        return await _userRepo.GetUser(email, token);
    }

    /// <summary>
    /// Get the user's past workouts.
    /// </summary>
    [HttpPost("UploadImage")]
    [SuppressMessage("Style", "IDE0075:Simplify conditional expression", Justification = "Easier to read unsimplified.")]
    public async Task<IActionResult> UploadImage([FromForm] Component type = Component.None, [FromForm] string email = UserConsts.DemoUser, [FromForm] string token = UserConsts.DemoToken, [FromForm] IFormFile? image = null, [FromForm] string? name = null)
    {
        if (type == Component.None)
        {
            return BadRequest("Invalid Type");
        }

        if (image == null || image.Length == 0)
        {
            return BadRequest("Invalid Image");
        }

        var user = await _userRepo.GetUser(email, token, allowDemoUser: true);
        if (user == null)
        {
            return BadRequest("Invalid User");
        }

        if (name != null)
        {
            // Named images are only allowed for the tasks component.
            if (type != Component.Tasks)
            {
                return BadRequest("Invalid Name");
            }

            // Make sure that the user isn't uploading too many images.
            if (await _context.UserTasks.CountAsync(ut => ut.UserId == user.Id) > UserConsts.MaxTasks)
            {
                return BadRequest("Invalid Name");
            }

            // Make sure the task exists in our system.
            if (Guid.TryParse(name, out Guid guidName) ? !await _context.UserTasks.AnyAsync(ut => ut.UserId == user.Id && ut.Uid == guidName) : true)
            {
                return BadRequest("Invalid Name");
            }
        }

        var userComponent = await _context.UserComponents
            .Where(uc => uc.UserId == user.Id)
            .Where(uc => uc.Component == type)
            .Where(uc => uc.Name == name)
            .FirstOrDefaultAsync();

        // Image was already uploaded today.
        if (userComponent?.LastUpload >= DateHelpers.Today == true)
        {
            return NoContent();
        }

        // Upload the image.
        var request = new PutObjectRequest()
        {
            Key = $"moods/{user.Uid}/{type}{name?.Insert(0, "-")}",
            BucketName = _digitalOceanOptions.Value.CDNBucket,
            InputStream = image.OpenReadStream(),
            CannedACL = S3CannedACL.PublicRead,
        };

        request.Metadata.Add("Cache-Control", "public, max-age=86400");
        await _client.Value.PutObjectAsync(request);

        // Update the LastUpload date.
        if (userComponent != null)
        {
            userComponent.LastUpload = DateHelpers.Today;
        }
        else
        {
            _context.Add(new UserComponent(user.Id, type)
            {
                Name = name
            });
        }

        await _context.SaveChangesAsync();
        return Ok();
    }

    /// <summary>
    /// Log an exception.
    /// </summary>
    [HttpPost("LogException")]
    public async Task LogException([FromForm] string? email, [FromForm] string token, [FromForm] string? message)
    {
        var user = await _userRepo.GetUser(email, token);
        if (user == null || string.IsNullOrWhiteSpace(message))
        {
            return;
        }

        throw new Exception(message);
    }
}
