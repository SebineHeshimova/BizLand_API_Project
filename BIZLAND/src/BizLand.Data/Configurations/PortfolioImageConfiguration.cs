using BizLand.Core.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Data.Configurations
{
    public class PortfolioImageConfiguration : IEntityTypeConfiguration<PortfolioImage>
    {
        public void Configure(EntityTypeBuilder<PortfolioImage> builder)
        {
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(100);
        }
    }
}
