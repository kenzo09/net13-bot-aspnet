using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using SimpleBot.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        private readonly IUserProfileRepository _userProfileRepository;
        private readonly IMessageRepository _messageRepository;

        public SimpleBotUser()
        {
            _messageRepository = new MessageMongoRepository();
            _userProfileRepository = new UserProfileMongoRepository();
        }

        public string Reply(Message message)
        {
            _messageRepository.SalvarHistorico(message);

            var profile = _userProfileRepository.GetProfile(message.Id);

            profile.Visitas++;

            _userProfileRepository.SetProfile(message.Id, profile);

            return $"{message.User} disse '{message.Text}'";
        }
    }
}