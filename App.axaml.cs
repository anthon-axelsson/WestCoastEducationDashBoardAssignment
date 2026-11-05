using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using System;
using WestCoastEducation.Interfaces;
using WestCoastEducation.Services;
using WestCoastEducation.ViewModels;
using WestCoastEducation.Views;

namespace WestCoastEducation;

public partial class App : Application
{
    public static IServiceProvider? Services { get; private set; }

    public override void Initialize()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IRestDbService, RestDbService>();
        services.AddTransient<MainViewModel>();

        Services = services.BuildServiceProvider();

        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(new RestDbService())
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}