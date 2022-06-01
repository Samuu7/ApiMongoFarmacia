using System;
using System.Collections.Generic;
using System.Linq;
using ApiMongoFarmacia.Model;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiMongoFarmacia.Service;

namespace ApiMongoFarmacia.Controllers
{

    [Route("api/user")]
    [ApiController]
      public class UserController : ControllerBase
      {
            [HttpGet]
            public List<User> Get()
            {
                return UserService.GetAll().ToList();
            }

            [HttpGet("{id}")]
            public User Get(String id)
            {
                UserService us = new UserService();
                return us.Get(id);
            }

            [HttpPost]
            public void Post([FromBody] User usuari)
            {
                UserService us = new UserService();
                us.Add(usuari);
            }

            [HttpPut("{id}")]
            public void Put([FromBody] User usuari, String id)
            {
                UserService us = new UserService();
                us.Update(usuari, id);
            }

            [HttpDelete("{id}")]
            public void Delete(String id)
            {
                UserService fs = new UserService();
                fs.Delete(id);
            }
        }
}
