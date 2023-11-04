using HandyControl.Controls;
using MyTwitchTools.Commands;
using MyTwitchTools.Services;
using MyTwitchTools.Stores;
using System.Collections.Generic;
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
                CheckSelectedAccountChanged();
                return _accountsStore.SelectedAccount;
            }
            set
            {
                if (_accountsStore.SelectedAccount != value)
                {
                    _accountsStore.SelectedAccount = value;
                    OnPropertyChanged(nameof(SelectedAccount));
                    CheckSelectedAccountChanged();
                    ErrorMessage = string.Empty;
                }
            }
        }

        private string _currentMessageText;
        public string CurrentMessageText
        {
            get { return _currentMessageText; }
            set
            {
                _currentMessageText = value;
                OnPropertyChanged(nameof(CurrentMessageText));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }

        public IEnumerable<AccountViewModel> Accounts => _accountsStore.Accounts.Where(account => account.Account.IsActivated);
        public IEnumerable<ChatMessageViewModel> Messages => _chatMessagesStore.Messages;

        public ICommand SendChatMessageCommand { get; }

        public ChatViewModel(ChatMessagesStore chatMessagesStore, AccountsStore accountsStore)
        {
            _chatMessagesStore = chatMessagesStore;
            _accountsStore = accountsStore;

            SendChatMessageCommand = new SendChatMessageCommand(this, _chatMessagesStore);

            _chatMessagesStore.MessagesChanged += OnMessagesChanged;
        }

        private void OnMessagesChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(Messages));
        }

        private void CheckSelectedAccountChanged()
        {
            if (_accountsStore.SelectedAccountChanged)
            {
                if (_accountsStore.SelectedAccount != null)
                {
                    MessageBox.Info($"The selected account has been changed to {_accountsStore.SelectedAccount.Account.Login}.", "Account change");
                }
                else
                {
                    MessageBox.Error("There are no active accounts.", "Account change");
                }
                _accountsStore.ResetSelectedAccountChanged();
            }
        }

        public override void Dispose()
        {
            _chatMessagesStore.MessagesChanged -= OnMessagesChanged;

            base.Dispose();
        }
    }
}