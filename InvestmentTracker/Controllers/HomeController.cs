using InvestmentTracker.Core.DataObj;
using InvestmentTracker.Core.Entities;
using InvestmentTracker.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InvestmentTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            MutualFundService service = new MutualFundService();
            List<FundInfo> funds = await service.GetAllFunds();
            return View(funds);
        }
    }
}