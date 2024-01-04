using System;

namespace MyTwitchTools.Models
{
    public class Message
    {
        public string User { get; }
        public string Text { get; }
        public DateTime Timestamp { get; }

        public Message(string user, string text, DateTime timestamp)
        {
            User = user;
            Text = text;
            Timestamp = timestamp;
        }
    }
}
