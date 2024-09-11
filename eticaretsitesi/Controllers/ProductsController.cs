using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eticaretsitesi.Data;
using eticaretsitesi.Models;
using Microsoft.Extensions.Hosting;

namespace eticaretsitesi.Controllers
{
    public class ProductsController : Controller
    {
        private readonly Context _context;
        private readonly IWebHostEnvironment _hostEnvironment;
        //hosting alakalı bilgisi buradan alıyoruz.
        public ProductsController(Context context, IWebHostEnvironment hostenvoriment)
        {
            _context = context;
            _hostEnvironment = hostenvoriment;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.Include("Category").ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewBag.Category = new SelectList(_context.Categories, "CategoryId", "CategoryName");

            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,CategoryId,ProductDescription,ProuctFeature,ProductPicture,ProductPrice,ProductStock")] Product product,IFormFile ProductImage)
        {
            if(ProductImage!=null)
            {
                //gönderilen resim ismi boş değilse

                string wwwRootPath = _hostEnvironment.WebRootPath;
                //varsayilan kök dizini al
                string fileName = Path.GetFileNameWithoutExtension(ProductImage.FileName);
                //gelen dosyanın  ismini al
                string extension = Path.GetExtension(ProductImage.FileName);
                //gelen dosyanın uzantısı .jpg png gif pdf 
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Product_Image/", fileName);
                //Path.Combine ile kök dizin yolunu ile bizim belirtiğimiz yolu birleştir
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    //hosting kısmın yukarı belirtiğimiz yol üzerinden kayıt dosyası
                    await ProductImage.CopyToAsync(fileStream);
                    //resimi varsayılan klasöre kopyala
                    product.ProductPicture = fileName;
                }
            }

           if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Category = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewBag.Category = new SelectList(_context.Categories, "CategoryId", "CategoryName");

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,CategoryId,ProductDescription,ProuctFeature,ProductPicture,ProductPrice,ProductStock")] Product product,IFormFile ProductImage)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }


            if (ProductImage != null)
            {
                //gönderilen resim ismi boş değilse

                string wwwRootPath = _hostEnvironment.WebRootPath;
                //varsayilan kök dizini al
                string fileName = Path.GetFileNameWithoutExtension(ProductImage.FileName);
                //gelen dosyanın  ismini al
                string extension = Path.GetExtension(ProductImage.FileName);
                //gelen dosyanın uzantısı .jpg png gif pdf 
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/Product_Image/", fileName);
                //Path.Combine ile kök dizin yolunu ile bizim belirtiğimiz yolu birleştir
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    //hosting kısmın yukarı belirtiğimiz yol üzerinden kayıt dosyası
                    await ProductImage.CopyToAsync(fileStream);
                    //resimi varsayılan klasöre kopyala
                    product.ProductPicture = fileName;
                }
            }



            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Category = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
