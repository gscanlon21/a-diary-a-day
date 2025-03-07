﻿using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared.Components.Depression;

public class DepressionViewModel
{
    public DepressionViewModel(IList<UserDepression>? userMoods)
    {

        if (userMoods != null)
        {
            Xys = Enumerable.Range(0, UserConsts.ChartDaysDefault).Select(i =>
            {
                var date = DateHelpers.Today.AddDays(-i);
                return new Xy(date, null);
            }).Where(xy => xy.Y.HasValue).Reverse().ToList();
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserDepression UserDepression { get; init; } = null!;

    internal IList<Xy> Xys { get; init; } = [];
}
