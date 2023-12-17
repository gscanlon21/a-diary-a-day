﻿using Core.Models.User;
using Data.Entities.Newsletter;

namespace Web.ViewModels.User.Components;

public class WorkoutViewModel
{
    public required Data.Entities.User.User User { get; init; } = null!;

    public required string Token { get; init; } = null!;

    public WorkoutRotation? Rotation { get; init; }

    public Frequency Frequency { get; init; }
}
