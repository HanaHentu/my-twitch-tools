﻿using Microsoft.Extensions.DependencyInjection;
using MyTwitchTools.Services;
using MyTwitchTools.Stores;
using MyTwitchTools.ViewModels;
using System;
using System.Windows;

namespace MyTwitchTools
{
    public partial class App : Application
    {
        private readonly IServiceProvider _serviceProvider;

        public App()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<AccountStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<UserThemeStore>();

            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));

            services.AddTransient<HomeViewModel>(s => new HomeViewModel(
                s.GetRequiredService<AccountStore>(),
                CreateChatNavigationService(s)));
            services.AddTransient<LoginViewModel>(s => new LoginViewModel(
                s.GetRequiredService<AccountStore>(),
                CreateHomeNavigationService(s)));
            services.AddTransient<ChatViewModel>(s => new ChatViewModel(CreateHomeNavigationService(s)));
            services.AddTransient<SettingsViewModel>(s => new SettingsViewModel(s.GetRequiredService<UserThemeStore>()));
            services.AddTransient<NavigationBarViewModel>(CreateNavigationBarViewModel);
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<MainWindow>(s => new MainWindow()
            {
                DataContext = s.GetRequiredService<MainViewModel>()
            });

            _serviceProvider = services.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService initialNavigationService = _serviceProvider.GetRequiredService<INavigationService>();
            initialNavigationService.Navigate();
            _serviceProvider.GetRequiredService<UserThemeStore>().Load();

            MainWindow = _serviceProvider.GetRequiredService<MainWindow>();
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateHomeNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<HomeViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<HomeViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateLoginNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<LoginViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<LoginViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateChatNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<ChatViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<ChatViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateSettingsNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<SettingsViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<SettingsViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private NavigationBarViewModel CreateNavigationBarViewModel(IServiceProvider serviceProvider)
        {
            return new NavigationBarViewModel(
                            serviceProvider.GetRequiredService<AccountStore>(),
                            serviceProvider.GetRequiredService<UserThemeStore>(),
                            CreateHomeNavigationService(serviceProvider),
                            CreateChatNavigationService(serviceProvider),
                            CreateLoginNavigationService(serviceProvider),
                            CreateSettingsNavigationService(serviceProvider));
        }
    }
}
