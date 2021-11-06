using EnergyPrices.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyPrices.Data
{
    public class EnergyPriceRepo : IEnergyPriceRepo
    {
        private EnergyPricesContext _context;

        public EnergyPriceRepo(EnergyPricesContext context)
        {
            _context = context;
        }

        public void CreateEnergyPrice(EnergyPrice plat)
        {
            if (plat == null)
            {
                throw new ArgumentNullException(nameof(plat));
            }
            _context.EnergyPrice.Add(plat);
        }

        public IEnumerable<EnergyPrice> GetAllEnergyPrices()
        {
            return _context.EnergyPrice.ToList();
        }

        public EnergyPrice GetEnergyPriceById(int id)
        {
            return _context.EnergyPrice.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChange()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
