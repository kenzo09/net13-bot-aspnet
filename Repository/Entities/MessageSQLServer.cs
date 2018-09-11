using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository.Entities
{
    public class MessageSQLServer
    {
        public string Id { get; set; }
        public string User { get; set; }
        public string Text { get; set; }
    }
}