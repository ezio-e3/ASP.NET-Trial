using Delivery.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infrastructure.Configurations
{
    public class RiderConfiguration : IEntityTypeConfiguration<Rider>
    {
        void IEntityTypeConfiguration<Rider>.Configure(EntityTypeBuilder<Rider> builder)
        {
            //builder.Property(p => p.Name).HasMaxLength(50);
        }
    }
}
