using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI_NGK.DataLayer.Models;

namespace WEBAPI_NGK
{
    public class WeatherContext : IdentityDbContext
    {
        public DbSet<Weatherinfo> weatherinfos { get; set; }
        public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
        {

        }
    }
}