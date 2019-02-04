using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShopExcercise.Core.Models
{
    public class Basket : BaseEntity
    {
        public virtual ICollection<BasketItem> BasketItems { get; set; } //virtual for lazy loading in EF

        public Basket()
        {
            this.BasketItems = new List<BasketItem>();
        }
    }
}
