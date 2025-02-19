using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CartModel : PageModel
{
    private readonly CartService _cartService;

    public CartModel(CartService cartService)
    {
        _cartService = cartService;
    }

    public Cart Cart { get; set; }

    public void OnGet()
    {
        Cart = _cartService.GetCurrentCart();
    }

    public IActionResult OnPostUpdateQuantity(int id, int quantity)
    {
        _cartService.UpdateQuantity(id, quantity);
        return RedirectToPage();
    }

    public IActionResult OnPostRemove(int id)
    {
        _cartService.RemoveItem(id);
        return RedirectToPage();
    }
}