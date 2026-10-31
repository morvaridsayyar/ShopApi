using ShopApi.Entities;

namespace ShopApi.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}