using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WEBAPI_NGK;
using WEBAPI_NGK.DataLayer.Models;

namespace WEBAPI_NGK.Controllers
{
    public class WeatherinfoesController : Controller
    {
        private readonly WeatherContext _context;

        public WeatherinfoesController(WeatherContext context)
        {
            _context = context;
        }



        // GET: Weatherinfoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.weatherinfos.ToListAsync());
        }

        // GET: Weatherinfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherinfo = await _context.weatherinfos
                .FirstOrDefaultAsync(m => m.weatherinfoId == id);
            if (weatherinfo == null)
            {
                return NotFound();
            }

            return View(weatherinfo);
        }

        // GET: Weatherinfoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Weatherinfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("date,clocktime,temperature,humidity,airpressure")] Weatherinfo weatherinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weatherinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weatherinfo);
        }

        // GET: Weatherinfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherinfo = await _context.weatherinfos.FindAsync(id);
            if (weatherinfo == null)
            {
                return NotFound();
            }
            return View(weatherinfo);
        }

        // POST: Weatherinfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("weatherinfoId,date,clocktime,temperature,humidity,airpressure")] Weatherinfo weatherinfo)
        {
            if (id != weatherinfo.weatherinfoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weatherinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeatherinfoExists(weatherinfo.weatherinfoId))
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
            return View(weatherinfo);
        }

        // GET: Weatherinfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weatherinfo = await _context.weatherinfos
                .FirstOrDefaultAsync(m => m.weatherinfoId == id);
            if (weatherinfo == null)
            {
                return NotFound();
            }

            return View(weatherinfo);
        }

        // POST: Weatherinfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weatherinfo = await _context.weatherinfos.FindAsync(id);
            _context.weatherinfos.Remove(weatherinfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeatherinfoExists(int id)
        {
            return _context.weatherinfos.Any(e => e.weatherinfoId == id);
        }
    }
}
