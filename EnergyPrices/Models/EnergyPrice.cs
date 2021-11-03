using System.ComponentModel.DataAnnotations;

namespace EnergyPrices.Models
{
    public class EnergyPrice
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Date { get; set; }
        [Required]
        public string BidArea { get; set; }
        [Required]
        public string Contract { get; set; }
        [Required]
        public string Supplier { get; set; }
        [Required]
        public string PriceOrePerKwh { get; set; }
    }
}
