using Delivery.Domain;
using Delivery.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Riders
{
    public class GetRider : IRequest<IActionResult>
    {
        public int? Id { get; set; }
    }

    public class GetRiderHandler : IRequestHandler<GetRider, IActionResult>
    {
        public GetRiderHandler(BaseDeliveryContext deliveryContext)
        {
            Context = deliveryContext;
        }

        public BaseDeliveryContext Context { get; }

        Task<IActionResult> IRequestHandler<GetRider, IActionResult>.Handle(GetRider request, CancellationToken cancellationToken)
        {
            if (request.Id == null)
            {
                var riders = Context.Riders.ToList();
                return Task.FromResult(new OkObjectResult(riders) as IActionResult);
            }

            var rider = Context.Riders.Where(r => r.Id == request.Id).FirstOrDefault();
            return Task.FromResult(rider == null ? new BadRequestResult() as IActionResult :
                new OkObjectResult(rider) as IActionResult);
        }
    }
}
