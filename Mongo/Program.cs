using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Mongo
{
    class Program
    {
        static void Main(string[] args)
        {
            //persist fruits
            var client = new MongoClient("mongodb://localhost/?w=1");

            var database = client.GetDatabase("test");

            var collection = database.GetCollection<BsonDocument>("fruits");

            var document = new BsonDocument
            {
                { "Name", "apple" }
            };

            collection.InsertOne(document);

            var objectId = document["_id"].ToString();

            
        }

        public IEnumerable<Fruit> Fruits { get; set; }

        public IEnumerable<Fruit> GetFruits()
        {
            return new List<Fruit>
            {
                new Fruit { Id = 1, Name = "apple" },
                new Fruit { Id = 2, Name = "orange" },
                new Fruit { Id = 3, Name = "pear" },
                new Fruit { Id = 4, Name = "strewberry" },
            };
        }

        public class Fruit
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
