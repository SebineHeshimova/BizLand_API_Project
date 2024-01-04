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
    public class PortfolioConfiguration : IEntityTypeConfiguration<Portfolio>
    {
        public void Configure(EntityTypeBuilder<Portfolio> builder)
        {
            builder.Property(x=>x.CategoryId).IsRequired();
            builder.Property(x => x.ImageUrl).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ProjectURL).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Client).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ProjectDate).IsRequired();
        }
    }
}
