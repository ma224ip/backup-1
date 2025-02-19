public class Cart
{
    public List<CartItem> Items { get; set; } = new List<CartItem>();
    
    public decimal Total => Items.Sum(item => item.Price * item.Quantity);
    
    public int TotalItems => Items.Sum(item => item.Quantity);
}