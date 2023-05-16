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
    public class JobVacancyMap : IEntityTypeConfiguration<JobVacancy>
    {
        public void Configure(EntityTypeBuilder<JobVacancy> builder)
        {
            //CONFIGURAÇÕES DE TABELA
            builder.ToTable("tb_Vacancy");
            builder.HasKey(x => x.Id);
            builder.Property(jv => jv.Title)
                .IsRequired()
                .HasConversion(jv => jv.ToString(), jv => jv)
                .HasColumnName("Title")
                .HasColumnType("varchar(100)");
            builder.Property(jv => jv.Description)
                .IsRequired()
                .HasConversion(jv => jv.ToString(), jv => jv)
                .HasColumnName("Description")
                .HasColumnType("varchar(300)");
            builder.Property(jv => jv.Company)
                .IsRequired()
                .HasConversion(jv => jv.ToString(), jv => jv)
                .HasColumnName("Company")
                .HasColumnType("varchar(100)");
            builder.Property(jv => jv.SalaryRange)
                .IsRequired()
                .HasConversion(jv => jv.ToString(), jv => jv)
                .HasColumnName("SalaryRange")
                .HasColumnType("varchar(50)");
            //CONFIGURAÇÕES ENTRE TABELAS
            builder.HasMany(jv => jv.Applications)
                .WithOne()
                .HasForeignKey(jv => jv.IdJobVacancy)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
