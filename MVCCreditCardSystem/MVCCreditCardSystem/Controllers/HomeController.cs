using static DataLibrary.BusinessLogic.CreditCardProcessor;
using static DataLibrary.BusinessLogic.CreditCardProviderProcessor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ViewCreditCards()
        {
            ViewBag.Message = "List of Credit Cards";

            var data = LoadCreditCards();
            List<Models.CreditCardModel> creditCards = new List<Models.CreditCardModel>();

            foreach (var item in data)
            {
                creditCards.Add(new Models.CreditCardModel
                {
                    cardNumber = item.cardNumber,
                    cardCVV = item.cardCVV,
                    cardExpiryDate = item.cardExpiryDate,
                    cardCountry = item.cardCountry

                });
            }

            return View(creditCards);
        }

        public ActionResult CaptureCreditCard()
        {
            ViewBag.Message = "Capture Credit Card";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CaptureCreditCard(Models.CreditCardModel model)
        {
            if (ModelState.IsValid)
            {
                CreateCreditCard(model.cardNumber, model.cardCVV, model.cardExpiryDate, model.cardCountry);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult ViewCreditCardProviders()
        {
            ViewBag.Message = "List of Credit Card Providers";

            var data = LoadCreditCardProviders();
            List<Models.CreditCardProviderModel> creditCardProviders = new List<Models.CreditCardProviderModel>();

            foreach (var item in data)
            {
                creditCardProviders.Add(new Models.CreditCardProviderModel
                {
                    providerName = item.providerName

                });
            }

            return View(creditCardProviders);
        }

        public ActionResult CaptureCreditCardProvider()
        {
            ViewBag.Message = "Capture Credit Card Provider";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CaptureCreditCardProvider(Models.CreditCardProviderModel model)
        {
            if (ModelState.IsValid)
            {
                CreateCreditCardProvider(model.providerName);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult CreditCardProviders()
        {
            ViewBag.Message = "Credit Card Providers";

            return View();
        }
    }
}