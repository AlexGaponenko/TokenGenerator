using System;
using System.Linq;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core;
using Avalonia.Data.Core.Plugins;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using TokenGenerator.Domain.Interfaces;
using TokenGenerator.Services;
using TokenGenerator.ViewModels;
using TokenGenerator.Views;

namespace TokenGenerator
{
    public partial class App : Application
    {

        public static IServiceProvider Services { get; private set; }

        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {

            var services = new ServiceCollection();

            //Domain
            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            //ViewModels
            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<SettingsViewModel>();
            services.AddSingleton<SettingsService>();

            //Views
            services.AddTransient<MainWindow>();
            services.AddTransient<SettingsWindow>();
            services.AddSingleton<SettingsViewModel>();

            Services = services.BuildServiceProvider();

            //UI
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = Services.GetRequiredService<MainWindow>();
            }

            base.OnFrameworkInitializationCompleted();

        }

        private void DisableAvaloniaDataAnnotationValidation()
        {
            // Get an array of plugins to remove
            var dataValidationPluginsToRemove =
                BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

            // remove each entry found
            foreach (var plugin in dataValidationPluginsToRemove)
            {
                BindingPlugins.DataValidators.Remove(plugin);
            }
        }
    }
}