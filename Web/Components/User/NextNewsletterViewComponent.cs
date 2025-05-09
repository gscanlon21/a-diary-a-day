﻿using Core.Models.User;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.NextNewsletter;

namespace Web.Components.User;

/// <summary>
/// Renders an alert box summary of when the user's next deload week will occur.
/// </summary>
public class NextNewsletterViewComponent(CoreContext context) : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "NextNewsletter";

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, string token)
    {
        DateOnly? nextSendDate = null;
        if (user.RestDays < Days.All)
        {
            nextSendDate = DateTime.UtcNow.Hour <= user.SendHour ? DateHelpers.Today : DateHelpers.Today.AddDays(1);
            // Next send date is a rest day and user does not want off day workouts, next send date is the day after.
            while ((user.RestDays.HasFlag(DaysExtensions.FromDate(nextSendDate.Value)))
                // User was sent a newsletter for the next send date, next send date is the day after.
                // Checking for variations because we create a dummy newsletter record to advance the workout split.
                || await context.UserEmails
                    .Where(n => n.UserId == user.Id)
                    .Where(n => n.Subject == EmailConsts.SubjectDiary)
                    .AnyAsync(n => n.Date == nextSendDate.Value)
                )
            {
                nextSendDate = nextSendDate.Value.AddDays(1);
            }
        }

        var nextSendDateTime = nextSendDate?.ToDateTime(TimeOnly.FromTimeSpan(TimeSpan.FromHours(user.SendHour)));
        var timeUntilNextSend = !nextSendDateTime.HasValue ? null : nextSendDateTime - DateTime.UtcNow;
        if (!timeUntilNextSend.HasValue)
        {
            return Content("");
        }

        return View("NextNewsletter", new NextNewsletterViewModel()
        {
            User = user,
            Token = token,
            TimeUntilNextSend = timeUntilNextSend,
            Today = DaysExtensions.FromDate(user.TodayOffset),
            NextWorkoutSendsToday = timeUntilNextSend.HasValue && DateOnly.FromDateTime(DateTime.UtcNow.Add(timeUntilNextSend.Value)) == user.TodayOffset
        });
    }
}
