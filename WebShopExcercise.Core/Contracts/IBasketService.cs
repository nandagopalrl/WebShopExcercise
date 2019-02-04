using System.Collections.Generic;
using System.Web;
using WebShopExcercise.Core.ViewModels;
using System.Web;

namespace WebShopExcercise.Services
{
    public interface IBasketService
    {
        void AddToBasket(HttpContextBase httpContext, string productId);
        void ChangeBasketQuantity(HttpContextBase httpContext, string itemId, bool increment);
        List<BasketItemViewModel> GetBasketItems(HttpContextBase httpContext);
        BasketSummaryViewModel GetBasketSummary(HttpContextBase httpContext);
        void RemoveFromBasket(HttpContextBase httpContext, string itemId);
    }
}