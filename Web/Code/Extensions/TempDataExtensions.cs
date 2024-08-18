using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Web.Code.Extensions;

public static class TempDataExtensions
{
    public static bool IsSuccess(this ITempDataDictionary tempData)
    {
        return tempData.ContainsKey(TempData_User.SuccessMessage) || tempData.ContainsKey(TempData_User.SuccessMessage2);
    }
}
