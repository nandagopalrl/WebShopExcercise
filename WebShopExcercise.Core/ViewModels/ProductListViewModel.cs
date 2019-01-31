using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebShopExcercise.Core.Models;

namespace WebShopExcercise.Core.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<ProductCategory> ProductCategories { get; set; }
    }
}
