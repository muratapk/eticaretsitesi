using eticaretsitesi.Models;

namespace eticaretsitesi.Dto
{
    public class CartViewDto
    {
        public List<CartItem> cartItems { get; set; }
        public decimal GrandTotal { get; set; }

    }
}
