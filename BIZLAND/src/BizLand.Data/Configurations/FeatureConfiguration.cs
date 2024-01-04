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
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Icon).IsRequired();
        }
    }
}
