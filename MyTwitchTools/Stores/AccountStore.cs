using MyTwitchTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitchTools.Stores
{
    public class AccountStore
    {
        private Account _currentAccount;
        public Account CurrentAccount
        {
            get => _currentAccount;
            set
            {
                _currentAccount = value;
            }
        }

        public bool IsLoggedIn => CurrentAccount != null;
    }
}
