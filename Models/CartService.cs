using Microsoft.AspNetCore.Http;
using System.Text.Json;

public class CartService
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private const string CartSessionKey = "Cart";

    public CartService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    private Cart GetCart()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        string cartJson = session.GetString(CartSessionKey);
        if (string.IsNullOrEmpty(cartJson))
            return new Cart();
        return JsonSerializer.Deserialize<Cart>(cartJson);
    }

    private void SaveCart(Cart cart)
    {
        var session = _httpContextAccessor.HttpContext.Session;
        string cartJson = JsonSerializer.Serialize(cart);
        session.SetString(CartSessionKey, cartJson);
    }

    public void AddItem(CartItem item)
    {
        var cart = GetCart();
        var existingItem = cart.Items.FirstOrDefault(i => i.Id == item.Id);
        
        if (existingItem != null)
        {
            existingItem.Quantity += item.Quantity;
        }
        else
        {
            cart.Items.Add(item);
        }
        
        SaveCart(cart);
    }

    public void RemoveItem(int id)
    {
        var cart = GetCart();
        var item = cart.Items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            cart.Items.Remove(item);
            SaveCart(cart);
        }
    }

    public void UpdateQuantity(int id, int quantity)
    {
        var cart = GetCart();
        var item = cart.Items.FirstOrDefault(i => i.Id == id);
        if (item != null)
        {
            item.Quantity = quantity;
            if (quantity <= 0)
                cart.Items.Remove(item);
            SaveCart(cart);
        }
    }

    public Cart GetCurrentCart()
    {
        return GetCart();
    }

    public void ClearCart()
    {
        _httpContextAccessor.HttpContext.Session.Remove(CartSessionKey);
    }
}