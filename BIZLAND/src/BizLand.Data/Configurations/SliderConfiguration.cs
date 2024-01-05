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
    public class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(x=>x.Title1).IsRequired().HasMaxLength(20);
            builder.Property(x=>x.Title2).IsRequired().HasMaxLength(10);
            builder.Property(x=>x.Description).IsRequired().HasMaxLength(50);
            builder.Property(x=>x.Button1Text).IsRequired().HasMaxLength(20);
            builder.Property(x=>x.Button2Text).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Button1Url).IsRequired();
            builder.Property(x=>x.Button2Url).IsRequired();
        }
    }
}
