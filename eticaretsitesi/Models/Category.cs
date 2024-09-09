using System.ComponentModel.DataAnnotations;

namespace eticaretsitesi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Kategori Adını Boş Geçemezsiniz")]

        [Display(Name ="Kategori Adı:")]
        public string CategoryName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Resim Yükleneniz Lazım")]

        [Display(Name ="Kategori Resim:")]
        public string CategoryPicture { get; set; } = string.Empty;
    }
}
