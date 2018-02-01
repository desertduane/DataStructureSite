using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataStructureSite.Models;

namespace DataStructureSite.Controllers
{
    public class DatastructuresController : Controller
    {
        private readonly DataStructureSiteContext _context;

        public DatastructuresController(DataStructureSiteContext context)
        {
            _context = context;
        }

        // GET: Datastructures
        public IActionResult Index()
        {
            return View();
        }

        // GET: Datastructures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datastructure = await _context.Datastructure
                .SingleOrDefaultAsync(m => m.ID == id);
            if (datastructure == null)
            {
                return NotFound();
            }

            return View(datastructure);
        }

        // GET: Datastructures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Datastructures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,Solution")] Datastructure datastructure)
        {
            if (ModelState.IsValid)
            {
                _context.Add(datastructure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(datastructure);
        }

        // GET: Datastructures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datastructure = await _context.Datastructure.SingleOrDefaultAsync(m => m.ID == id);
            if (datastructure == null)
            {
                return NotFound();
            }
            return View(datastructure);
        }

        // POST: Datastructures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,Solution")] Datastructure datastructure)
        {
            if (id != datastructure.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(datastructure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DatastructureExists(datastructure.ID))
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
            return View(datastructure);
        }

        // GET: Datastructures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var datastructure = await _context.Datastructure
                .SingleOrDefaultAsync(m => m.ID == id);
            if (datastructure == null)
            {
                return NotFound();
            }

            return View(datastructure);
        }

        // POST: Datastructures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var datastructure = await _context.Datastructure.SingleOrDefaultAsync(m => m.ID == id);
            _context.Datastructure.Remove(datastructure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DatastructureExists(int id)
        {
            return _context.Datastructure.Any(e => e.ID == id);
        }
    }
}
