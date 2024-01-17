using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudDeProduto.Data;
using CrudDeProduto.Models;

namespace CrudDeProduto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoProdutosController : ControllerBase
    {
        private readonly ProdutoContext _context;

        public TodoProdutosController(ProdutoContext context)
        {
            _context = context;
        }

        // GET: api/TodoProdutos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoProduto>>> GetTodoProduto()
        {
            List<TodoProduto> todoProdutos = new List<TodoProduto>();

            todoProdutos = await _context.TodoProduto.ToListAsync();

            foreach (var i in todoProdutos)
            {
                i.Categoria = await _context.Categoria.FirstOrDefaultAsync(ct => ct.Id == i.CategoriaId);
                
            }


            return todoProdutos;
        }

        // GET: api/TodoProdutos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TodoProduto>> GetTodoProduto(int id)
        {
            var todoProduto = await _context.TodoProduto.FindAsync(id);

            if (todoProduto == null)
            {
                return NotFound();
            }

            return todoProduto;
        }

        // PUT: api/TodoProdutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTodoProduto(int id, TodoProduto todoProduto)
        {
            if (id != todoProduto.Id)
            {
                return BadRequest();
            }

            _context.Entry(todoProduto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoProdutoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/TodoProdutos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TodoProduto>> PostTodoProduto(TodoProduto todoProduto)
        {
            todoProduto.Categoria = await _context.Categoria.FirstOrDefaultAsync(ct => ct.Id == todoProduto.Categoria.Id);
            todoProduto.Categoria.Id = todoProduto.Categoria.Id;

            _context.TodoProduto.Add(todoProduto);

            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoProduto", new { id = todoProduto.Id }, todoProduto);
        }

        // DELETE: api/TodoProdutos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTodoProduto(int id)
        {
            var todoProduto = await _context.TodoProduto.FindAsync(id);
            if (todoProduto == null)
            {
                return NotFound();
            }

            _context.TodoProduto.Remove(todoProduto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TodoProdutoExists(int id)
        {
            return _context.TodoProduto.Any(e => e.Id == id);
        }
    }
}
