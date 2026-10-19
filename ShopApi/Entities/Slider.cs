namespace ShopApi.Entities;

public class Slider:BaseEntity
{
    public string ImageUrl { get; set; } = null!;
    public bool IsActive { get; set; }
}
