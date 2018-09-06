using MongoDB.Bson;
using MongoDB.Bson.Serialization;
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
            SalvarHistorico(message);
            SetProfile(message.Id, GetProfile(message.Id));

            return $"{message.User} disse '{message.Text}'";
        }

        public static void SalvarHistorico(Message message)
        {
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
        }

        public static UserProfile GetProfile(string id)
        {
            MongoClient client = new MongoClient(ConfigurationManager.ConnectionStrings["mongoDB"].ConnectionString);
            var db = client.GetDatabase("net13");
            var collection = db.GetCollection<BsonDocument>("userProfile");

            var filtro = Builders<BsonDocument>.Filter.Eq("id", id);
            var bsonProfile = collection.Find(filtro).FirstOrDefault();

            if (bsonProfile == null)
            {
                return new UserProfile
                {
                    Id = id,
                    Visitas = 0
                };
            }
            
            return new UserProfile
            {
                Id = bsonProfile["id"].ToString(),
                Visitas = bsonProfile["visitas"].ToInt32()
            };
        }

        public static void SetProfile(string id, UserProfile profile)
        {
            MongoClient client = new MongoClient(ConfigurationManager.ConnectionStrings["mongoDB"].ConnectionString);
            var db = client.GetDatabase("net13");
            var collection = db.GetCollection<BsonDocument>("userProfile");

            profile.Visitas++;

            var bson = new BsonDocument
            {
                { "id", profile.Id },
                { "visitas", profile.Visitas }
            };

            if (profile.Visitas == 1)
            {
                collection.InsertOne(bson);
            }
            else
            {
                collection.ReplaceOne(Builders<BsonDocument>.Filter.Eq("id", id), bson);
            }
        }
    }
}