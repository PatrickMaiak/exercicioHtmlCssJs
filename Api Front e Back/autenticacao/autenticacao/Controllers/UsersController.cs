using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using autenticacao.Data;
using autenticacao.Models;
using Microsoft.IdentityModel.Tokens;
using NuGet.Common;
using autenticacao.Controllers.Config;
using autenticacao.Dto;

namespace autenticacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AuthContext _context;

        public UsersController(AuthContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.User.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> login(UserDto user)
        {
            var token = "";
            var users = await _context.User.ToListAsync();
            var userlogado = (from u in users
                             where u.Password == user.Password & u.Username == user.Username
                             select u).ToList();
            if (!userlogado.IsNullOrEmpty()) 
            {
                token = TokenService.GenerateToken(userlogado[0]);
            }
            return new {token = token};
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
