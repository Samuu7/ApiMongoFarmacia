using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiMongoFarmacia.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public String id { get; set; }

        [BsonElement("usuari")]
        public String Usuari { get; set; }

        [BsonElement("Email")]
        public String Email { get; set; }

        [BsonElement("Contrasenya")]
        public String Contrasenya { get; set; }

        public User(string usuari, string email, string contrasenya)
        {
            this.Usuari = usuari;
            this.Email = email;
            this.Contrasenya = contrasenya;

        }

        public User() { }


    }
}
