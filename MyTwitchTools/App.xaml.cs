using MyTwitchTools.Services;
using MyTwitchTools.Stores;
using MyTwitchTools.ViewModels;
using System;
using System.Windows;

namespace MyTwitchTools
{
    public partial class App : Application
    {
        private readonly AccountStore _accountStore;
        private readonly NavigationStore _navigationStore;
        private readonly UserThemeStore _userThemeStore;

        public App()
        {
            _accountStore = new AccountStore();
            _navigationStore = new NavigationStore();
            _userThemeStore = new UserThemeStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService loginNavigationService = CreateLoginNavigationService();
            loginNavigationService.Navigate();
            _userThemeStore.Load();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService CreateHomeNavigationService()
        {
            return new LayoutNavigationService<HomeViewModel>(
                _navigationStore,
                () => new HomeViewModel(_accountStore, CreateChatNavigationService()),
                CreateNavigationBarViewModel);
        }

        private INavigationService CreateLoginNavigationService()
        {
            return new NavigationService<LoginViewModel>(
                _navigationStore,
                () => new LoginViewModel(_accountStore, CreateHomeNavigationService()));
        }

        private INavigationService CreateChatNavigationService()
        {
            return new LayoutNavigationService<ChatViewModel>(
                _navigationStore,
                () => new ChatViewModel(CreateHomeNavigationService()),
                CreateNavigationBarViewModel);
        }

        private INavigationService CreateSettingsNavigationService()
        {
            return new LayoutNavigationService<SettingsViewModel>(
                _navigationStore,
                () => new SettingsViewModel(_userThemeStore),
                CreateNavigationBarViewModel);
        }

        private NavigationBarViewModel CreateNavigationBarViewModel()
        {
            return new NavigationBarViewModel(
                            _accountStore,
                            _userThemeStore,
                            CreateHomeNavigationService(),
                            CreateChatNavigationService(),
                            CreateLoginNavigationService(),
                            CreateSettingsNavigationService());
        }
    }
}
