using eticaretsitesi.Data;
using eticaretsitesi.Dto;
using eticaretsitesi.Models;
using eticaretsitesi.Oturum;
using Microsoft.AspNetCore.Mvc;

namespace eticaretsitesi.Controllers
{
    public class CartController : Controller
    {
        private readonly Context _context;

        public CartController(Context context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<CartItem> item = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartViewDto cartvm = new()
            {
                cartItems = item,
                GrandTotal = item.Sum(x => x.Quantity * x.Price),
            };
            return View(cartvm);
        }
        public async Task<IActionResult>Add(int id)
        {
            Product product = _context.Products.Find(id);
            List<CartItem> item = HttpContext.Session.GetJson<List<CartItem>>("Cart") ?? new List<CartItem>();
            CartItem cartItem=item.FirstOrDefault(x=>x.ProductId== id); 
            if (cartItem!=null)
            {
                item.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", item);
            TempData["Success"] = "Sepette Eklendi";

            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult>Remove(int id)
        {
            List<CartItem> cart = HttpContext.Session.GetJson<List<CartItem>>("Cart");
           cart.RemoveAll(x=>x.ProductId== id);    
            if(cart.Count>0)
            { HttpContext.Session.Remove("Cart"); }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }

            TempData["Success"] = "Sepetti Ürünler Silindi";
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Clear() {
            HttpContext.Session.Remove("Cart");
            return RedirectToAction("Index");
         
        }

    }
}
