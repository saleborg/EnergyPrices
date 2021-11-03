using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EnergyPrices.Models;

namespace EnergyPrices.Data
{
    public class EnergyPricesContext : DbContext
    {
        public EnergyPricesContext (DbContextOptions<EnergyPricesContext> options)
            : base(options)
        {
        }

        public DbSet<EnergyPrices.Models.EnergyPrice> EnergyPrice { get; set; }
    }
}
