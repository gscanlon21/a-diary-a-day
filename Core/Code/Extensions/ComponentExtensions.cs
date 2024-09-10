using Core.Attributes;
using System.Reflection;

namespace Core.Code.Extensions;

public static class ComponentExtensions
{
    public static SubComponentAttributeInternal? GetSubComponent(this Component component)
    {
        var memberInfo = component.GetType().GetMember(component.ToString());
        if (memberInfo != null && memberInfo.Length > 0)
        {
            return memberInfo[0].GetCustomAttribute(typeof(SubComponentAttribute<>), true) as SubComponentAttributeInternal;
        }

        return null;
    }
}
