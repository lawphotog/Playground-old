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

            IMongoDatabase database = client.GetDatabase("test");

            IMongoCollection<Fruit> collection = database.GetCollection<Fruit>("fruits");
            
            var fruit = new Fruit { Name = "apple" };

            collection.InsertOne(fruit);

            var col = collection.Find(new BsonDocument()).ToList();

            foreach(var item in col)
            {
                Console.WriteLine(item.Id + " : " + item.Name);
            }

            Console.ReadLine();  
        }

        public IEnumerable<Fruit> Fruits { get; set; }

        public IEnumerable<Fruit> GetFruits()
        {
            return new List<Fruit>
            {
                new Fruit { Name = "apple" },
                new Fruit { Name = "orange" },
                new Fruit { Name = "pear" },
                new Fruit { Name = "strewberry" },
            };
        }

        public class Fruit
        {
            public ObjectId Id { get; set; }
            public string Name { get; set; }
        }
    }
}
