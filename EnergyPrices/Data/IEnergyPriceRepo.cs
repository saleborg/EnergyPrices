using EnergyPrices.Models;
using System.Collections.Generic;

namespace EnergyPrices.Data
{
    public interface IEnergyPriceRepo
    {
        bool SaveChange();
        IEnumerable<EnergyPrice> GetAllEnergyPrices();
        EnergyPrice GetEnergyPriceById(int id);
        void CreateEnergyPrice(EnergyPrice plat);
    }
}
