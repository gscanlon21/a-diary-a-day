using Core.Models.Options;
using Core.Models.User;
using Data.Repos;
using Lib.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
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
    private readonly IOptions<SiteSettings> _siteSettings;

    public LinkFeastsViewComponent(UserRepo userRepo, IHttpClientFactory httpClientFactory, IOptions<SiteSettings> siteSettings)
    {
        _userRepo = userRepo;
        _siteSettings = siteSettings;
        _httpClient = httpClientFactory.CreateClient();
        if (_httpClient.BaseAddress != siteSettings.Value.FeastUri)
        {
            _httpClient.BaseAddress = siteSettings.Value.FeastUri;
        }
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user)
    {
        if (user.FeastEmail != null && user.FeastToken != null)
        {
            var response = await _httpClient.GetAsync($"{_siteSettings.Value.FeastUri}/User/Allergens?weeks={1}&email={Uri.EscapeDataString(user.FeastEmail)}&token={Uri.EscapeDataString(user.FeastToken)}");
            var weeklyFeast = await ApiResult<IDictionary<Allergy, double?>>.FromResponse(response);
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
