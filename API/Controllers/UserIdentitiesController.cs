using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Route("api/identities")]
    [ApiController]
    public class UserIdentitiesController(IUserIdentityRepository repo) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<UserIdentity>>> GetUserIdentities()
        {
            return Ok(await repo.GetUserIdentitiesAsync());
        }

        [HttpGet("{id:int}")] // api/userIdentity/2
        public async Task<ActionResult<UserIdentity>> GetUserIdentity(int id)
        {
            var userIdentity = await repo.GetUserIdentityByIdAsync(id);

            if (userIdentity == null) return NotFound();

            return userIdentity;
        }

        [HttpPost]
        public async Task<ActionResult<UserIdentity>> CreateUserIdentity(UserIdentity userIdentity)
        {
            repo.AddUserIdentity(userIdentity);

            if (await repo.SaveChangesAsync())
            {
                return CreatedAtAction("GetUserIdentity", new { id = userIdentity.Id }, userIdentity);
            }

            return BadRequest("Problem creating userIdentity");
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateUserIdentity(int id, UserIdentity userIdentity)
        {
            if (userIdentity.Id != id || !UserIdentityExists(id))
            {
                return BadRequest("Cannot update this userIdentity");
            }

            repo.UpdateUserIdentity(userIdentity);

            if (await repo.SaveChangesAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem updating the userIdentity");
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteUserIdentity(int id)
        {
            var userIdentity = await repo.GetUserIdentityByIdAsync(id);

            if (userIdentity == null) return NotFound();

            repo.DeleteUserIdentity(userIdentity);

            if (await repo.SaveChangesAsync())
            {
                return NoContent();
            }

            return BadRequest("Problem deleting the userIdentity");
        }

        private bool UserIdentityExists(int id)
        {
            return repo.UserIdentityExists(id);
        }
    }
}
