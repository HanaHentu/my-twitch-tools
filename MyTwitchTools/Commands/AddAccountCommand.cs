using MyTwitchTools.Models;
using MyTwitchTools.Services;
using MyTwitchTools.Stores;
using MyTwitchTools.ViewModels;

namespace MyTwitchTools.Commands
{
    public class AddAccountCommand : CommandBase
    {
        private readonly AddAccountViewModel _addAccountViewModel;
        private readonly AccountsStore _accountsStore;
        private readonly INavigationService _navigationService;

        public AddAccountCommand(AddAccountViewModel addAccountViewModel, AccountsStore accountsStore, INavigationService navigationService)
        {
            _addAccountViewModel = addAccountViewModel;
            _accountsStore = accountsStore;
            _navigationService = navigationService;

            _addAccountViewModel.PropertyChanged += (sender, args) => OnCanExecuteChanged();
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(_addAccountViewModel.Login) &&
                   !string.IsNullOrWhiteSpace(_addAccountViewModel.Password);
        }

        public override void Execute(object parameter)
        {
            Account account = new Account()
            {
                Login = _addAccountViewModel.Login,
                Password = _addAccountViewModel.Password
            };

            _accountsStore.AddAccount(account);

            _navigationService.Navigate();
        }
    }
}
