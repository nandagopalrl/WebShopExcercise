using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebShopExcercise.Core.Contracts;
using WebShopExcercise.Core.Models;
using WebShopExcercise.Core.ViewModels;


namespace WebShopExcercise.WebUI.Controllers
{
    public class ProductManagerController : Controller
    {
        IRepository<Product> context;
        IRepository<ProductCategory> productCategoryRepository;

        public ProductManagerController(IRepository<Product> productContext, IRepository<ProductCategory> productCategoryContext) // these are injected by the dependency injection class. check Unity.config
        {
            context = productContext;
            productCategoryRepository = productCategoryContext;

        }

        // GET: ProductManager
        public ActionResult Index()
        {
            List<Product> products = context.Collection().ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ProductManagerViewModel viewModel = new ProductManagerViewModel();
            viewModel.product = new Product();
            viewModel.ProductCategories = productCategoryRepository.Collection();
            return View(viewModel);
        }

        [HttpPost]  //https://www.aurigma.com/upload-suite/developers/aspnet-mvc/how-to-upload-files-in-aspnet-mvc  : further reading
        public ActionResult Create(Product product, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            else
            {
                //if(file != null)
                //{
                //    product.Image = product.Id + Path.GetExtension(file.FileName);
                //    file.SaveAs(Server.MapPath("//Content//ProductImages") + product.Image); 
                //}
                if (HttpContext.Request.Files.AllKeys.Any())
                {
                    // Get the uploaded image from the Files collection
                    var httpPostedFile = HttpContext.Request.Files[0];

                    if (httpPostedFile != null)
                    {
                        // Validate the uploaded image(optional)

                        // Get the complete file path
                        product.Image = product.Id + Path.GetExtension(file.FileName);

                        // Save the uploaded file to "UploadedFiles" folder
                        httpPostedFile.SaveAs(Server.MapPath("//Content//ProductImages//") + product.Image);
                    }
                }

                context.Insert(product);
                context.Commit();

                return RedirectToAction("Index");
            }
        }

        public ActionResult Edit(string Id)
        {
            Product product = context.Find(Id);

            if(product == null)
            {
                return HttpNotFound();
            }
            else
            {
                ProductManagerViewModel viewModel = new ProductManagerViewModel();
                viewModel.product = product;
                viewModel.ProductCategories = productCategoryRepository.Collection();
                return View(viewModel);
            }
        }

        [HttpPost]
        public ActionResult Edit(Product product, string Id, HttpPostedFileBase file)
        {
            Product productToEdit = context.Find(Id);

            if (productToEdit == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(product);
                }
                else
                {
                    //if (file != null)
                    //{
                    //    product.Image = product.Id + Path.GetExtension(file.FileName);
                    //    file.SaveAs(Server.MapPath("//Content//ProductImages") + product.Image);
                    //}
                    if (HttpContext.Request.Files.AllKeys.Any())
                    {
                        // Get the uploaded image from the Files collection
                        var httpPostedFile = HttpContext.Request.Files[0];

                        if (httpPostedFile != null)
                        {
                            // Validate the uploaded image(optional)

                            // Get the complete file path
                            productToEdit.Image = product.Id + Path.GetExtension(file.FileName);

                            // Save the uploaded file to "UploadedFiles" folder
                            httpPostedFile.SaveAs(Server.MapPath("//Content//ProductImages//") + productToEdit.Image);
                        }
                    }

                    productToEdit.Category = product.Category;
                    productToEdit.Description = product.Description;
                    productToEdit.Name = product.Name;
                    productToEdit.Price = product.Price;

                    context.Commit();

                    return RedirectToAction("Index");
                }
            }
        }

        public ActionResult Delete(string Id)
        {
            Product product = context.Find(Id);

            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View(product);
            }
        }

        [HttpPost]
        [ActionName("Delete")]        
        public ActionResult ConfirmDelete(string Id)
        {
            Product productToDelete = context.Find(Id);

            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Delete(productToDelete);
                context.Commit();

                return RedirectToAction("Index");
            }
        }
    }
}