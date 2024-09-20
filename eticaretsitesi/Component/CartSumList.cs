using eticaretsitesi.Data;
using eticaretsitesi.Models;
using Microsoft.AspNetCore.Mvc;
using eticaretsitesi.Oturum;
using eticaretsitesi.Dto;
namespace eticaretsitesi.Component
{
    public class CartSumList:ViewComponent
    {
        private readonly Context _context;

        public CartSumList(Context context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewDto cartVm = new()
            {
                cartItems = cart,
                GrandTotal = cart.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVm);
        }
    }
}
