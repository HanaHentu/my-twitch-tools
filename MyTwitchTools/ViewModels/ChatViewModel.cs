using MyTwitchTools.Commands;
using MyTwitchTools.Services;
using MyTwitchTools.Stores;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace MyTwitchTools.ViewModels
{
    public class ChatViewModel : ViewModelBase
    {
        private readonly ChatMessagesStore _chatMessagesStore;
        private readonly AccountsStore _accountsStore;

        public AccountViewModel SelectedAccount
        {
            get
            {
                return _accountsStore.SelectedAccount;
            }
            set
            {
                if (_accountsStore.SelectedAccount != value)
                {
                    _accountsStore.SelectedAccount = value;
                    OnPropertyChanged(nameof(SelectedAccount));
                }
            }
        }

        public IEnumerable<AccountViewModel> Accounts => _accountsStore.Accounts.Where(account => account.Account.IsActivated);

        public ICommand NavigateHomeCommand { get; }

        public ChatViewModel(ChatMessagesStore chatMessagesStore, AccountsStore accountsStore, INavigationService homeNavigationService)
        {
            _chatMessagesStore = chatMessagesStore;
            _accountsStore = accountsStore;

            NavigateHomeCommand = new NavigateCommand(homeNavigationService);
        }
    }
}