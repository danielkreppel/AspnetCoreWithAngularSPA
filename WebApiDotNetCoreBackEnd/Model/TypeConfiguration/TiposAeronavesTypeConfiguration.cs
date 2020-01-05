using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.TypeConfiguration
{
    class TiposAeronavesTypeConfiguration : IEntityTypeConfiguration<TiposAeronaves>
    {
        public void Configure(EntityTypeBuilder<TiposAeronaves> entity)
        {
            entity.HasKey(e => e.Idtipoaeronave)
                    .HasName("PK__TIPOS_AE__8FA97976AEA8E856");

            entity.ToTable("TIPOS_AERONAVES");

            entity.Property(e => e.Idtipoaeronave).HasColumnName("IDTIPOAERONAVE");

            entity.Property(e => e.Ativo).HasColumnName("ATIVO");

            entity.Property(e => e.Descricao)
                .IsRequired()
                .HasColumnName("DESCRICAO")
                .HasMaxLength(5)
                .IsUnicode(false);
        }
    }
}
