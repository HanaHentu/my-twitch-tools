using HandyControl.Controls;
using HandyControl.Tools.Command;
using MyTwitchTools.Commands;
using MyTwitchTools.Services;
using MyTwitchTools.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyTwitchTools.ViewModels
{
    public class NavigationBarViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;
        public ICommand NavigateHomeCommand { get; }
        public ICommand NavigateChatCommand { get; }
        public ICommand NavigateLoginCommand { get; }
        public ICommand NavigateSettingsCommand { get; }
        public ICommand LogoutCommand { get; }

        public bool IsNotLoggedIn => !_accountStore.IsLoggedIn;

        public NavigationBarViewModel(AccountStore accountStore,
            INavigationService<HomeViewModel> homeNavigationService,
            INavigationService<ChatViewModel> chatNavigationService,
            INavigationService<LoginViewModel> loginNavigationService,
            INavigationService<SettingsViewModel> settingsNavigationService)
        {
            _accountStore = accountStore;
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateChatCommand = new NavigateCommand<ChatViewModel>(chatNavigationService);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
            NavigateSettingsCommand = new NavigateCommand<SettingsViewModel>(settingsNavigationService);
            LogoutCommand = new LogoutCommand(_accountStore);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(IsNotLoggedIn));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}