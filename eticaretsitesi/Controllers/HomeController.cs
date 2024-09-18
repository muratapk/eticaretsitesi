using eticaretsitesi.Data;
using eticaretsitesi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace eticaretsitesi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;
        public HomeController(ILogger<HomeController> logger,Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Details(int ?id)
        {
            var result = _context.Products.Find(id);
            return View(result);
        }
        public IActionResult AllCategories()
        {
            ViewBag.CategoryList=_context.Categories.ToList();
            //kategori modelini groupjoin birleþtir product tablosu category tablosun category Id product tablosundaki categoryId eþitle
            //category göre bunu groupla bunda productGroup ismi ver new yeni bir kolon türleri oluþtur burdan gelen verileri
            //oluþturulan kolonlara ata

            ViewBag.CategoryCount = _context.Categories.GroupJoin(_context.Products, category => category.CategoryId, product => product.CategoryId, (category, productGroup) => new { categoryName = category.CategoryName, productCount = productGroup.Count()}).ToList();

            //groupjoin ifadesi 
            ViewBag.LastProduct = _context.Products.OrderByDescending(p => p.CategoryId).Take(3).ToList();
            var result=_context.Products.OrderByDescending(p=>p.ProductId).ToList();
            return View(result);
        }

        [HttpGet]
        public JsonResult ArtanAzalan(string Veri)
        {
            
            if(Veri=="Artan")
            {
              var result = _context.Products.OrderByDescending(p => p.ProductPrice).ToList();
                return Json(result);
            }
            else
            {
               var result = _context.Products.OrderByDescending(p => p.ProductPrice).ToList();
                return Json(result);
            }

            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
