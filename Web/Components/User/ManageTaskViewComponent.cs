﻿using Core.Dtos.Newsletter;
using Core.Models.Newsletter;
using Data;
using Data.Query.Builders;
using Data.Repos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Views.Shared.Components.ManageTask;

namespace Web.Components.User;

public class ManageTaskViewComponent : ViewComponent
{
    /// <summary>
    /// For routing.
    /// </summary>
    public const string Name = "ManageTask";

    private readonly UserRepo _userRepo;
    private readonly CoreContext _context;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public ManageTaskViewComponent(CoreContext context, UserRepo userRepo, IServiceScopeFactory serviceScopeFactory)
    {
        _context = context;
        _userRepo = userRepo;
        _serviceScopeFactory = serviceScopeFactory;
    }

    public async Task<IViewComponentResult> InvokeAsync(Data.Entities.User.User user, Data.Entities.Task.UserTask task, Section section = Section.None)
    {
        var token = await _userRepo.AddUserToken(user, durationDays: 1);
        if (task == null)
        {
            // Create a new user task.
            return View("ManageTask", new ManageTaskViewModel(user, new Data.Entities.Task.UserTask()
            {
                UserId = user.Id
            }, token));
        }

        // User must have created the task to be able to edit it.
        var userTask = await _context.UserTasks.AsNoTracking().FirstOrDefaultAsync(r => r.UserId == user.Id && r.Id == task.Id);
        if (userTask == null) { return Content(""); }

        var taskDto = (await new QueryBuilder(Section.None)
            .WithUser(user, ignored: null)
            .WithTasks(x =>
            {
                x.AddTasks([task]);
            })
            .Build()
            .Query(_serviceScopeFactory))
            .FirstOrDefault();

        var completedForSection = await _context.UserTaskLogs.AsNoTracking()
            .Where(ut => ut.UserTaskId == userTask.Id)
            .Where(ut => ut.Date == user.TodayOffset)
            .Where(ut => ut.Section == section)
            .AnyAsync(ut => ut.Complete > 0);

        var lastValue = await _context.UserTaskLogs.AsNoTracking()
            .Where(ut => ut.UserTaskId == userTask.Id)
            .Where(ut => ut.Section == section)
            .OrderByDescending(ut => ut.Date)
            .LastOrDefaultAsync();

        // Edit an existing user task.
        return View("ManageTask", new ManageTaskViewModel(user, userTask, token)
        {
            ManageSection = section,
            Value = lastValue?.Complete ?? default,
            CompletedForSection = completedForSection,
            Task = taskDto?.AsType<NewsletterTaskDto>()!,
        });
    }
}
