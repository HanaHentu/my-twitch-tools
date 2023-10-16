using MyTwitchTools.Commands;
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
    public class AddAccountViewModel : ViewModelBase
    {
        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        public AddAccountViewModel(AccountsStore accountsStore, INavigationService closeNavigationService)
        {
            SubmitCommand = new AddAccountCommand(this, accountsStore, closeNavigationService);
            CancelCommand = new NavigateCommand(closeNavigationService);
        }
    }
}
