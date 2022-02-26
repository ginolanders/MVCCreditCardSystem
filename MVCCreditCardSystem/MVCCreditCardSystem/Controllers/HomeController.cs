using static DataLibrary.BusinessLogic.CreditCardProcessor;
using static DataLibrary.BusinessLogic.CreditCardProviderProcessor;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MVCCreditCardSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "The main function of the application is to capture valid credit card numbers.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //VIEW - Credit Cards
        public ActionResult ViewCreditCards()
        {
            ViewBag.Message = "Credit Card List";

            var data = LoadCreditCards();
            List<Models.CreditCardModel> creditCards = 
                (from item in data select new Models.CreditCardModel
                {
                    CardNumber = item.CardNumber,
                    CardCVV = item.CardCVV,
                    CardExpiryDate = item.CardExpiryDate,
                    CardCountry = item.CardCountry 
                }).ToList();

            return View(creditCards);
        }

        public ActionResult CaptureCreditCard()
        {
            ViewBag.Message = "Submit Credit Card";

            return View();
        }

        //CREATE - Credit Card
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CaptureCreditCard(Models.CreditCardModel model)
        {
            //Check if all information is present before creating the record
            if (ModelState.IsValid)
            {
                CreateCreditCard(model.CardNumber, model.CardCVV, model.CardExpiryDate, model.CardCountry);
                return RedirectToAction("Index");
            }

            return View();
        }

        //VIEW - Credit Card Providers
        public ActionResult ViewCreditCardProviders()
        {
            ViewBag.Message = "Credit Card Provider List";

            var data = LoadCreditCardProviders();
            List<Models.CreditCardProviderModel> creditCardProviders = 
                (from item in data select new Models.CreditCardProviderModel
                {
                    ProviderName = item.ProviderName
                }).ToList();

            return View(creditCardProviders);
        }

        public ActionResult CreditCardProviders()
        {
            ViewBag.Message = "Credit Card Providers";

            return View();
        }
    }
}