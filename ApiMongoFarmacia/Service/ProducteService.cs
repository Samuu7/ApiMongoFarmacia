using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMongoFarmacia.Model;
using MongoDB.Driver;

namespace ApiMongoFarmacia.Service
{
    public class ProducteService
    {
        public static IEnumerable<Producte> GetAll()
        {
            MongoService MS = new MongoService("Producte");
            List<Producte> result = MS.producteCollection.AsQueryable<Producte>().ToList();

            return result;
        }
        //Afegim producte
        public int Add(Producte producte)
        {
            MongoService MS = new MongoService("Producte");
            MS.producteCollection.InsertOne(producte);
            return 1;
        }
        //Actualitzem producte
        public int Update(Producte producte)
        {
            MongoService MS = new MongoService("Producte");
            var filter = Builders<Producte>.Filter.Eq("id", producte.id);
            MS.producteCollection.ReplaceOne(filter, producte);
            return 1;
        }
        //Borrar producte
        public int Delete(string id)
        {
            MongoService MS = new MongoService("Producte");
            var result = MS.producteCollection.DeleteOne(t => t.id == id);
            return (int)result.DeletedCount;
        }
        //Cridem al producte
        public Producte Get(string id)
        {
            MongoService MS = new MongoService("Producte");
            List<Producte> result = MS.producteCollection.AsQueryable().Where(t => t.id == id).ToList();
            return result[0];
        }
    }
}


