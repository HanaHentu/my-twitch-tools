using MyTwitchTools.Commands;
using MyTwitchTools.Services;
using MyTwitchTools.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                    OnPropertyChanged(nameof(IsAccountSelected));
                }
            }
        }

        public bool IsAccountSelected => SelectedAccount != null;

        private IEnumerable<AccountViewModel> _accounts;
        public IEnumerable<AccountViewModel> Accounts
        {
            get => _accounts;
            set
            {
                _accounts = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddAccountCommand { get; }
        public ICommand RemoveAccountCommand { get; }
        public ICommand ToggleAccountStateCommand { get; }

        public AccountsListingViewModel(AccountsStore accountsStore, INavigationService addAccountNavigationService)
        {
            _accountsStore = accountsStore;

            AddAccountCommand = new NavigateCommand(addAccountNavigationService);
            RemoveAccountCommand = new RemoveAccountCommand(this, accountsStore);
            ToggleAccountStateCommand = new ToggleAccountStateCommand(this, accountsStore);

            _accountsStore.AccountStatusChanged += OnAccountStatusChanged;
            Accounts = new ObservableCollection<AccountViewModel>(_accountsStore.Accounts);
        }

        private void OnAccountStatusChanged()
        {
            Accounts = new ObservableCollection<AccountViewModel>(_accountsStore.Accounts);
        }

        public override void Dispose()
        {
            _accountsStore.AccountStatusChanged -= OnAccountStatusChanged;

            base.Dispose();
        }
    }
}
