﻿using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared.Components.PanicSeverity;

public class PanicSeverityViewModel
{
    public PanicSeverityViewModel(Data.Entities.User.User user, IList<UserPanicSeverity>? userMoods)
    {
        User = user;
        if (userMoods != null)
        {
            // Skip today, start at 1, because we append the current weight onto the end regardless.
            Xys = Enumerable.Range(1, user.GetComponentDaysFor(Component.PanicSeverity)).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                return new XScore(date, userMoods.FirstOrDefault(uw => uw.Date == date));
            }).Where(xy => xy.Y != null).Reverse().Append(new XScore(DateHelpers.Today, userMoods.FirstOrDefault(um => um.Date == DateHelpers.Today))).ToList();
        }
    }

    public Data.Entities.User.User User { get; private init; } = null!;
    public required string Token { get; init; } = null!;

    public UserPanicSeverity UserMood { get; init; } = null!;
    public UserPanicSeverity? PreviousMood { get; init; }

    internal IList<XScore> Xys { get; init; } = [];
}