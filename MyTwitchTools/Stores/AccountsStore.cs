using MyTwitchTools.Models;
using MyTwitchTools.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MyTwitchTools.Stores
{
    public class AccountsStore
    {
        private readonly ObservableCollection<AccountViewModel> _accounts = new ObservableCollection<AccountViewModel>();
        public IEnumerable<AccountViewModel> Accounts => _accounts;

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
        }

        public void Remove(AccountViewModel accountViewModel)
        {
            _accounts.Remove(accountViewModel);
        }

        public void ToggleAccountStatus(AccountViewModel accountViewModel)
        {
            accountViewModel.Account.IsActivated = !accountViewModel.Account.IsActivated;
            AccountStatusChanged?.Invoke();
        }
    }
}
