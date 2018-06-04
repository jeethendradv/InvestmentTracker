using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentTracker.Web.Models
{
    public class AddFundViewModel
    {
        public int SchemeCode { get; set; }
        public string SchemeName { get; set; }
        public DateTime NavPurchaseDate { get; set; }
        public int NavsPurchased { get; set; }
        public decimal AmountInvested { get; set; }
    }
}