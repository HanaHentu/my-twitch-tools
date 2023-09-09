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

        public App()
        {
            _accountStore = new AccountStore();
            _navigationStore = new NavigationStore();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            INavigationService<LoginViewModel> loginNavigationService = CreateLoginNavigationService();
            loginNavigationService.Navigate();

            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        private INavigationService<HomeViewModel> CreateHomeNavigationService()
        {
            return new LayoutNavigationService<HomeViewModel>(
                _navigationStore,
                () => new HomeViewModel(_accountStore, CreateChatNavigationService()),
                CreateNavigationBarViewModel);
        }

        private INavigationService<LoginViewModel> CreateLoginNavigationService()
        {
            return new NavigationService<LoginViewModel>(
                _navigationStore,
                () => new LoginViewModel(_accountStore, CreateHomeNavigationService()));
        }

        private INavigationService<ChatViewModel> CreateChatNavigationService()
        {
            return new LayoutNavigationService<ChatViewModel>(
                _navigationStore,
                () => new ChatViewModel(CreateHomeNavigationService()),
                CreateNavigationBarViewModel);
        }

        private INavigationService<SettingsViewModel> CreateSettingsNavigationService()
        {
            return new LayoutNavigationService<SettingsViewModel>(
                _navigationStore,
                () => new SettingsViewModel(),
                CreateNavigationBarViewModel);
        }

        private NavigationBarViewModel CreateNavigationBarViewModel()
        {
            return new NavigationBarViewModel(
                            _accountStore,
                            CreateHomeNavigationService(),
                            CreateChatNavigationService(),
                            CreateLoginNavigationService(),
                            CreateSettingsNavigationService());
        }
    }
}
