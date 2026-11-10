namespace ShopApi.DTOs.ShoppingCart;

public class GetShoppingCartResponse
{
    public long TotalPrice => Items.Sum(x => x.ProductPrice);
    public int TotalQuantity { get; set; }
    public UserAddressDto Address { get; set; } = null!;
    public List<ShoppingCartItemDto> Items { get; set; } = [];
}
public class UserAddressDto
{
    public int Id { get; set; }
    public string City { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Mobile { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
}
public class ShoppingCartItemDto
{
    public string ProductName { get; set; } = null!;
    public long ProductPrice { get; set; }
    public int Quantity { get; set; }
}