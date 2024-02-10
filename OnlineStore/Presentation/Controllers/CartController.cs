using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[Route("[controller]/[action]")]
public class CartController : Controller
{

    [HttpPost]
    public Task<IActionResult> Add([FromBody] int productId)
    {
        
    }

    [HttpPost]
    public Task<IActionResult> Remove([FromBody] int productId)
    {
        
    }
    
    
}