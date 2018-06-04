using InvestmentTracker.Core;
using InvestmentTracker.Core.DataObj;
using InvestmentTracker.Core.Entities;
using InvestmentTracker.Core.Service;
using InvestmentTracker.Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InvestmentTracker.Web.Controllers
{
    public class MutualFundController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Search(SearchViewModel model)
        {
            MutualFundProxy proxy = new MutualFundProxy();
            List<FundData> results = await proxy.Search(model.Text);
            SearchResults viewModel = new SearchResults
            {
                Funds = results,
                Search = model
            };
            return View(viewModel);
        }

        public ActionResult Add(string schemecode, string schemename)
        {
            FundPurchased fund = new FundPurchased
            {
                Name = schemename,
                SchemeCode = schemecode
            };
            return View(fund);
        }
        
        [HttpPost]
        public async Task<ActionResult> Add(FundPurchased fund)
        {
            MutualFundService service = new MutualFundService();
            await service.Add(fund);
            return RedirectToAction("Index", "Home");
        }
    }
}