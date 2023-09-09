using MyTwitchTools.Commands;
using MyTwitchTools.Models;
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
    public class HomeViewModel : ViewModelBase
    {
        private readonly AccountStore _accountStore;

        public string Login => _accountStore.CurrentAccount?.Login;
        public string Password => _accountStore.CurrentAccount?.Password;
        public string WelcomeMessage => $"Welcome {Login} to my application.";

        public ICommand NavigateChatCommand { get; }


        public HomeViewModel(AccountStore accountStore, INavigationService<ChatViewModel> chatNavigationService)
        {
            _accountStore = accountStore;

            NavigateChatCommand = new NavigateCommand<ChatViewModel>(chatNavigationService);

            _accountStore.CurrentAccountChanged += OnCurrentAccountChanged;
        }

        private void OnCurrentAccountChanged()
        {
            OnPropertyChanged(nameof(Login));
            OnPropertyChanged(nameof(Password));
            OnPropertyChanged(nameof(WelcomeMessage));
        }

        public override void Dispose()
        {
            _accountStore.CurrentAccountChanged -= OnCurrentAccountChanged;

            base.Dispose();
        }
    }
}
