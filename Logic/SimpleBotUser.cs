using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using SimpleBot.Repository;
using SimpleBot.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    // Parabens! Voce corrigiu a classe!!! Ela nao é mais static.
    
    public class SimpleBotUser
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMessageRepository _messageRepository;

        // Esta 100% correto. Uma alternativa seria passar os objetos atraves
        // do construtor, deixando que a logica nao conheca o repositorio fisico
        public SimpleBotUser(IMessageRepository messageRepository, IUserProfileRepository userProfileRepository)
        {
            _messageRepository = messageRepository;
            _userProfileRepository = userProfileRepository;
        }

        public string Reply(Message message)
        {
            //_messageRepository.SalvarHistorico(message);

            var profile = _userProfileRepository.GetProfile(message.Id);

            profile.Visitas++;

            _userProfileRepository.SetProfile(message.Id, profile);

            return $"{message.User} disse '{message.Text}'";
        }
    }
}
