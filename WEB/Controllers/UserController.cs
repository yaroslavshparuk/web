using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WEB.DTOs;
using WEB.Models;

namespace WEB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly DAL.AppContext _context;

        public UserController(DAL.AppContext context)
        {
            _context = context;
        }

        [Route("get")]
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _context.Users.ToArray();
        }

        [Route("get/{id}")]
        [HttpGet]
        public User GetById(int id)
        {
            return _context.Users.FirstOrDefault(x => x.Id == id);
        }

        [Route("create")]
        [HttpPost]
        public IActionResult Create([FromBody] UserDTO user)
        {
            if (user == null) { throw new ArgumentNullException(); }
            _context.Users.Add(new User { FullName = user.FullName, Age = Convert.ToInt32(user.Age), Phone = user.Phone });
            _context.SaveChanges();
            return Ok();
        }

        [Route("edit/{id}")]
        [HttpPut]
        public IActionResult Edit(int id, [FromBody] UserDTO userToEdit)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user == null) { return BadRequest("User not found."); }
            user.Age = Convert.ToInt32(userToEdit.Age);
            user.FullName = userToEdit.FullName;
            user.Phone = userToEdit.Phone;
            _context.Users.Update(user);
            _context.SaveChanges();
            return Ok();
        }
    }
}