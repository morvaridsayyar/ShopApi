namespace ShopApi.Entities;

public class ProductComment : BaseEntity
{
    public int UserId { get; set; }
    public int ProductId { get; set; }
    public string Body { get; set; } = null!;

    public User User { get; set; } = null!;
    public Product Product { get; set; } = null!;
}