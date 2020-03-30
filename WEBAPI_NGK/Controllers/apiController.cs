using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WEBAPI_NGK.Controllers
{

    public class apiController : Controller
    {
        private readonly WeatherContext _context;

        public apiController(WeatherContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetTopFive()
        {
            var temp = await _context.weatherinfos.OrderByDescending(w => w.date).Take(5).ToListAsync();
            return Ok(temp);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var temp = await _context.weatherinfos.ToListAsync();
            return Ok(temp);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllByDate(string date)
        {
            var temp = await _context.weatherinfos.Where(w => w.date == date).ToListAsync();
            return Ok(temp);
        }
    }
}