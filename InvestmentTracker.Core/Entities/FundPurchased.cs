using System;
using System.ComponentModel.DataAnnotations;

namespace InvestmentTracker.Core.Entities
{
    public class FundPurchased
    {
        public int Id { get; set; }

        [Display(Name ="Scheme Code")]
        public string SchemeCode { get; set; }

        [Display(Name ="Fund Name")]
        public string Name { get; set; }
                
        public decimal NavPurchasePrice { get; set; }

        [Display(Name="Purchase Date")]
        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }

        [Display(Name="Navs Purchased")]
        public decimal? NavsPurchased { get; set; }

        [Display(Name="Amount Invested")]
        public decimal? AmountInvested { get; set; }

        [Display(Name="Is Reinvested amount")]
        public bool? IsReinvestedAmount { get; set; }
    }
}
