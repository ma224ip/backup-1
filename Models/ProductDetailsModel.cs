using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class ProductDetailsModel : PageModel
{
    private readonly CartService _cartService;

    public ProductDetailsModel(CartService cartService)
    {
        _cartService = cartService;
    }

    public IActionResult OnPostAddToCart(int id, string name, decimal price, string imageUrl)
    {
        var item = new CartItem
        {
            Id = id,
            Name = name,
            Price = price,
            Quantity = 1,
            ImageUrl = imageUrl
        };
        
        _cartService.AddItem(item);
        return RedirectToPage("/Cart");
    }
}