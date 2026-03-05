using System;
using System.Collections.Generic;
using System.Text;

namespace MusicStore.Messages
{
    public class NotificationMessage
    {
        public NotificationMessage(string message)
        {
            Message = message;
        }
        public string Message { get; }
    }
}
