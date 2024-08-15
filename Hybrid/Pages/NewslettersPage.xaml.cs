﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Core.Dtos.Newsletter;
using Lib.Services;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Hybrid;

public partial class NewslettersPage : ContentPage
{
    /// https://stackoverflow.com/questions/73710578/net-maui-mvvm-navigate-and-pass-object-between-views
    public NewslettersPage(NewslettersPageViewModel viewModel)
    {
        InitializeComponent();
        viewModel.Navigation = Navigation;
        BindingContext = viewModel;
    }
}

public partial class NewslettersPageViewModel : ObservableObject
{
    private readonly UserService _userService;

    public INavigation Navigation { get; set; } = null!;

    public ICommand NewsletterCommand { get; }

    public IAsyncRelayCommand LoadCommand { get; }

    public NewslettersPageViewModel(UserService userService)
    {
        _userService = userService;

        LoadCommand = new AsyncRelayCommand(LoadWorkoutsAsync);
        NewsletterCommand = new Command<UserMoodDto>(async (UserMoodDto arg) =>
        {
            await Navigation.PushAsync(new NewsletterPage(arg.Date));
        });
    }

    [ObservableProperty]
    private bool _loading = true;

    [ObservableProperty]
    public ObservableCollection<UserMoodDto>? _workouts = null;

    private async Task LoadWorkoutsAsync()
    {
        var email = Preferences.Default.Get(nameof(PreferenceKeys.Email), "");
        var token = Preferences.Default.Get(nameof(PreferenceKeys.Token), "");
        Workouts = new ObservableCollection<UserMoodDto>(
            await _userService.GetWorkouts(email, token) ?? Enumerable.Empty<UserMoodDto>()
        );

        Loading = false;
    }
}