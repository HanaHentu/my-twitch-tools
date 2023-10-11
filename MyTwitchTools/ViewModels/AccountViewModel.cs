using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitchTools.ViewModels
{
    public class AccountViewModel : ViewModelBase
    {
        public string Login { get; }

        public AccountViewModel(string login)
        {
            Login = login;
        }
    }
}
