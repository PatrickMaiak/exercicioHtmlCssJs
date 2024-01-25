using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudDeProduto.Data;
using CrudDeProduto.Models;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "funcionario, gerente, root")]
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
        [Authorize(Roles = "funcionario, gerente, root")]
        public async Task<ActionResult<TodoProduto>> GetTodoProduto(int id)
        {
            var todoProduto = await _context.TodoProduto.FindAsync(id);

            if (todoProduto == null)
            {
                return NotFound();
            }

            return todoProduto;
        }

        [HttpGet("api/[controller]/categoria{id}")]
        [Authorize(Roles = "funcionario, gerente, root")]
        public async Task<ActionResult<IEnumerable<TodoProduto>>> GetProdutosDaCategoria(int id)
        {
            List<TodoProduto> todoProdutos = await _context.TodoProduto.ToListAsync();

            var Prod = (from todoProduto in todoProdutos where todoProduto.CategoriaId == id select todoProduto).ToList();

           
            Categoria categoria = await _context.Categoria.FirstOrDefaultAsync(categoria => categoria.Id == id);

            foreach (var todoProduto in Prod)
            {
                todoProduto.Categoria = categoria;
            }
           
            return Prod;
        }

        [HttpGet("pages")]
        [Authorize(Roles = "funcionario, gerente, root")]
        public async Task<ActionResult<IEnumerable<TodoProduto>>> GetPageProdutos(
             [FromQuery] int numeroDePaginas = 0,
             [FromQuery] int tamanhoDaPagina = 2
            )
        {
            List<TodoProduto> produto = await _context.TodoProduto.AsNoTracking().Skip(numeroDePaginas * tamanhoDaPagina).Take(tamanhoDaPagina).ToListAsync();
            return produto;
        }


        //api/produtos/descricao?nome=cola
        [HttpGet("/api/[controller]/descricao")]
        [Authorize(Roles = "funcionario, gerente, root")]
        public async Task<ActionResult<IEnumerable<TodoProduto>>> GetNameTodoProduto([FromQuery]string nome)
        {
            List<TodoProduto> produtobyname = await _context.TodoProduto.ToListAsync();

            var todoProdutos = (from prod in produtobyname where prod.Produto.ToLower().Contains(nome.ToLower()) select prod).ToList();

            foreach (var produto in todoProdutos)
            {
                produto.Categoria = await _context.Categoria.FirstOrDefaultAsync(c => c.Id == produto.CategoriaId);
            }
           
            return todoProdutos;
        }


        // PUT: api/TodoProdutos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "gerente, root")]
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
        [Authorize(Roles = "funcionario, root")]
        public async Task<ActionResult<TodoProduto>> PostTodoProduto(TodoProduto todoProduto)
        {
            //todoProduto.Categoria = await _context.Categoria.FirstOrDefaultAsync(ct => ct.Id == todoProduto.Categoria.Id);
           

            _context.TodoProduto.Add(todoProduto);

            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoProduto", new { id = todoProduto.Id }, todoProduto);
        }

        // DELETE: api/TodoProdutos/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin, root")]
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
