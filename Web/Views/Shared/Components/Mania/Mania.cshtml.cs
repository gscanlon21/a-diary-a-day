using Data.Entities.User;
using Web.ViewModels;

namespace Web.Views.Shared.Components.Mania;


public class ManiaViewModel
{
    public ManiaViewModel(IList<UserMania>? userMoods)
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

    public UserMania UserMood { get; init; } = null!;
    public UserMania? PreviousMood { get; init; }

    internal IList<Xy> Xys { get; init; } = [];
}
