using InvestmentTracker.Core.DataObj;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvestmentTracker.Web.Models
{
    public class SearchResults
    {
        public List<FundData> Funds { get; set; }
        public SearchViewModel Search { get; set; }
    }
}