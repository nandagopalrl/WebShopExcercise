using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;
using WebShopExcercise.Core.Models;

namespace WebShopExcercise.DataAccess.InMemory
{
    public class ProductCategoryRepository
    {
        ObjectCache cache = MemoryCache.Default;
        List<ProductCategory> productCategories;

        public ProductCategoryRepository()
        {
            this.productCategories = cache["productCategories"] as List<ProductCategory>;

            if (productCategories == null)
            {
                productCategories = new List<ProductCategory>();
            }
        }

        public void Commit()
        {
            cache["productCategories"] = productCategories;
        }

        public void Insert(ProductCategory p)
        {
            productCategories.Add(p);
        }

        public void Update(ProductCategory ProductCategory)
        {
            ProductCategory update = productCategories.Find(p => p.Id == ProductCategory.Id);

            if (update != null)
            {
                update = ProductCategory;
            }
            else
            {
                throw new Exception("ProductCategory not found");
            }
        }

        public ProductCategory Find(string id)
        {
            ProductCategory searched = productCategories.Find(p => p.Id == id);

            if (searched != null)
            {
                return searched;
            }
            else
            {
                throw new Exception("ProductCategory not found");
            }
        }

        public IQueryable<ProductCategory> Collection()
        {
            return productCategories.AsQueryable();
        }

        public void Delete(ProductCategory ProductCategory)
        {
            ProductCategory delete = productCategories.Find(p => p.Id == ProductCategory.Id);

            if (delete != null)
            {
                productCategories.Remove(delete);
            }
            else
            {
                throw new Exception("ProductCategory not found");
            }
        }
    }
}
