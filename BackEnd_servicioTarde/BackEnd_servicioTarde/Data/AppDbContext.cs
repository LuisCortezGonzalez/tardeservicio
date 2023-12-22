using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
namespace BackEnd_servicioTarde.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {
        }

        public DbSet<WeatherForecast> weatherForecasts { get; set; } = default!;
    }
}
