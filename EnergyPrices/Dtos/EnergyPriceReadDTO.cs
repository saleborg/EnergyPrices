using System.ComponentModel.DataAnnotations;

namespace EnergyPrices.Dtos
{
    public class EnergyPriceReadDTO
    {


        public int Id { get; set; }

        public string Date { get; set; }

        public string BidArea { get; set; }

        public string Contract { get; set; }

        public string Supplier { get; set; }
        
        public string PriceOrePerKwh { get; set; }

    }
}
