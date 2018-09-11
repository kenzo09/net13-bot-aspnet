using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository.Entities
{
    public class MessageMongo
    {
        public string _id { get; }
        public string User { get; }
        public string Text { get; }

        public MessageMongo(Message message)
        {
            _id = message.Id;
            User = message.User;
            Text = message.Text;
        }
    }
}