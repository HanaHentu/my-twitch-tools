using MyTwitchTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitchTools.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        public Account Account { get; }

        public AccountViewModel(Account account)
        {
            Account = account;
        }
    }
}
