using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiMongoFarmacia.Model;
using ApiMongoFarmacia.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiMongoFarmacia.Controllers
{
    //ruta de la API
    [Route("api/farmacia")]
    [ApiController]
    public class FarmaciaController : ControllerBase
    {
        [HttpGet]
        public List<Farmacia> Get()
        {
            return FarmaciaService.GetAll().ToList();
        }
        //Agafar ID
        [HttpGet("{id}")]
        public Farmacia Get(String id)
        {
            FarmaciaService fs = new FarmaciaService();
            return fs.Get(id);
        }

        //Afegir farmacia
        [HttpPost]
        public void Post([FromBody] Farmacia farmacia)
        {
            FarmaciaService fs = new FarmaciaService();
            fs.Add(farmacia);
        }
        //Actualitzar farmacia per ID
        [HttpPut("{id}")]
        public void Put([FromBody] Farmacia farmacia, String id)
        {
            FarmaciaService fs = new FarmaciaService();
            fs.Update(farmacia, id);
        }

        //Borrar per ID
        [HttpDelete("{id}")]
        public void Delete(String id)
        {
            FarmaciaService fs = new FarmaciaService();
            fs.Delete(id);
        }
    }
}

