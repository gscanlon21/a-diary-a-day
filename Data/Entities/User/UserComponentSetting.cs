﻿using Core.Consts;
using Core.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
using System.Text.Json.Serialization;

namespace Data.Entities.User;

[Table("user_component_setting")]
[DebuggerDisplay("{Component}: {Days}")]
public class UserComponentSetting
{
    public Components Component { get; init; }

    [ForeignKey(nameof(Entities.User.User.Id))]
    public int UserId { get; init; }

    [JsonIgnore, InverseProperty(nameof(Entities.User.User.UserComponentSettings))]
    public virtual User User { get; private init; } = null!;

    [Range(UserConsts.ChartDaysMin, UserConsts.ChartDaysMax)]
    public int Days { get; init; } = UserConsts.ChartDaysDefault;
}