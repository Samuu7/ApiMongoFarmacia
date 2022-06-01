using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMongoFarmacia.Model
{
    public class Producte
    {
     
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String id { get; set; }

        [BsonElement("name")]
        public String Name { get; set; }

        [BsonElement("descripcio")]
        public String Descripcio { get; set; }

        [BsonElement("data")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Data { get; set; }

        [BsonElement("representantfarmacia")]
        public String Representant { get; set; }

        [BsonElement("stock")]
        public int Stock { get; set; }

        public Producte(string nom, string descripcio, DateTime data, string representantfarm, int stock)
        {
            this.Name = nom;
            this.Descripcio = descripcio;
            this.Data = data;
            this.Representant = representantfarm;
            this.Stock= stock;
        }

        public Producte()
        {

        }

    }
}
