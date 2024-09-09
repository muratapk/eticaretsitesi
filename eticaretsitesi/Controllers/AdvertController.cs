using eticaretsitesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eticaretsitesi.Models;
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

        [HttpGet]
        //linkle gelen veriler HttpGet methodu ile yakalanır
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Advert gelen )
        {
            _context.Adverts.Add(gelen);
            //Add Komut ile Ekleme yapıyoruz
            _context.SaveChanges();
            //SaveChanges veritabanı ekliyoruz.
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int ? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var result = _context.Adverts.Find(id);
            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(Advert gelen)
        {
           if(gelen == null)
            {
                return NotFound();
            }
            _context.Adverts.Update(gelen);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = _context.Adverts.Find(id);
            return View(result);
        }
    }
}
