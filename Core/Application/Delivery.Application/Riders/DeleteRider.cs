using Delivery.Domain;
using Delivery.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Application.Riders
{
    public class DeleteRider : IRequest<IActionResult>
    {
        public int Id { get; set; }
    }
    public class DeleteRiderHandler : IRequestHandler<DeleteRider, IActionResult>
    {
        public DeleteRiderHandler(DeliveryContext deliveryContext)
        {
            DeliveryContext = deliveryContext;
        }

        public DeliveryContext DeliveryContext { get; }

        async Task<IActionResult> IRequestHandler<DeleteRider, IActionResult>.Handle(DeleteRider request, CancellationToken cancellationToken)
        {
            int count = await DeliveryContext.Riders
                .Where(r => r.Id == request.Id)
                .ExecuteDeleteAsync(cancellationToken);


            return (count > 0 ?
                new OkObjectResult($"Rider deleted successfully") as IActionResult :
                new BadRequestObjectResult("Rider cannot Found") as IActionResult);
        }
    }
}
