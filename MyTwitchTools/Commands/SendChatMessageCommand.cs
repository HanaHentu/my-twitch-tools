using MyTwitchTools.Models;
using MyTwitchTools.Stores;
using MyTwitchTools.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitchTools.Commands
{
    public class SendChatMessageCommand : CommandBase
    {
        private readonly ChatMessagesStore _chatMessagesStore;
        private readonly ChatViewModel _chatViewModel;

        public SendChatMessageCommand(ChatViewModel chatViewModel, ChatMessagesStore chatMessagesStore)
        {
            _chatViewModel = chatViewModel;
            _chatMessagesStore = chatMessagesStore;

            _chatViewModel.PropertyChanged += (sender, args) => OnCanExecuteChanged();
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(_chatViewModel.CurrentMessageText);
        }

        public override void Execute(object parameter)
        {
            if (_chatViewModel.SelectedAccount == null)
            {
                _chatViewModel.ErrorMessage = "Please select an account before sending a message.";
                return;
            }

            Message message = new Message(
                _chatViewModel.SelectedAccount.Account.Login,
                _chatViewModel.CurrentMessageText,
                DateTime.Now
                );

            _chatMessagesStore.SendMessage(message);
            _chatViewModel.CurrentMessageText = string.Empty;
        }
    }
}
