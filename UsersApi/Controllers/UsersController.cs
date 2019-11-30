using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Models;

namespace UsersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersContext _db;

        public UsersController(UsersContext db)
        {
            _db = db;


            _db.Users.Add(new User
            {
                Name = "Mike",
                Surname = "Smith",
                Birthday = new DateTime(1990, 11, 11),
                        
                
            }) ;
            _db.Users.Add(new User
            {
                Name = "Ben",
                Surname = "Broud",
                Birthday = new DateTime(1984, 05, 21)
                

            }) ;
            _db.SaveChanges();
        }
        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> Get()
        {

            return _db.Users.ToList(); 
        }

        // GET: api/Users/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            User user = _db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
                return NotFound();
            return new ObjectResult(user);
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            _db.Users.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }

        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody]User user)
        {
            if (user == null)
            {
                return BadRequest();
            }
            if (!_db.Users.Any(x => x.Id == user.Id))
            {
                return NotFound();
            }

            _db.Update(user);
            _db.SaveChanges();
            return Ok(user);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            User user = _db.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            _db.Users.Remove(user);
            _db.SaveChanges();
            return Ok(user);
        }
    }
}
