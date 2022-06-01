using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMongoFarmacia.Model;
using MongoDB.Driver;

namespace ApiMongoFarmacia.Service
{
    public class MongoService
    {
        //Agafem les col·leccions
        private MongoClient mongoClient;
        public IMongoCollection<Producte> producteCollection { get; set; }
        public IMongoCollection<Farmacia> farmaciaCollection { get; set; }
        public IMongoCollection<User> userCollection { get; set; }
        public MongoService(string collection)
        {
            //Posem el link del Mongo
            mongoClient = new MongoClient("mongodb+srv://samu:samu123456@projectecanpixa.byxki.mongodb.net/test");
            var database = mongoClient.GetDatabase("FarmApp");
           
            if (collection == "Farmacia")
            {
                farmaciaCollection = database.GetCollection<Farmacia>(collection);
                producteCollection = null;
            }
            else if (collection == "Producte")
            {
                producteCollection = database.GetCollection<Producte>(collection);
                farmaciaCollection = null;
            }
            else if (collection == "User")
            {
                userCollection = database.GetCollection<User>(collection);
                farmaciaCollection = null;
            }
        }
    }
}



