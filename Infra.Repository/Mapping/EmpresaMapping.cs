using Domain.Entitidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository.Mapping
{
    public class EmpresaMapping : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresa");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.NomeFantasma)
                .HasColumnName("Nome Fantasma")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.CNPJ)
               .HasColumnName("CNPJ")
               .HasMaxLength(11)
               .IsRequired();

            builder.Property(x => x.UF)
               .HasColumnName("UF")
               .HasMaxLength(2)
               .IsRequired();
        }
    }
}
