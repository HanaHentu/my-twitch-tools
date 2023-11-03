using MyTwitchTools.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitchTools.Stores
{
    public class ChatMessagesStore
    {
        private readonly ObservableCollection<Message> _messages = new ObservableCollection<Message>();
        public IEnumerable<Message> Messages => _messages;

        public ChatMessagesStore()
        {
            _messages.Add(new Message() { User = "Hentu", Text = "Sample message", Timestamp = DateTime.Today });
            _messages.Add(new Message() { User = "Lily", Text = "Another sample message", Timestamp = DateTime.Today });
        }
    }
}
