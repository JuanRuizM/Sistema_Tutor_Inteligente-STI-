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
    public class resultados_ejerciciosController : Controller
    {
        private readonly STIContext _context;

        public resultados_ejerciciosController(STIContext context)
        {
            _context = context;
        }

        // GET: resultados_ejercicios
        public async Task<IActionResult> Index()
        {
            return View(await _context.resultados_ejercicios.ToListAsync());
        }

        // GET: resultados_ejercicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados_ejercicios = await _context.resultados_ejercicios
                .FirstOrDefaultAsync(m => m.id_resultado_ejercicio == id);
            if (resultados_ejercicios == null)
            {
                return NotFound();
            }

            return View(resultados_ejercicios);
        }

        // GET: resultados_ejercicios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: resultados_ejercicios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id_resultado_ejercicio,acierto,id_ejercicio,id_usuario,fecha")] resultados_ejercicios resultados_ejercicios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultados_ejercicios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(resultados_ejercicios);
        }

        // GET: resultados_ejercicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados_ejercicios = await _context.resultados_ejercicios.FindAsync(id);
            if (resultados_ejercicios == null)
            {
                return NotFound();
            }
            return View(resultados_ejercicios);
        }

        // POST: resultados_ejercicios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id_resultado_ejercicio,acierto,id_ejercicio,id_usuario,fecha")] resultados_ejercicios resultados_ejercicios)
        {
            if (id != resultados_ejercicios.id_resultado_ejercicio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultados_ejercicios);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!resultados_ejerciciosExists(resultados_ejercicios.id_resultado_ejercicio))
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
            return View(resultados_ejercicios);
        }

        // GET: resultados_ejercicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultados_ejercicios = await _context.resultados_ejercicios
                .FirstOrDefaultAsync(m => m.id_resultado_ejercicio == id);
            if (resultados_ejercicios == null)
            {
                return NotFound();
            }

            return View(resultados_ejercicios);
        }

        // POST: resultados_ejercicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultados_ejercicios = await _context.resultados_ejercicios.FindAsync(id);
            _context.resultados_ejercicios.Remove(resultados_ejercicios);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool resultados_ejerciciosExists(int id)
        {
            return _context.resultados_ejercicios.Any(e => e.id_resultado_ejercicio == id);
        }
    }
}