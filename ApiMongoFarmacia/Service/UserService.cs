using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMongoFarmacia.Model;
using MongoDB.Driver;

namespace ApiMongoFarmacia.Service
{
    public class UserService
    {
        public static IEnumerable<User> GetAll()
        {
            MongoService MS = new MongoService("User");
            List<User> result = MS.userCollection.AsQueryable<User>().ToList();

            return result;
        }
        //Afegir usuari
        public int Add(User user)
        {
            MongoService MS = new MongoService("User");
            MS.userCollection.InsertOne(user);
            return 1;
        }
        //Actualitzar usuari
        public int Update(User usuari, string id)
        {
            MongoService MS = new MongoService("User");
            var filter = Builders<User>.Filter.Eq("id", usuari.id);
            MS.userCollection.ReplaceOne(filter, usuari);
            return 1;
        }
        //Borrar usuari
        public int Delete(string id)
        {
            MongoService MS = new MongoService("User");
            var result = MS.producteCollection.DeleteOne(t => t.id == id);
            return (int)result.DeletedCount;
        }
        //Cridem usuari
        public User Get(string id)
        {
            MongoService MS = new MongoService("User");
            List<User> result = MS.userCollection.AsQueryable().Where(t => t.id == id).ToList();
            return result[0];
        }
    }
}



    