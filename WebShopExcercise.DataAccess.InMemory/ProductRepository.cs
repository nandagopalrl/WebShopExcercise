using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using WebShopExcercise.Core.Models;

namespace WebShopExcercise.DataAccess.InMemory
{
    public class ProductRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<Product> products;

        public ProductRepository()
        {
            this.products = cache["products"] as List<Product>;

            if(products == null)
            {
                products = new List<Product>();
            }
        }

        public void Commit()
        {
            cache["products"] = products;
        }

        public void Insert(Product p)
        {
            products.Add(p);
        }

        public void Update(Product product)
        {
            Product update = products.Find(p => p.Id == product.Id);

            if(update != null)
            {
                update = product;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public Product Find(string id)
        {
            Product searched = products.Find(p => p.Id == id);

            if (searched != null)
            {
                return searched;
            }
            else
            {
                throw new Exception("Product not found");
            }
        }

        public IQueryable<Product> Collection()
        {
            return products.AsQueryable();
        }

        public void Delete(Product product)
        {
            Product delete = products.Find(p => p.Id == product.Id);

            if (delete != null)
            {
                products.Remove(delete);
            }
            else
            {
                throw new Exception("Product not found");
            }
        }
    }
}
