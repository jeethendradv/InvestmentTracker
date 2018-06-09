using System;

namespace InvestmentTracker.Core.Entities
{
    public class CurrencyPrice
    {
        public int Id { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public decimal Price { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
