﻿using System;
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
    public class CategoriasController : ControllerBase
    {
        private readonly ProdutoContext _context;

        public CategoriasController(ProdutoContext context)
        {
            _context = context;
        }


        // GET: api/Categorias
        [HttpGet]
        [Authorize(Roles = "funcionario, root")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
        {
            return await _context.Categoria.ToListAsync();
        }






        [HttpGet("api/[controller]/categoria{Id}")]
        [Authorize(Roles = "funcionario, gerente, root")]
        public async Task<ActionResult<IEnumerable<TodoProduto>>> GetProdutosDaCategoria(int Id)
        {
            List<TodoProduto> todoProdutos = new List<TodoProduto>();


            todoProdutos = (from todoProduto in _context.TodoProduto where todoProduto.CategoriaId == Id select todoProduto).ToList();

            todoProdutos = await _context.TodoProduto.ToListAsync();

            var categoria = await _context.Categoria.FindAsync(Id);



            if (categoria == null)
            {
                return NotFound();
            }


            return todoProdutos;
        }


        // GET: api/Categorias/5s
        [HttpGet("{id}")]
        [Authorize(Roles = "funcionario, gerente, root")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "gerente, root")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
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

        // POST: api/Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles = "funcionario, root")]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin, root")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaExists(int id)
        {
            return _context.Categoria.Any(e => e.Id == id);
        }
    }
}
