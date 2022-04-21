using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private UserRepository _userRepository;

        public UsersController()
        {
            _userRepository = UserRepository.Instance;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userRepository.GetUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);

            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult AddUser([FromBody] UserDto userDto)
        {
            var addedUser = _userRepository.AddUser(userDto);
            var uri = new Uri(Request.GetDisplayUrl().ToString() + addedUser.Id);
            return Created(uri, addedUser);
        }

        [HttpPut]
        public IActionResult UpdateUser([FromBody] UserDto userDto)
        {
            var addedUser = _userRepository.UpdateUser(userDto);
            
            return Ok(addedUser);
        }

        [HttpDelete("{userId}")]
        public IActionResult DeleteUser(int userId)
        {
            var getUser = _userRepository.GetUserById(userId);

            if (getUser == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(userId);
            return Ok();
        }
    }

}