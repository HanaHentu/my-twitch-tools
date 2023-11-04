using MyTwitchTools.Models;
using MyTwitchTools.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTwitchTools.Stores
{
    public class ChatMessagesStore
    {
        private readonly ObservableCollection<ChatMessageViewModel> _messages = new ObservableCollection<ChatMessageViewModel>();

        public event NotifyCollectionChangedEventHandler MessagesChanged
        {
            add { _messages.CollectionChanged += value; }
            remove { _messages.CollectionChanged -= value; }
        }

        public IEnumerable<ChatMessageViewModel> Messages => _messages;

        public ChatMessagesStore()
        {
            _messages.Add(new ChatMessageViewModel(new Message() { User = "Hentu", Text = "Sample message", Timestamp = DateTime.Now }));
            _messages.Add(new ChatMessageViewModel(new Message() { User = "Lily", Text = "Another sample message", Timestamp = DateTime.Now }));
        }

        public void SendMessage(Message Message)
        {
            _messages.Add(new ChatMessageViewModel(Message));
        }
    }
}
