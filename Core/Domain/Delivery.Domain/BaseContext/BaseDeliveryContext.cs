using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain
{
    public class BaseDeliveryContext : DbContext
    {
        public DbSet<Rider> Riders { get; set; }
        public BaseDeliveryContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
    }
}
