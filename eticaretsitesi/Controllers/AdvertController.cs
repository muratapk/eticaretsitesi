using eticaretsitesi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using eticaretsitesi.Models;
using Microsoft.AspNetCore.Http;
namespace eticaretsitesi.Controllers
{
    public class AdvertController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        private readonly Context _context;
        //database tanımladım
        public AdvertController(Context context,IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
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
        public async Task<IActionResult> Create(Advert gelen,IFormFile Picture )
        {
            if(Picture.Name!=null)
            {
                //gönderilen resim ismi boş değilse

                string wwwRootPath = _hostEnvironment.WebRootPath;
                //varsayilan kök dizini al
                string fileName = Path.GetFileNameWithoutExtension(Picture.FileName);
                //gelen dosyanın  ismini al
                string extension = Path.GetExtension(Picture.FileName);
                //gelen dosyanın uzantısı .jpg png gif pdf 
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Reklam_Image/", fileName);
                //Path.Combine ile kök dizin yolunu ile bizim belirtiğimiz yolu birleştir
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    //hosting kısmın yukarı belirtiğimiz yol üzerinden kayıt dosyası
                    await Picture.CopyToAsync(fileStream);
                    //resimi varsayılan klasöre kopyala
                    gelen.AdvertPicture = fileName;
                }
            }

            if(ModelState.IsValid)
            {
                _context.Adverts.Add(gelen);
                //Add Komut ile Ekleme yapıyoruz
                _context.SaveChanges();
                TempData["Mesaj"] = "Yeni Kayıt Yapıldı";
                //SaveChanges veritabanı ekliyoruz.
                return RedirectToAction("Index");
            }
            return View();
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
        public async Task<IActionResult> Edit(Advert gelen,IFormFile Picture)
        {

            if (Picture!= null)
            {
                //gönderilen resim ismi boş değilse

                string wwwRootPath = _hostEnvironment.WebRootPath;
                //varsayilan kök dizini al
                string fileName = Path.GetFileNameWithoutExtension(Picture.FileName);
                //gelen dosyanın  ismini al
                string extension = Path.GetExtension(Picture.FileName);
                //gelen dosyanın uzantısı .jpg png gif pdf 
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Reklam_Image/", fileName);
                //Path.Combine ile kök dizin yolunu ile bizim belirtiğimiz yolu birleştir
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    //hosting kısmın yukarı belirtiğimiz yol üzerinden kayıt dosyası
                    await Picture.CopyToAsync(fileStream);
                    //resimi varsayılan klasöre kopyala
                    gelen.AdvertPicture = fileName;
                }
            }
           

           
                if (gelen == null)
                {
                    return NotFound();
                }
                _context.Adverts.Update(gelen);
                _context.SaveChanges();
                TempData["Mesaj"] = "Kayıt  Güncellendi";
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
        [HttpPost]
        public IActionResult Delete(Advert gelen)
        {
            if (gelen == null)
            {
                return NotFound();
            }
            _context.Adverts.Remove(gelen);
            _context.SaveChanges();
            TempData["Mesaj"] = "Kayıt Silindi";
            return RedirectToAction("Index");

        }
    }
}
