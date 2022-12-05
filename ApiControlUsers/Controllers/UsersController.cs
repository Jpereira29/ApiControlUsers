using ApiControlUsers.Models;
using ApiControlUsers.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace ApiControlUsers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUnitOfWork _ofWork;

        public UsersController(IUnitOfWork contex)
        {
            _ofWork = contex;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetAsync()
        {
            var users = await _ofWork.UserRepository.Get().ToListAsync();
            if (users.Count == 0)
            {
                return NoContent();
            }
            return Ok(users);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> GetByIdAsync(int id)
        {
            var user = await _ofWork.UserRepository.GetById(p => p.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostAsync(User user)
        {
            _ofWork.UserRepository.Add(user);
            await _ofWork.Commit();

            return StatusCode(StatusCodes.Status201Created, user);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> PutAsync(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            _ofWork.UserRepository.Update(user);
            await _ofWork.Commit();

            return Ok(user);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var user = await _ofWork.UserRepository.GetById(p => p.UserId == id);
            if (user == null)
            {
                return NotFound();
            }
            _ofWork.UserRepository.Delete(user);
            await _ofWork.Commit();

            return Ok();
        }
    }
}
