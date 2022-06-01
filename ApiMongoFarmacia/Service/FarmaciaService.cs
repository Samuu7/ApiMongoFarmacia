using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using ApiMongoFarmacia.Model;

namespace ApiMongoFarmacia.Service
{
    public class FarmaciaService
    {
        public static IEnumerable<Farmacia> GetAll()
        {
            MongoService MS = new MongoService("Farmacia");
            List<Farmacia> result = MS.farmaciaCollection.AsQueryable<Farmacia>().ToList();

            return result;
        }
        //Afegim farmàcia
        public int Add(Farmacia farmacia)
        {
            MongoService MS = new MongoService("Farmacia");
            if (MS.farmaciaCollection.AsQueryable<Farmacia>().Where(t => t.Nom == farmacia.Nom).ToList().Count == 0)
            {
                MS.farmaciaCollection.InsertOne(farmacia);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //Actualitzar la farmàcia
        public int Update(Farmacia farmacia, String Nom)
        {
            MongoService MS = new MongoService("Farmacia");
            if (MS.farmaciaCollection.AsQueryable<Farmacia>().Where(t => t.Nom == farmacia.Nom).ToList().Count == 0 || farmacia.Nom == Nom)
            {
                var filter = Builders<Farmacia>.Filter.Eq("nom", Nom);
                MS.farmaciaCollection.ReplaceOne(filter, farmacia);
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //Mètode per borrar una farmàcia
        public int Delete(String nom)
        {
            MongoService MS = new MongoService("Farmacia");
            var result = MS.farmaciaCollection.DeleteOne(t => t.Nom == nom);
            return (int)result.DeletedCount;
        }
        //Agafem el nom de les farmàcies
        public Farmacia Get(String nom)
        {
            MongoService MS = new MongoService("Farmacia");
            List<Farmacia> result = MS.farmaciaCollection.AsQueryable().Where(t => t.Nom == nom).ToList();
            try
            {
                return result[0];
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

