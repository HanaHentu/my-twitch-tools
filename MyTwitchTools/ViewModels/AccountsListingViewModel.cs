using MyTwitchTools.Commands;
using MyTwitchTools.Models;
using MyTwitchTools.Services;
using MyTwitchTools.Stores;
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
        private readonly AccountsStore _accountsStore;

        private AccountViewModel _selectedAccount;
        public AccountViewModel SelectedAccount
        {
            get
            {
                return _selectedAccount;
            }
            set
            {
                if (_selectedAccount != value)
                {
                    _selectedAccount = value;
                    OnPropertyChanged(nameof(SelectedAccount));
                }
            }
        }

        public IEnumerable<AccountViewModel> Accounts => _accountsStore.Accounts;

        public ICommand AddAccountCommand { get; }
        public ICommand RemoveAccountCommand { get; }

        public AccountsListingViewModel(AccountsStore accountsStore, INavigationService addAccountNavigationService)
        {
            _accountsStore = accountsStore;

            AddAccountCommand = new NavigateCommand(addAccountNavigationService);
            RemoveAccountCommand = new RemoveAccountCommand(this, accountsStore);
        }
    }
}
