using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SimpleBot
{
    public class SimpleBotUser
    {
        public static string Reply(Message message)
        {
            // Teste
            MongoClient client = new MongoClient(ConfigurationManager.ConnectionStrings["mongoDB"].ConnectionString);
            var db = client.GetDatabase("net13");
            var collection = db.GetCollection<BsonDocument>("message");

            var doc = new BsonDocument
            {
                { "id", message.Id },
                { "user", message.User },
                { "text", message.Text }
            };

            collection.InsertOne(doc);

            return $"{message.User} disse '{message.Text}'";
        }

        public static UserProfile GetProfile(string id)
        {
            return null;
        }

        public static void SetProfile(string id, UserProfile profile)
        {
        }
    }
}