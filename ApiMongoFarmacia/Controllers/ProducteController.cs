using System;
using System.Collections.Generic;
using System.Linq;
using ApiMongoFarmacia.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiMongoFarmacia.Service;

namespace ApiMongoFarmacia.Controllers
{
    //Ruta api/producte
    [Route("api/producte")]
    [ApiController]
    public class ProducteController : ControllerBase
    { 

        [HttpGet]
        public List<Producte> Get()
        {
            return ProducteService.GetAll().ToList();
        }

        //Agafem IDs
        [HttpGet("{id}")]
        public Producte Get(string id)
        {
            ProducteService ts = new ProducteService();
            return ts.Get(id);
        }
        //Afegir producte
        [HttpPost]
        public void Post([FromBody] Producte producte)
        {
            ProducteService ps = new ProducteService();
            ps.Add(producte);
        }
        //Actuaitzar producte
        [HttpPut]
        public void Put(Producte producte)
        {
            ProducteService ps = new ProducteService();
            ps.Update(producte);
        }
        //Borrar producte per ID
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ProducteService ps = new ProducteService();
            ps.Delete(id);
        }

    }
}

