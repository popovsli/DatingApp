using System.Security.Cryptography;
using System.Text;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
       public class UsersController : BaseApiController
    {
        private readonly DataContext context;
        public UsersController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await context.User.ToListAsync();
        }

        // api/users/3
        [Authorize]
         [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            return await context.User.FindAsync(id);
        }
    }
}