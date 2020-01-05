using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.TypeConfiguration
{
    class AeroportosTypeConfiguration : IEntityTypeConfiguration<Aeroportos>
    {
        public void Configure(EntityTypeBuilder<Aeroportos> entity)
        {
            entity.HasKey(e => e.Idaeroporto)
                    .HasName("PK__AEROPORT__FCD878B8C77562BA");

            entity.ToTable("AEROPORTOS");

            entity.Property(e => e.Idaeroporto).HasColumnName("IDAEROPORTO");

            entity.Property(e => e.Ativo).HasColumnName("ATIVO");

            entity.Property(e => e.Sigla)
                .IsRequired()
                .HasColumnName("SIGLA")
                .HasMaxLength(4)
                .IsUnicode(false);
        }
    }
}
