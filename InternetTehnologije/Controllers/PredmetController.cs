﻿using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternetTehnologije.DAL;
using InternetTehnologije.Models;

namespace InternetTehnologije.Controllers
{
    public class PredmetController : Controller
    {
        private readonly InternetTehnologijeContext _context;

        public PredmetController(InternetTehnologijeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var predmetiDb = await _context.Predmets.ToListAsync();

            var predmeti = predmetiDb.Select(predmet => new PredmetViewModel
            {
                Id = predmet.Id,
                Sifra = predmet.Sifra,
                Naziv = predmet.Naziv,
                Espb = predmet.Espb
            });

            return View(predmeti);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet1 = await _context.Predmets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (predmet1 == null)
            {
                return NotFound();
            }

            return View(predmet1);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PredmetPostModel predmet)
        {
            if (ModelState.IsValid)
            {
                var predmetDto = new Predmet
                {
                    Naziv = predmet.Naziv,
                    Sifra = predmet.Sifra,
                    Espb = predmet.Espb
                };

                _context.Add(predmetDto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(predmet);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = await _context.Predmets.FindAsync(id);
            if (predmet == null)
            {
                return NotFound();
            }

            var predmetViewModel = new PredmetPostModel
            {
                Id = predmet.Id,
                Sifra = predmet.Sifra,
                Naziv = predmet.Naziv,
                Espb = predmet.Espb
            };
            return View(predmetViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, PredmetPostModel predmetViewModel)
        {
            if (id != predmetViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var predmet = new Predmet
                    {
                        Id = predmetViewModel.Id,
                        Naziv = predmetViewModel.Naziv,
                        Espb = predmetViewModel.Espb,
                        Sifra = predmetViewModel.Sifra
                    };
                    _context.Update(predmet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PredmetExists(predmetViewModel.Id))
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
            return View(predmetViewModel);
        }

        // GET: Predmet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var predmet = await _context.Predmets
                .FirstOrDefaultAsync(m => m.Id == id);
            if (predmet == null)
            {
                return NotFound();
            }

            return View(predmet);
        }

        // POST: Predmet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var predmet = await _context.Predmets.FindAsync(id);
            _context.Predmets.Remove(predmet);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PredmetExists(int id)
        {
            return _context.Predmets.Any(e => e.Id == id);
        }
    }
}
