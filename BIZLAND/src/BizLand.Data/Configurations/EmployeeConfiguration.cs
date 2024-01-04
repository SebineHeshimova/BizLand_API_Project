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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(x=>x.FullName).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.ImageUrl).IsRequired().HasMaxLength(100);
            builder.Property(x => x.ProfessionId).IsRequired();
            builder.Property(x=>x.TwitterUrl).IsRequired();
            builder.Property(x => x.FacebookUrl).IsRequired();
            builder.Property(x => x.InstagramUrl).IsRequired();
            builder.Property(x => x.LinkedInUrl).IsRequired();
        }
    }
}
