
using Delivery.Application.Riders;
using Delivery.Domain;
using Delivery.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Controllers;

[Route("api/[Controller]")]
public class HomeController : Controller
{
    public IMediator Mediator { get; }

    public HomeController(IMediator mediator)
    {
        Mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? id)
        => await Mediator.Send(new GetRider { Id = id });

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RiderModel model) => await Mediator.Send(new CreateRider { Model = model });
    //{
    //    //var rider = new Rider()
    //    //{
    //    //    Name = model.Name,
    //    //    NumberPlate = model.NumberPlate,
    //    //    RideCount = model.RideCount
    //    //};

    //    //DeliveryContext.Riders.Add(rider);
    //    //int count = DeliveryContext.SaveChanges();
    //    //return Task.FromResult(Ok(count > 0 ? $" {count} saved successfully " : " no data was saved ") as IActionResult);

    //    return await Mediator.Send(new CreateRider { Model = model });
    //}

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] RiderModel model)
    {
        //var rider = DeliveryContext.Riders.Where(r => r.Id == model.Id).FirstOrDefault();
        //if (rider == null)
        //    return Task.FromResult(BadRequest($"Rider cannot be found") as IActionResult);

        //rider.NumberPlate = model.NumberPlate;
        //rider.Name = model.Name;
        //rider.RideCount = model.RideCount;
        //DeliveryContext.SaveChanges();
        //return Task.FromResult(Ok($"Rider with name {model.Name} updated successfully") as IActionResult);
        return await Mediator.Send(new UpdateRider { Model = model });
    }

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        //Opyion 1
        //var rider = DeliveryContext.Riders.Where(r => r.Id == model.Id).FirstOrDefault();
        //if (rider == null)
        //    return Task.FromResult(BadRequest("Rider cannot be found") as IActionResult);

        //DeliveryContext.Riders.Remove(rider);

        //Option 2
        //try
        //{
        //    DeliveryContext.Riders.Remove(new() { Name = default, NumberPlate = default, Id = model.Id });
        //    DeliveryContext.SaveChanges();
        //}
        //catch (Exception ex)
        //{
        //    return Task.FromResult(BadRequest("Rider cannot be found") as IActionResult);
        //}

        //Option 3
        //int count = await DeliveryContext.Riders.Where(r => r.Id == model.Id).ExecuteDeleteAsync();
        //return (count > 0 ?
        //    Ok($"Rider with name {model.Name} deleted successfully") as IActionResult :
        //    BadRequest("Rider cannot Found") as IActionResult);

        //return count > 0 ? Task.FromResult(Ok($"Rider with name {model.Name} deleted successfully") as IActionResult)
        //    : Task.FromResult(BadRequest("Rider cannot Found") as IActionResult);
        return await Mediator.Send(new DeleteRider { Id = id });
    }
}
