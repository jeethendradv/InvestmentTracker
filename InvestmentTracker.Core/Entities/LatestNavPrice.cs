using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvestmentTracker.Core.Entities
{
    public class LatestNavPrice
    {
        public int Id { get; set; }
        public string SchemeCode { get; set; }
        public decimal NavPrice { get; set; }
        public DateTime Date { get; set; }
        public DateTime LastFetch { get; set; }
    }
}
