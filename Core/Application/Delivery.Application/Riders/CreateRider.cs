using Delivery.Domain;
using Delivery.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Riders
{
    public class CreateRider : IRequest<IActionResult>
    {
        public RiderModel Model { get; set; }
    }

    public class CreateRiderHandler : IRequestHandler<CreateRider, IActionResult>
    {
        public CreateRiderHandler(BaseDeliveryContext baseContext)
        {
            BaseContext = baseContext;
        }

        public BaseDeliveryContext BaseContext { get; }

        Task<IActionResult> IRequestHandler<CreateRider, IActionResult>.Handle(CreateRider request, CancellationToken cancellationToken)
        {
            var rider = new Rider { Name = request.Model.Name, NumberPlate = request.Model.NumberPlate, RideCount = request.Model.RideCount };
            BaseContext.Riders.Add(rider);
            return Task.FromResult(BaseContext.SaveChanges() > 0 ? new OkObjectResult("Rider saved successfully") as IActionResult
                : new BadRequestObjectResult("Rider cannot be saved") as IActionResult);
        }
    }
}
