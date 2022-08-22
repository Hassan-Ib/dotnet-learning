using BuberBreakfast.Contracts.Breakfast; // for the Breakfast interface
using Microsoft.AspNetCore.Mvc; // for the controller
using BuberBreakfast.Models; // for the Breakfast class
using BuberBreakfast.Services.Breakfasts; // for the IBreakfastService interface
// namespace for scope the classes to BuberBreakfast.Controllers
namespace BuberBreakfast.Controllers;

// create a BreakfastController class that inherits from ControllerBase class -- this class will be responsible for handling all requests to the BreakfastController endpoint.
[ApiController] // this attribute makes the class a controller 
[Route("/breakfasts")] // this attribute defines the endpoint for the controller
public class BreakfastsController : ControllerBase
{

    private readonly IBreakfastService _breakfastService; // create a private readonly IBreakfastService field that will be injected by the constructor

    public BreakfastsController(IBreakfastService breakfastService) // create a constructor that takes an IBreakfastService as a parameter
    {
        _breakfastService = breakfastService; // set the private readonly IBreakfastService field to the parameter
    }

    [HttpGet]

    public IActionResult GetAllBreakfast()
    {
        var breakfasts = _breakfastService.GetAllBreakfast();

       return Ok(breakfasts);
    }

    [HttpPost] // this attribute makes the method a POST request to the BreakfastsController endpoint
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {

        // create a Breakfast object
        var breakfast = new Breakfast(
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.startDateTime,
            request.endDateTime,
            DateTime.UtcNow,
            request.savory,
            request.sweet
        );

        // save object to database
        // create a BreakfastResponse object that will be returned to the client

        _breakfastService.CreateBreakfast(breakfast); // call the CreateBreakfast method on the IBreakfastService interface
        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.startDateTime,
            breakfast.endDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.savory,
            breakfast.sweet
        );
        // return response to client with a 201 status code and location header to query the newly created object 
        return CreatedAtAction(
           actionName:  nameof(GetBreakfast),
           routeValues : new { id = breakfast.Id },
            value : response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
       var breakfast =  _breakfastService.GetBreakfast(id);
       BreakfastResponse response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.startDateTime,
            breakfast.endDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.savory,
            breakfast.sweet
        );
        
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastResquest request)
    {
        var breakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.startDateTime,
            request.endDateTime,
            DateTime.UtcNow,
            request.savory,
            request.sweet
        );


        _breakfastService.UpsertBreakfast(breakfast);

        return NoContent();
    }
    
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        _breakfastService.DeleteBreakfast(id);
        return NoContent();
    }
}