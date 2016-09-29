using Braintree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BraintreeTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "s54xg73t7vkm6pv5",
                PublicKey = "wn4tzyhgs3tbk87s",
                PrivateKey = "88195c37e7a827e84b6302cbe8ad96c6"
            };

            var clientToken = gateway.ClientToken.generate();

            ViewBag.clientToken = clientToken;

            return View();
        }

        [HttpPost]
        public ActionResult CreatePurchase(FormCollection collection)
        {
            string nonce = collection["payment_method_nonce"];

            var gateway = new BraintreeGateway
            {
                Environment = Braintree.Environment.SANDBOX,
                MerchantId = "s54xg73t7vkm6pv5",
                PublicKey = "wn4tzyhgs3tbk87s",
                PrivateKey = "88195c37e7a827e84b6302cbe8ad96c6"
            };            

            TransactionRequest request = new TransactionRequest
            {
                Amount = 15.0M,
                PaymentMethodNonce = nonce,
                Options = new TransactionOptionsRequest
                {
                    SubmitForSettlement = true
                }
            };

            Result<Transaction> result = gateway.Transaction.Sale(request);

            if (result.IsSuccess())
            {
                //System.Console.WriteLine("Transaction ID: " + transaction.Id);
                return Content("Success");
            }
            else
            {
                return Content(result.Message);                
            }            
        }
    }
}
