using DevJobs.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevJobs.Infrastructure.Persistence.Mapping
{
    public class JobApplicationMap : IEntityTypeConfiguration<JobApplication>
    {
        public void Configure(EntityTypeBuilder<JobApplication> builder)
        {
            builder.ToTable("tb_Application");
            builder.HasKey(x => x.Id);
            builder.Property(ja => ja.ApplicantEmail)
                .IsRequired()
                .HasConversion(ja => ja.ToString(), ja => ja)
                .HasColumnName("Email")
                .HasColumnType("varchar(100)");
            builder.Property(ja => ja.ApplicatName)
                .IsRequired()
                .HasConversion(ja => ja.ToString(), ja => ja)
                .HasColumnName("Name")
                .HasColumnType("varchar(150)");
        }
    }
}
