using Microsoft.AspNetCore.Mvc; // for the controller
namespace BuberBreakfast.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}
