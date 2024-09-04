
namespace Web.Code.RouteConstraints;

public class ComponentsRouteConstraint : IRouteConstraint
{
    /// <summary>
    /// The constraint name for use in routes like /{comp:components}/.
    /// </summary>
    public const string Name = "components";

    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        // Retrieve the candidate value.
        var candidate = values[routeKey]?.ToString();
        // Attempt to parse the candidate to the required Enum type, and return the result.
        return Enum.TryParse(candidate, out Core.Models.User.Components _);
    }
}
