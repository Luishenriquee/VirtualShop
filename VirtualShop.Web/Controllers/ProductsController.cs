using Microsoft.AspNetCore.Mvc;
using VirtualShop.Web.Models;
using VirtualShop.Web.Services.Contracts;

namespace VirtualShop.Web.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<ActionResult<IEnumerable<ProductViewModel>>> Index()
    {
        var result = await _productService.GetAllProducts();

        if(result is null)
            return View("Error");

        return View(result);
    }
}
