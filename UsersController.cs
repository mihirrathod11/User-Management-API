using Microsoft.AspNetCore.Mvc;
using UserManagementAPI.Models;

namespace UserManagementAPI.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        // Simple in-memory list — acts as our "database"
        private static List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Alice", Email = "alice@example.com", Age = 25 },
            new User { Id = 2, Name = "Bob",   Email = "bob@example.com",   Age = 30 }
        };

        private static int nextId = 3;

        // GET api/users — returns all users
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(users);
        }

        // GET api/users/1 — returns one user by ID
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound("User not found.");

            return Ok(user);
        }

        // POST api/users — creates a new user
        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            user.Id = nextId++;
            users.Add(user);
            return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
        }

        // PUT api/users/1 — updates an existing user
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] User updated)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound("User not found.");

            user.Name  = updated.Name;
            user.Email = updated.Email;
            user.Age   = updated.Age;

            return Ok(user);
        }

        // DELETE api/users/1 — deletes a user
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound("User not found.");

            users.Remove(user);
            return Ok("User deleted.");
        }
    }
}