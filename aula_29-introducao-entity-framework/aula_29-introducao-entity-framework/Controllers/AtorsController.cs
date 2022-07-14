using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Mesa1.Models;
using Models.Mesa_1;

namespace aula_29_introducao_entity_framework.Controllers
{
    public class AtorsController : Controller
    {
        private readonly Catalogo _context;

        public AtorsController(Catalogo context)
        {
            _context = context;
        }

        // GET: Ators
        public async Task<IActionResult> Index()
        {
              return _context.Atores != null ? 
                          View(await _context.Atores.ToListAsync()) :
                          Problem("Entity set 'Catalogo.Atores'  is null.");
        }

        // GET: Ators/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atores == null)
            {
                return NotFound();
            }

            var ator = await _context.Atores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ator == null)
            {
                return NotFound();
            }

            return View(ator);
        }

        // GET: Ators/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome")] Ator ator)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ator);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ator);
        }

        // GET: Ators/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atores == null)
            {
                return NotFound();
            }

            var ator = await _context.Atores.FindAsync(id);
            if (ator == null)
            {
                return NotFound();
            }
            return View(ator);
        }

        // POST: Ators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome")] Ator ator)
        {
            if (id != ator.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ator);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtorExists(ator.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ator);
        }

        // GET: Ators/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atores == null)
            {
                return NotFound();
            }

            var ator = await _context.Atores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ator == null)
            {
                return NotFound();
            }

            return View(ator);
        }

        // POST: Ators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atores == null)
            {
                return Problem("Entity set 'Catalogo.Atores'  is null.");
            }
            var ator = await _context.Atores.FindAsync(id);
            if (ator != null)
            {
                _context.Atores.Remove(ator);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtorExists(int id)
        {
          return (_context.Atores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
