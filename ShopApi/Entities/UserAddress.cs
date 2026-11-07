using ShopApi.Entities;

namespace ShopApi.Entities;

public class UserAddress : BaseEntity
{
    public int UserId { get; set; }
    //ToDo: Add CityId Fk - Create City Entity
    public string City { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string Mobile { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public bool IsDefault { get; set; }
    public User User { get; set; } = null!;
    public List<ShoppingCart> ShoppingCarts { get; set; } = null!;
}