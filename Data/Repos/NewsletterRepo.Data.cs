using Core.Code.Extensions;
using Core.Consts;
using Core.Models.Exercise;
using Core.Models.Newsletter;
using Core.Models.User;
using Data.Dtos.Newsletter;
using Data.Entities.User;
using Data.Models.Newsletter;
using Microsoft.EntityFrameworkCore;

namespace Data.Repos;

public partial class NewsletterRepo
{
    #region Warmup Exercises

    /// <summary>
    /// Returns a list of warmup exercises.
    /// </summary>
    internal async Task<List<ExerciseVariationDto>> GetWarmupExercises(WorkoutContext context,
        IEnumerable<ExerciseVariationDto>? excludeGroups = null, IEnumerable<ExerciseVariationDto>? excludeExercises = null, IEnumerable<ExerciseVariationDto>? excludeVariations = null)
    {
        return new List<ExerciseVariationDto>();
    }

    #endregion
    #region Cooldown Exercises

    /// <summary>
    /// Returns a list of cooldown exercises.
    /// </summary>
    internal async Task<List<ExerciseVariationDto>> GetCooldownExercises(WorkoutContext context,
        IEnumerable<ExerciseVariationDto>? excludeGroups = null, IEnumerable<ExerciseVariationDto>? excludeExercises = null, IEnumerable<ExerciseVariationDto>? excludeVariations = null)
    {
        return new List<ExerciseVariationDto>();
    }

    #endregion
    #region Rehab Exercises

    /// <summary>
    /// Returns a list of rehabilitation exercises.
    /// </summary>
    internal async Task<IList<ExerciseVariationDto>> GetRehabExercises(WorkoutContext context,
        IEnumerable<ExerciseVariationDto>? excludeGroups = null, IEnumerable<ExerciseVariationDto>? excludeExercises = null, IEnumerable<ExerciseVariationDto>? excludeVariations = null)
    {
        return new List<ExerciseVariationDto>();
    }

    #endregion
    #region Sports Exercises

    /// <summary>
    /// Returns a list of sports exercises.
    /// </summary>
    internal async Task<IList<ExerciseVariationDto>> GetSportsExercises(WorkoutContext context,
         IEnumerable<ExerciseVariationDto>? excludeGroups = null, IEnumerable<ExerciseVariationDto>? excludeExercises = null, IEnumerable<ExerciseVariationDto>? excludeVariations = null, IDictionary<MuscleGroups, int>? _ = null)
    {
        return new List<ExerciseVariationDto>();
    }

    #endregion
    #region Core Exercises

    /// <summary>
    /// Returns a list of core exercises.
    /// </summary>
    internal async Task<IList<ExerciseVariationDto>> GetCoreExercises(WorkoutContext context,
        IEnumerable<ExerciseVariationDto>? excludeGroups = null, IEnumerable<ExerciseVariationDto>? excludeExercises = null, IEnumerable<ExerciseVariationDto>? excludeVariations = null, IDictionary<MuscleGroups, int>? workedMusclesDict = null)
    {
        return new List<ExerciseVariationDto>();
    }

    #endregion
    #region Prehab Exercises

    /// <summary>
    /// Returns a list of core exercises.
    /// </summary>
    internal async Task<IList<ExerciseVariationDto>> GetPrehabExercises(WorkoutContext context,
        IEnumerable<ExerciseVariationDto>? excludeGroups = null, IEnumerable<ExerciseVariationDto>? excludeExercises = null, IEnumerable<ExerciseVariationDto>? excludeVariations = null)
    {
        return new List<ExerciseVariationDto>();
    }

    #endregion
    #region Functional Exercises

    /// <summary>
    /// Grabs a core set of compound exercises that work the functional movement patterns for the day.
    /// </summary>
    internal async Task<IList<ExerciseVariationDto>> GetFunctionalExercises(WorkoutContext context,
        IEnumerable<ExerciseVariationDto>? excludeGroups = null, IEnumerable<ExerciseVariationDto>? excludeExercises = null, IEnumerable<ExerciseVariationDto>? excludeVariations = null)
    {
        return new List<ExerciseVariationDto>();
    }

    #endregion
    #region Accessory Exercises

    /// <summary>
    /// Returns a list of accessory exercises.
    /// </summary>
    internal async Task<IList<ExerciseVariationDto>> GetAccessoryExercises(WorkoutContext context,
        IEnumerable<ExerciseVariationDto>? excludeGroups = null, IEnumerable<ExerciseVariationDto>? excludeExercises = null, IEnumerable<ExerciseVariationDto>? excludeVariations = null, IDictionary<MuscleGroups, int>? workedMusclesDict = null)
    {
        return new List<ExerciseVariationDto>();
    }

    #endregion
    #region Debug Exercises

    /// <summary>
    /// Grab x-many exercises that the user hasn't seen in a long time.
    /// </summary>
    private async Task<List<ExerciseVariationDto>> GetDebugExercises(User user)
    {
        return new List<ExerciseVariationDto>();
    }

    #endregion
}
