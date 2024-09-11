using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eticaretsitesi.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Display(Name ="Ürün Adı")]
        public string ProductName { get; set; } = string.Empty;
        [Display(Name = "Ürün Kategorisi")]

        //foreignkey
        public int ? CategoryId { get; set; }
       
        virtual public Category ? Category { get; set; }
        [Display(Name = "Ürün Açıklaması")]
        public string ProductDescription { get; set; } = string.Empty;
        [Display(Name = "Ürün Özellikleri")]
        public string ProuctFeature { get; set; } = string.Empty;
        [Display(Name = "Ürün Resimleri")]
        public string ProductPicture { get; set; } = string.Empty;
        [Display(Name = "Ürün Fiyatı")]
        public int ? ProductPrice { get; set; }
        [Display(Name = "Ürün Stok")]
        public int ? ProductStock { get; set; }
        [NotMapped]
        public IFormFile? ProductImage { get; set; }
        virtual public List<Comment> Comment { get; set; }
    }
}
