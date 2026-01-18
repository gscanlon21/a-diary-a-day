
namespace Core.Models.Options;

/// <summary>
/// App settings for the domain name.
/// </summary>
public class SiteSettings
{
    /// <summary>
    /// The user-friendly name of the website.
    /// 
    /// sa. A Diary a Day
    /// </summary>
    public string Name { get; set; } = "A Diary a Day";

    /// <summary>
    /// Link to the site's source code.
    /// 
    /// sa. https://github.com/gscanlon21/a-diary-a-day
    /// </summary>
    public string? Source { get; set; } = "https://github.com/gscanlon21/a-diary-a-day";

    /// <summary>
    /// The link to the main website.
    /// 
    /// sa. https://adiaryaday.com
    /// </summary>
    public string WebLink { get; set; } = "https://adiaryaday.com";
    public Uri WebUri => new(WebLink);

    /// <summary>
    /// The domain name of the site.
    /// 
    /// sa. adiaryaday.com
    /// </summary>
    public string Domain => WebUri.Host;

    /// <summary>
    /// Get the root domain sans TLD and sans subdomains.
    /// 
    /// sa. adiaryaday
    /// </summary>
    public string ApexDomainSansTLD => Domain.Split('.')[^2];

    /// <summary>
    /// The link to the cdn.
    /// 
    /// sa. https://cdn.adiaryaday.com
    /// </summary>
    public string CdnLink { get; set; } = "https://cdn.adiaryaday.com";
    public Uri CdnUri => new(CdnLink);

    /// <summary>
    /// The path to the api.
    /// 
    /// sa. https://adiaryaday.com/api
    /// </summary>
    public string ApiLink { get; set; } = "https://adiaryaday.com/api";
    public Uri ApiUri => new(ApiLink);

    /// <summary>
    /// The path to the feast api.
    /// 
    /// sa. https://afeastaday.com/api
    /// </summary>
    public string FeastLink { get; set; } = "https://afeastaday.com/api";
    public Uri FeastUri => new(FeastLink);

    /// <summary>
    /// The link where the user can download the app.
    /// </summary>
    public string AppLink { get; set; } = null!;
    public Uri AppUri => new(AppLink);
}
