using MyTwitchTools.Commands;
using MyTwitchTools.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyTwitchTools.ViewModels
{
    public class AccountsListingViewModel : ViewModelBase
    {
        private readonly ObservableCollection<AccountViewModel> _accounts;
        public IEnumerable<AccountViewModel> Accounts => _accounts;
        public ICommand AddAccountCommand { get; }

        public AccountsListingViewModel(INavigationService addAccountNavigationService)
        {
            AddAccountCommand = new NavigateCommand(addAccountNavigationService);

            _accounts = new ObservableCollection<AccountViewModel>();

            _accounts.Add(new AccountViewModel("Hentu"));
            _accounts.Add(new AccountViewModel("Lily"));
            _accounts.Add(new AccountViewModel("Xavick"));
        }
    }
}
