using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace ApiMongoFarmacia.Model
{
    public class Farmacia
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String id { get; set; }
     
        [BsonElement("nom")]
        public String Nom { get; set; }

        [BsonElement("carrer")]
        public String Carrer { get; set; }

        [BsonElement("telefon")]
        public String Telefon { get; set; }


        public Farmacia(string nom, string carrer, string telefon)
        {
            this.Nom = nom;
            this.Carrer = carrer;
            this.Telefon = telefon;

        }

        public Farmacia() { }

       
    }
}
