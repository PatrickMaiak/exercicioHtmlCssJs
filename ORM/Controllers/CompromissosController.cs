using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ORM.Data;
using ORM.Models;

namespace ORM.Controllers
{
    public class CompromissosController : Controller
    {
        private readonly ORMContext _context;

        public CompromissosController(ORMContext context)
        {
            _context = context;
        }

        // GET: Compromissos
        public async Task<IActionResult> Index()
        {
            var compromissos = await _context.Compromisso.ToListAsync();

            foreach (var comprom in compromissos)
            {
                comprom.Local = await _context.Local.FirstOrDefaultAsync(l => l.Id == comprom.LocalId);
                comprom.Contato = await _context.Contato.FirstOrDefaultAsync(l => l.Id == comprom.ContatoId);
            }

            return View(compromissos);
                      
        }

        // GET: Compromissos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Compromisso == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromisso
                .FirstOrDefaultAsync(m => m.Id == id);
            compromisso.Local = new();
            compromisso.Local = await _context.Local.FirstOrDefaultAsync(l => l.Id == compromisso.LocalId);

            compromisso.Contato = new();
            compromisso.Contato = await _context.Contato.FirstOrDefaultAsync(l => l.Id == compromisso.ContatoId);
            if (compromisso == null)
            {
                return NotFound();
            }
            return View(compromisso);
        }

        // GET: Compromissos/Create
        public IActionResult Create()
        {
            List<SelectListItem> Contatos = new List<SelectListItem>();
            Contatos = _context.Contato.Select(c => new SelectListItem()
            { Text = c.Email, Value = c.Id.ToString() }).ToList();
            ViewBag.Contatos = Contatos;

            List<SelectListItem> Locais = new List<SelectListItem>();
            Locais = _context.Local.Select(c => new SelectListItem()
            { Text = c.Rua, Value = c.Id.ToString() }).ToList();
            ViewBag.Locais = Locais;


            return View();
            
        }

        // POST: Compromissos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descricao,Data,ContatoId,LocalId")] Compromisso compromisso)
        {
            compromisso.Local = new();
            compromisso.Local = await _context.Local.FirstOrDefaultAsync(l => l.Id == compromisso.LocalId);

            compromisso.Contato = new();
            compromisso.Contato = await _context.Contato.FirstOrDefaultAsync(l => l.Id == compromisso.ContatoId);

            _context.Add(compromisso);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
           
            
        }

        // GET: Compromissos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> Contatos = new List<SelectListItem>();
            Contatos = _context.Contato.Select(c => new SelectListItem()
            { Text = c.Email, Value = c.Id.ToString() }).ToList();
            ViewBag.Contatos = Contatos;

            List<SelectListItem> Locais = new List<SelectListItem>();
            Locais = _context.Local.Select(c => new SelectListItem()
            { Text = c.Rua, Value = c.Id.ToString() }).ToList();
            ViewBag.Locais = Locais;

            if (id == null || _context.Compromisso == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromisso.FindAsync(id);
            if (compromisso == null)
            {
                return NotFound();
            }
            return View(compromisso);
        }

        // POST: Compromissos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao,Data,ContatoId,LocalId")] Compromisso compromisso)
        {
                    compromisso.Local = await _context.Local.FirstOrDefaultAsync(l => l.Id == compromisso.LocalId);
                    compromisso.Contato = await _context.Contato.FirstOrDefaultAsync(l => l.Id == compromisso.ContatoId);
                   
                    _context.Update(compromisso);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));

              
        }

        // GET: Compromissos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Compromisso == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromisso
                .FirstOrDefaultAsync(m => m.Id == id);
            compromisso.Local = new();
            compromisso.Local = await _context.Local.FirstOrDefaultAsync(l => l.Id == compromisso.LocalId);

            compromisso.Contato = new();
            compromisso.Contato = await _context.Contato.FirstOrDefaultAsync(l => l.Id == compromisso.ContatoId);
            if (compromisso == null)
            {
                return NotFound();
            }

            return View(compromisso);
        }

        // POST: Compromissos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Compromisso == null)
            {
                return Problem("Entity set 'ORMContext.Compromisso'  is null.");
            }
            var compromisso = await _context.Compromisso.FindAsync(id);
            if (compromisso != null)
            {
                _context.Compromisso.Remove(compromisso);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompromissoExists(int id)
        {
            return (_context.Compromisso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
