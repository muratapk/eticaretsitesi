namespace eticaretsitesi.Models
{
    public class CartItem
    {
        public long ProductId {  get; set; }    
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }      
        public string Image { get; set; }
        public decimal Total { get {  return Price*Quantity; } }
        //bu properites veri atamıyoru Quantity*Price çarparak geri alıyoruz
        public CartItem() { }   
        public CartItem(Product product)
        {
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            Quantity = 1;
            Image = product.ProductPicture;
            Price =Convert.ToDecimal(product.ProductPrice);
        }
    }
}
