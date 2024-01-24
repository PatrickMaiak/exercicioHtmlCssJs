using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudDeProduto.Data;

using CrudDeProduto.Models;
using Microsoft.IdentityModel.Tokens;
using CrudDeProduto.UserDto;
using Microsoft.AspNetCore.Authorization;

namespace CrudDeProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ProdutoContext _context;

        public UsersController(ProdutoContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        //[Authorize(Roles = "admin, gerente,root")]
        public async Task<ActionResult<IEnumerable<User>>> GetUser()
        {
            return await _context.User.ToListAsync();
        }

        // GET: api/Users/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<User>> GetUser(int id)
        //{
        //    var user = await _context.User.FindAsync(id);

        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return user;
        //}

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(int id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        //[Authorize(Roles = "admin, gerente, root")]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }


        [HttpPost("login")]
        

        public async Task<ActionResult<dynamic>> login(UserDto.UserDto user)
        {
            var token = "";
            var users = await _context.User.ToListAsync();
            var userlogado = (from u in users where u.Password == user.Password & u.Username == user.Username select u).ToList();

            if (!userlogado.IsNullOrEmpty())
            {
                token = TokenService.GenerateToken(userlogado[0]);
            }

            return new {token = token };
        }

        // DELETE: api/Users/5

        [HttpDelete("{id}")]
        //[Authorize (Roles ="admin, gerente, root")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.User.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.User.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.User.Any(e => e.Id == id);
        }
    }
}
