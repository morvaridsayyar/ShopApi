namespace ShopApi.Entities;

public class ShoppingCart : BaseEntity
{
    public int UserId { get; set; }
    public int AddressId { get; set; }
    public UserAddress Address { get; set; } = null!;
    public User User { get; set; } = null!;
    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = null!;
}