using ShopApi.Entities;

namespace ShopApi.Entities;

public class ShoppingCartItem : BaseEntity
{
    public int ShoppingCartId { get; set; }
    public int Quantity { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; } = null!;
    public ShoppingCart ShoppingCart { get; set; } = null!;
}