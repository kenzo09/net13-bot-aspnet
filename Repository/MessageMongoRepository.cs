using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SimpleBot.Repository
{
    public class MessageMongoRepository : IMessageRepository
    {
        private readonly IMongoCollection<MessageMongo> _collection;

        public MessageMongoRepository()
        {
            _collection = new MongoClient(ConfigurationManager.ConnectionStrings["mongoDB"].ConnectionString)
                .GetDatabase("net13")
                .GetCollection<MessageMongo>("message");
        }

        public void SalvarHistorico(Message message)
        {
            _collection.InsertOne(new MessageMongo(message));
        }
    }
}