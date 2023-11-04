using MyTwitchTools.Models;
using MyTwitchTools.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyTwitchTools.Stores
{
    public class AccountsStore
    {
        private readonly ObservableCollection<AccountViewModel> _accounts = new ObservableCollection<AccountViewModel>();
        public IEnumerable<AccountViewModel> Accounts => _accounts;

        public bool SelectedAccountChanged { get; private set; }

        private AccountViewModel _selectedAccount;
        public AccountViewModel SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
            }
        }

        public event Action AccountStatusChanged;

        public AccountsStore()
        {
            _accounts.Add(new AccountViewModel(new Account() { Login = "Hentu", Password = "qweqwe", IsActivated = true }));
            _accounts.Add(new AccountViewModel(new Account() { Login = "Lily", Password = "asdasd", IsActivated = true }));
            _accounts.Add(new AccountViewModel(new Account() { Login = "Xavick", Password = "zxczxc", IsActivated = false }));
        }

        public void AddAccount(Account account)
        {
            _accounts.Add(new AccountViewModel(account));
            AccountStatusChanged?.Invoke();
        }

        public void Remove(AccountViewModel accountViewModel)
        {
            _accounts.Remove(accountViewModel);
            if (SelectedAccount == accountViewModel) SelectFirstActivatedAccount();
            AccountStatusChanged?.Invoke();
        }

        public void ToggleAccountStatus(AccountViewModel accountViewModel)
        {
            accountViewModel.Account.IsActivated = !accountViewModel.Account.IsActivated;
            if (_selectedAccount == accountViewModel && !_selectedAccount.Account.IsActivated)
            {
                SelectFirstActivatedAccount();
            }
            AccountStatusChanged?.Invoke();
        }

        public void SelectFirstActivatedAccount()
        {
            SelectedAccount = _accounts.FirstOrDefault(a => a.Account.IsActivated);
            SelectedAccountChanged = true;
        }

        public void ResetSelectedAccountChanged()
        {
            SelectedAccountChanged = false;
        }
    }
}
