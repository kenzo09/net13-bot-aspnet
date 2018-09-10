using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository
{
    public interface IMessageRepository
    {
        void SalvarHistorico(Message message);
    }
}