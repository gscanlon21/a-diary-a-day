using Core.Models.User;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities.User;

[Table("user_component_setting")]
public class UserComponentSetting
{
    public Components Component { get; init; }

    [ForeignKey(nameof(Entities.User.User.Id))]
    public int UserId { get; init; }

    //[JsonIgnore, InverseProperty(nameof(Entities.User.User.UserComponentSettings))]
    public virtual User User { get; private init; } = null!;
}
