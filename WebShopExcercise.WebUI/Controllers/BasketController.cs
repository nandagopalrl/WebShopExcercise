using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopExcercise.Services;

namespace WebShopExcercise.WebUI.Controllers
{
    public class BasketController : Controller
    {
        IBasketService basketservice;
        
        public BasketController(IBasketService basketService)
        {
            this.basketservice = basketService;
        }
        // GET: Basket
        public ActionResult Index()
        {
            var model = basketservice.GetBasketItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToBasket(string Id)
        {
            basketservice.AddToBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromBasket(string Id)
        {
            basketservice.RemoveFromBasket(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public PartialViewResult BasketSummary()
        {
            var basketSummary = basketservice.GetBasketSummary(this.HttpContext);

            return PartialView(basketSummary);
        }
    }
}