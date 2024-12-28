using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

public class ViewController : Controller
{
    /// <summary>
    /// Message to show to the user when a link has expired.
    /// </summary>
    public const string LinkExpiredMessage = "This link has expired.";
}
