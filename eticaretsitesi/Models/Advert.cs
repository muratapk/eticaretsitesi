using System.ComponentModel.DataAnnotations;

namespace eticaretsitesi.Models
{
    public class Advert
    {
        [Key]
        public int AdvertId { get;set; }
        [Display(Name ="Reklam Adı")]
        [Required(ErrorMessage ="Reklam Adını Boş Bırakmazsınız")]
        [StringLength(30)]
        public string AdvertName { get; set; } = string.Empty;
        [Display(Name ="Reklam Resmi")]
        [Required(ErrorMessage ="Reklam Resmi Zorunludur")]
        public string AdvertPicture { get; set; } = string.Empty;
        public string AdvertLocation { get; set; } = string.Empty;

    }
}
