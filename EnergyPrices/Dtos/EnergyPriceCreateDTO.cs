namespace EnergyPrices.Dtos
{
    public class EnergyPriceCreateDTO
    {
        public string Date { get; set; }

        public string BidArea { get; set; }

        public string Contract { get; set; }

        public string Supplier { get; set; }

        public string PriceOrePerKwh { get; set; }

        public string ContractName { get; set; }
    }
}
