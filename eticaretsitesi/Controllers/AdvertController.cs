using eticaretsitesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eticaretsitesi.Controllers
{
    public class AdvertController : Controller
    {
        private readonly Context _context;
        //database tanımladım
        public AdvertController(Context context)
        {
            _context = context;
        }
        //control nesnesi çağırıldığında otomatik yüklenmesini istiyorum
        public async Task<IActionResult> Index()
        {
            var result = await _context.Adverts.ToListAsync();
            //liste olarak veriyi gönderiyorum.
            return View(result);
        }
    }
}
