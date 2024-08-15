using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Web.Views.Shared.Components.LinkFeasts;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class LinkFeastsViewComponent : ViewComponent
{
    /// <summary>
    /// For routing
    /// </summary>
    public const string Name = "LinkFeasts";

    private static readonly Uri FeastUri = new("https://afeastaday.com/api");

    private readonly UserRepo _userRepo;
    private readonly HttpClient _httpClient;

    public LinkFeastsViewComponent(UserRepo userRepo, IHttpClientFactory httpClientFactory)
    {
        _userRepo = userRepo;
        _httpClient = httpClientFactory.CreateClient();
        if (_httpClient.BaseAddress != FeastUri)
        {
            _httpClient.BaseAddress = FeastUri;
        }
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        if (user.FeastEmail != null && user.FeastToken != null)
        {
            var weeklyFeast = await _httpClient.GetFromJsonAsync<IDictionary<string, double?>?>($"{FeastUri}/User/Nutrients?email={Uri.EscapeDataString(user.FeastEmail)}&token={Uri.EscapeDataString(user.FeastToken)}");
            var one = 1;
        }

        return View("LinkFeasts", new LinkFeastsViewModel()
        {
            Email = user.Email,
            FeastEmail = user.FeastEmail,
            FeastToken = user.FeastToken,
            Token = await _userRepo.AddUserToken(user, durationDays: 1),
        });
    }
}
