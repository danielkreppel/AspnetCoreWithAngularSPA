using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.TypeConfiguration
{
    class AeronavesTypeConfiguration : IEntityTypeConfiguration<Aeronaves>
    {
        public void Configure(EntityTypeBuilder<Aeronaves> entity)
        {
            entity.HasKey(e => e.Idaeronave)
                     .HasName("PK__AERONAVE__C966EAD5A464EF69");

            entity.ToTable("AERONAVES");

            entity.Property(e => e.Idaeronave).HasColumnName("IDAERONAVE");

            entity.Property(e => e.Ativo).HasColumnName("ATIVO");

            entity.Property(e => e.Idtipoaeronave).HasColumnName("IDTIPOAERONAVE");

            entity.Property(e => e.Matricula)
                .IsRequired()
                .HasColumnName("MATRICULA")
                .HasMaxLength(7)
                .IsUnicode(false);

            entity.HasOne(d => d.TipoAeronave)
                .WithMany(p => p.Aeronaves)
                .HasForeignKey(d => d.Idtipoaeronave)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AERONAVES__IDTIP__25869641");
        }
    }
}
