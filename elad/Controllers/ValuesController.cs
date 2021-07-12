
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
//using AutoMapper;

namespace elad.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        IUserBL _userBL;
      
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(IUserBL userBL, ILogger<ValuesController> logger)
        {
            _logger = logger;
            _userBL = userBL;
       
        }

        string filepath = "../ss.txt";

        // GET api/values



        // GET api/<ValuesControlle r>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }



        [HttpGet("{email}/{password}")]
        public async Task<ActionResult<User>> Login(string email, string password)
        {

            
            _logger.LogInformation("Loging attempted with User Name ,{0} ang password {1}", email, password);
            User user = await _userBL.GetUser(email, password);
            if (user == null)
                return NoContent();
            else
                return Ok(user);
        }

        // POST api/Values
        [HttpPost]
        //הכנסת משתמש חדש לקובץ:
        public async Task Post(User user)
        {
            await _userBL.PostUser(user);
        }



        // עדכון פרטי משתמש:

        [HttpPut]
        public async Task<User> Put(int Id, [FromBody] User userToUpdate)
        {
            return await _userBL.PutUser(Id, userToUpdate);
        }




        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }





    }
}