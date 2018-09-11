using MongoDB.Driver;
using SimpleBot.Repository.Entities;
using SimpleBot.Repository.Interfaces;
using System.Configuration;

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