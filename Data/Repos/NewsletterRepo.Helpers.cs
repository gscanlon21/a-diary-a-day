using Data.Entities.User;
using Data.Models.Newsletter;

namespace Data.Repos;

public partial class NewsletterRepo
{
    /// <summary>
    /// Common properties surrounding today's workout.
    /// </summary>
    internal async Task<WorkoutContext?> BuildWorkoutContext(User user, string token)
    {
        return new WorkoutContext()
        {
            User = user,
            Token = token,
        };
    }
}
