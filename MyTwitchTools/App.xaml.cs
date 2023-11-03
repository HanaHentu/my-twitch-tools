using Microsoft.Extensions.DependencyInjection;
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

            services.AddSingleton<AccountsStore>();
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<DialogNavigationStore>();
            services.AddSingleton<UserThemeStore>();
            services.AddSingleton<ChatMessagesStore>();

            services.AddSingleton<INavigationService>(s => CreateHomeNavigationService(s));
            services.AddSingleton<CloseDialogNavigationService>();

            services.AddTransient<HomeViewModel>(s => new HomeViewModel(
                CreateChatNavigationService(s)));
            services.AddTransient<AccountsListingViewModel>(s => new AccountsListingViewModel(
                s.GetRequiredService<AccountsStore>(),
                CreateAddAccountNavigationService(s)));
            services.AddTransient<AddAccountViewModel>(s => new AddAccountViewModel(
                s.GetRequiredService<AccountsStore>(),
                s.GetRequiredService<CloseDialogNavigationService>()
                ));
            services.AddTransient<ChatViewModel>(s => new ChatViewModel(
                s.GetRequiredService<ChatMessagesStore>(),
                s.GetRequiredService<AccountsStore>(),
                CreateHomeNavigationService(s)
                ));
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

        private INavigationService CreateAccountsListingNavigationService(IServiceProvider serviceProvider)
        {
            return new LayoutNavigationService<AccountsListingViewModel>(
                serviceProvider.GetRequiredService<NavigationStore>(),
                () => serviceProvider.GetRequiredService<AccountsListingViewModel>(),
                () => serviceProvider.GetRequiredService<NavigationBarViewModel>());
        }

        private INavigationService CreateAddAccountNavigationService(IServiceProvider serviceProvider)
        {
            return new DialogNavigationService<AddAccountViewModel>(
                serviceProvider.GetRequiredService<DialogNavigationStore>(),
                () => serviceProvider.GetRequiredService<AddAccountViewModel>());
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
                            serviceProvider.GetRequiredService<UserThemeStore>(),
                            CreateHomeNavigationService(serviceProvider),
                            CreateAccountsListingNavigationService(serviceProvider),
                            CreateChatNavigationService(serviceProvider),
                            CreateSettingsNavigationService(serviceProvider));
        }
    }
}
