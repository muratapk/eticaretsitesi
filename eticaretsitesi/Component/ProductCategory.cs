using eticaretsitesi.Data;
using Microsoft.AspNetCore.Mvc;

namespace eticaretsitesi.Component
{
    public class ProductCategory: ViewComponent
    {
        private readonly Context _context;

        public ProductCategory(Context context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var result = _context.Products.OrderByDescending(p => p.ProductId).Take(8).ToList();
            /* order by Asc kb Desc Bk*/
            /*Tüm Listeyi Ekrana getir*/
            return View(result);
            /*elde ettiğim verileri View Gönder*/
        }
    }
}
