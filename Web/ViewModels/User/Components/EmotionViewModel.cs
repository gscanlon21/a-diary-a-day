﻿using Data.Entities.Footnote;
using Data.Entities.User;
using static Web.ViewModels.User.Components.ActivityViewModel;
using System.Linq;

namespace Web.ViewModels.User.Components;

public class EmotionViewModel
{
    /// <summary>
    /// Today's date in UTC.
    /// </summary>
    private static DateOnly Today => DateOnly.FromDateTime(DateTime.UtcNow);

    public EmotionViewModel(IList<UserEmotion>? userMoods, List<UserCustom> customs)
    {
        Customs = customs;
        //Mood = currentWeight.GetValueOrDefault();
        if (userMoods != null)
        {
            var flatMap = userMoods.SelectMany(m =>
            {
                return m.UserCustoms.Select(c => new UserCustomGroup(m.Date, c.Type, c.Id, c.Name));
            });

            foreach (var custom in Customs)
            {
                // Skip today, start at 1, because we append the current weight onto the end regardless.
                Xys.AddRange(Enumerable.Range(1, 365).Select(i =>
                {
                    var date = Today.AddDays(-i);
                    return new XCustom(date, flatMap.FirstOrDefault(uw => uw.Date == date && uw.Id == custom.Id), custom.Id);
                }).Where(xy => xy.Y != null).Reverse().Append(new XCustom(Today, flatMap.FirstOrDefault(um => um.Date == Today && um.Id == custom.Id), custom.Id)).ToList());
            }
        }
    }

    public string Token { get; init; } = null!;
    public Data.Entities.User.User User { get; init; } = null!;

    public UserEmotion UserMood { get; init; } = null!;
    public UserEmotion? PreviousMood { get; init; }

    internal List<XCustom> Xys { get; init; } = [];
    internal List<IGrouping<int, XCustom>> XysGrouped => Xys.GroupBy(xy => xy.Id).ToList();

    public List<UserCustom> Customs { get; set; } = [];
}
