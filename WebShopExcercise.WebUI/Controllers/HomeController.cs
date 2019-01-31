using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopExcercise.Core.Contracts;
using WebShopExcercise.Core.Models;
using WebShopExcercise.Core.ViewModels;

namespace WebShopExcercise.WebUI.Controllers
{
    public class HomeController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategoryRepository;

        public HomeController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext) // these are injected by the dependency injection class. check Unity.config
        {
            context = productContext;
            productCategoryRepository = productCategoryContext;

        }
        public ActionResult Index(string category = null)
        {
            List<Product> products;
            List<ProductCategory> productCategories = productCategoryRepository.Collection().ToList();
                    
            if(category == null)
            {
                products = context.Collection().ToList();
            }
            else
            {
                products = context.Collection().Where(p=>p.Category == category).ToList();
            }

            ProductListViewModel viewmodel = new ProductListViewModel();

            viewmodel.products = products;
            viewmodel.ProductCategories = productCategories;
            return View(viewmodel);
        }

        public ActionResult Details(string id)
        {
            Product product = context.Find(id);

            if(product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
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
    }
}