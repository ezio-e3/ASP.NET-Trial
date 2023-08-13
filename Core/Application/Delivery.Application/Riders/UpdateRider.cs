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
    public class UpdateRider : IRequest<IActionResult>
    {
        public RiderModel Model { get; set; }
    }
    public class UpdateRiderHandler : IRequestHandler<UpdateRider, IActionResult>
    {
        public UpdateRiderHandler(DeliveryContext deliveryContext)
        {
            DeliveryContext = deliveryContext;
        }

        public DeliveryContext DeliveryContext { get; }

        Task<IActionResult> IRequestHandler<UpdateRider, IActionResult>.Handle(UpdateRider request, CancellationToken cancellationToken)
        {
            var rider = DeliveryContext.Riders.Where(r => r.Id == request.Model.Id).FirstOrDefault();
            if (rider != null)
                return Task.FromResult(new BadRequestObjectResult($"Rider cannot be Found") as IActionResult);
            rider.Name = request.Model.Name;
            rider.NumberPlate = request.Model.NumberPlate;
            rider.RideCount = request.Model.RideCount;
            DeliveryContext.SaveChanges();
            return Task.FromResult(new OkObjectResult($"Rider with name {rider.Name} updated") as IActionResult);
        }
    }
}
