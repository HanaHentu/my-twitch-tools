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
        public ICommand NavigateHomeCommand { get; set; }
        public ICommand NavigateChatCommand { get; set; }
        public ICommand NavigateLoginCommand { get; set; }

        public bool IsNotLoggedIn => !_accountStore.IsLoggedIn;

        public NavigationBarViewModel(AccountStore accountStore,
            INavigationService<HomeViewModel> homeNavigationService,
            INavigationService<ChatViewModel> chatNavigationService,
            INavigationService<LoginViewModel> loginNavigationService)
        {
            _accountStore = accountStore;
            NavigateHomeCommand = new NavigateCommand<HomeViewModel>(homeNavigationService);
            NavigateChatCommand = new NavigateCommand<ChatViewModel>(chatNavigationService);
            NavigateLoginCommand = new NavigateCommand<LoginViewModel>(loginNavigationService);
        }
    }
}