using MyTwitchTools.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitchTools.ViewModels
{
    public class ChatMessageViewModel : ViewModelBase
    {
        private readonly Message _message;

        public string Timestamp
        {
            get { return _message.Timestamp.ToString("T"); }
        }

        public string User
        {
            get { return _message.User; }
        }

        public string Text
        {
            get { return _message.Text; }
        }

        public ChatMessageViewModel(Message message)
        {
            _message = message;
        }
    }
}
