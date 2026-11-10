using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopApi.Data;
using ShopApi.DTOs.ShoppingCart;
using ShopApi.Entities;
namespace ShopApi.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ShoppingCartController(ApplicationDbContext context)
    : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult> Get()
    {
        int userId = GetUserId();
        var shoppingCart = await context
            .ShoppingCarts
            .Where(s => s.UserId == userId)
            .Select(x => new GetShoppingCartResponse
            {
                Address = new()
                {
                    Id = x.Id,
                    Address = x.Address.Address,
                    City = x.Address.City,
                    Mobile = x.Address.Mobile,
                    PostalCode = x.Address.PostalCode
                },
                Items = x.Items.Select(i => new ShoppingCartItemDto
                {
                    ProductName = i.Product.Name,
                    Quantity = i.Quantity,
                    ProductPrice = i.Product.Price
                }).ToList()
            }).FirstOrDefaultAsync();
        shoppingCart?.TotalQuantity = shoppingCart.Items.Sum(x => x.Quantity);
        return Ok(shoppingCart);
    }
    [HttpPost("Increase")]
    public async Task<ActionResult> Increase(IncreaseShoppingCartItemDto request)
    {
        var cart = await GetCartAsync();
        var item = cart.Items.FirstOrDefault(x => x.ProductId == request.ProductId);
        if (item == null)
        {
            cart.Items.Add(new ShoppingCartItem()
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity
            });
        }
        else
        {
            item.Quantity += request.Quantity;
        }
        await context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("Decrease")]
    public async Task<ActionResult> Decrease(IncreaseShoppingCartItemDto request)
    {
        var cart = await GetCartAsync();
        var item = cart.Items.FirstOrDefault(x => x.ProductId == request.ProductId);
        if (item == null)
        {
            cart.Items.Add(new ShoppingCartItem()
            {
                ProductId = request.ProductId,
                Quantity = request.Quantity
            });
        }
        else
        {
            item.Quantity -= request.Quantity;
        }
        await context.SaveChangesAsync();
        return NoContent();
    }
    private async Task<ShoppingCart> GetCartAsync()
    {
        var userId = GetUserId();
        var shoppingCart = await context
            .ShoppingCarts
            .Include(x => x.Items)
            .FirstOrDefaultAsync(x => x.UserId == userId);
        if (shoppingCart != null)
        {
            return shoppingCart;
        }
        shoppingCart = new ShoppingCart()
        {
            AddressId = null,
            UserId = userId,
            Items = []
        };
        context.ShoppingCarts.Add(shoppingCart);
        await context.SaveChangesAsync();
        return shoppingCart;
    }

    private int GetUserId()
    {
        //Get User Real Id
        return 3;
    }
}