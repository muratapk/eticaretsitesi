namespace eticaretsitesi.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string CommentText { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public int ProductId { get; set; }
        virtual public Product? Product { get; set; }
        
    }
}
