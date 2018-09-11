using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository.Interfaces
{
    public interface IMessageRepository
    {
        void SalvarHistorico(Message message);
    }
}