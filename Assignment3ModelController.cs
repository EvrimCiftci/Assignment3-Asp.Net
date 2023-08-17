using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using assignment3.Db;

namespace assignment3.Controllers
{
    public class Assignment3ModelController : Controller
    {
        private readonly Context _context;

        public Assignment3ModelController(Context context)
        {
            _context = context;
        }

        
        public async Task<IActionResult> Index()
        {
              return _context.Assignment3Model != null ? 
                          View(await _context.Assignment3Model.ToListAsync()) :
                          Problem("Entity set 'Context.Assignment3Model'  is null.");
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Assignment3Model == null)
            {
                return NotFound();
            }

            var assignment3Model = await _context.Assignment3Model
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment3Model == null)
            {
                return NotFound();
            }

            return View(assignment3Model);
        }

      
        public IActionResult Create()
        {
            return View();
        }

        // POST: Assignment3Model/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Property1,Property2")] Assignment3Model assignment3Model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assignment3Model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assignment3Model);
        }

        // GET: Assignment3Model/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Assignment3Model == null)
            {
                return NotFound();
            }

            var assignment3Model = await _context.Assignment3Model.FindAsync(id);
            if (assignment3Model == null)
            {
                return NotFound();
            }
            return View(assignment3Model);
        }

        // POST: Assignment3Model/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Property1,Property2")] Assignment3Model assignment3Model)
        {
            if (id != assignment3Model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assignment3Model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Assignment3ModelExists(assignment3Model.Id))
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
            return View(assignment3Model);
        }

        // GET: Assignment3Model/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Assignment3Model == null)
            {
                return NotFound();
            }

            var assignment3Model = await _context.Assignment3Model
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assignment3Model == null)
            {
                return NotFound();
            }

            return View(assignment3Model);
        }

        // POST: Assignment3Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Assignment3Model == null)
            {
                return Problem("Entity set 'Context.Assignment3Model'  is null.");
            }
            var assignment3Model = await _context.Assignment3Model.FindAsync(id);
            if (assignment3Model != null)
            {
                _context.Assignment3Model.Remove(assignment3Model);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Assignment3ModelExists(int id)
        {
          return (_context.Assignment3Model?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
