using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InternetTehnologije.DAL;
using InternetTehnologije.Models;

namespace InternetTehnologije.Controllers
{
    public class SmerController : Controller
    {
        private readonly InternetTehnologijeContext _context;

        public SmerController(InternetTehnologijeContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var smerDb = await _context.Smers.ToListAsync();

            var smerViewModel = smerDb.Select(smer => new SmerViewModel
            {
                Id = smer.Id,
                Sifra = smer.Sifra,
                Naziv = smer.Naziv
            }).ToList();

            return View(smerViewModel);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smer = await _context.Smers.FirstOrDefaultAsync(m => m.Id == id);

            if (smer == null)
            {
                return NotFound();
            }

            var predmetiZaSmer = await _context.PredmetSmers.Include(p => p.Predmet).Where(s => s.SmerId == id).ToListAsync();

            var smerViewModel = new SmerViewModel
            {
                Id = smer.Id,
                Sifra = smer.Sifra,
                Naziv = smer.Naziv,
                SpisakPredmeta = string.Join(", ", predmetiZaSmer.Select(p => p.Predmet.Naziv))
            };

            return View(smerViewModel);
        }

        public IActionResult Create()
        {
            var listaPredmeta = _context.Predmets.ToListAsync().Result.Select(p => new PredmetViewModel
            {
                Id = p.Id,
                Naziv = p.Naziv
            }).ToList();

            var viewModel = new SmerViewModel { Predmeti = listaPredmeta };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SmerViewModel smer)
        {
            if (ModelState.IsValid)
            {
                var smerDb = new Smer
                {
                    Naziv = smer.Naziv,
                    Sifra = smer.Sifra
                };

                var a = _context.Add(smerDb);
                await _context.SaveChangesAsync();

                if (smer.PredmetiIds != null)
                {
                    var predmetSmer = smer.PredmetiIds.Select(p => new PredmetSmer { PredmetId = p, SmerId = a.Entity.Id }).ToList();
                    _context.AddRange(predmetSmer);
                    await _context.SaveChangesAsync();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(smer);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smer = await _context.Smers.FindAsync(id);

            var predmetiZaSmer = _context.PredmetSmers.Include(p => p.Predmet)
                .Where(smer => smer.SmerId == id).ToListAsync().Result
                .Select(p => new PredmetViewModel
                {
                    Id = p.PredmetId,
                    Naziv = p.Predmet.Naziv
                }).ToList();

            var sviPredmeti = _context.Predmets.ToListAsync().Result.Select(p => new PredmetViewModel
            {
                Id = p.Id,
                Naziv = p.Naziv
            }).ToList();

            var smerViewModel = new SmerViewModel
            {
                Id = smer.Id,
                Naziv = smer.Naziv,
                Sifra = smer.Sifra,
                Predmeti = sviPredmeti,
                OznaceniPredmeti = string.Join(",", predmetiZaSmer.Select(pred => pred.Id).ToArray())
            };

            if (smer == null)
            {
                return NotFound();
            }
            return View(smerViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SmerViewModel smer)
        {
            if (id != smer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var smerDb = _context.Smers.FirstOrDefaultAsync(s => s.Id == id).Result;

                smerDb.Naziv = smer.Naziv;
                smerDb.Sifra = smer.Sifra;

                var predmetiZaSmer = _context.PredmetSmers.Where(s => s.SmerId == id).ToList();
                _context.RemoveRange(predmetiZaSmer);

                if (smer.PredmetiIds != null)
                {
                    var predmetSmer = smer.PredmetiIds.Select(p => new PredmetSmer { PredmetId = p, SmerId = id }).ToList();
                    await _context.PredmetSmers.AddRangeAsync(predmetSmer);
                }

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(smer);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var smer = await _context.Smers
                .FirstOrDefaultAsync(m => m.Id == id);

            var smerViewModel = new SmerViewModel
            {
                Id = smer.Id,
                Sifra = smer.Sifra,
                Naziv = smer.Naziv
            };

            if (smer == null)
            {
                return NotFound();
            }

            return View(smerViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var smer = await _context.Smers.FindAsync(id);
            var predmetiZaSmer = _context.PredmetSmers.Where(s => s.SmerId == id);
            _context.PredmetSmers.RemoveRange(predmetiZaSmer);
            _context.Smers.Remove(smer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
