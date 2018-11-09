using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using STI.Models;

namespace STI.Controllers
{
    public class ejerciciosController : Controller
    {
        private readonly STIContext _context;

        public ejerciciosController(STIContext context)
        {
            _context = context;
        }

        // GET: ejercicios
        public async Task<IActionResult> Index()
        {
            return View(await _context.ejercicios.ToListAsync());
        }

        // GET: ejercicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicios = await _context.ejercicios
                .FirstOrDefaultAsync(m => m.id_ejercicio == id);
            if (ejercicios == null)
            {
                return NotFound();
            }

            return View(ejercicios);
        }

        // GET: ejercicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ejercicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_ejercicio,nombre_ejercicio,puntaje,id_temas")] ejercicios ejercicios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ejercicios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ejercicios);
        }

        // GET: ejercicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicios = await _context.ejercicios.FindAsync(id);
            if (ejercicios == null)
            {
                return NotFound();
            }
            return View(ejercicios);
        }

        // POST: ejercicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_ejercicio,nombre_ejercicio,puntaje,id_temas")] ejercicios ejercicios)
        {
            if (id != ejercicios.id_ejercicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ejercicios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ejerciciosExists(ejercicios.id_ejercicio))
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
            return View(ejercicios);
        }

        // GET: ejercicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ejercicios = await _context.ejercicios
                .FirstOrDefaultAsync(m => m.id_ejercicio == id);
            if (ejercicios == null)
            {
                return NotFound();
            }

            return View(ejercicios);
        }

        // POST: ejercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ejercicios = await _context.ejercicios.FindAsync(id);
            _context.ejercicios.Remove(ejercicios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ejerciciosExists(int id)
        {
            return _context.ejercicios.Any(e => e.id_ejercicio == id);
        }
    }
}