using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.TypeConfiguration
{
    class PlanoVooTypeConfiguration : IEntityTypeConfiguration<PlanoVoo>
    {
        public void Configure(EntityTypeBuilder<PlanoVoo> entity)
        {
            entity.HasKey(e => e.Idplanovoo)
                    .HasName("PK__PLANO_VO__6313708F5C53A0EC");

            entity.ToTable("PLANO_VOO");

            entity.Property(e => e.Idplanovoo).HasColumnName("IDPLANOVOO");

            entity.Property(e => e.Ativo).HasColumnName("ATIVO");

            entity.Property(e => e.Data)
                .HasColumnName("DATA")
                .HasColumnType("datetime");

            entity.Property(e => e.Idaeronave).HasColumnName("IDAERONAVE");

            entity.Property(e => e.Idaeroportodestino).HasColumnName("IDAEROPORTODESTINO");

            entity.Property(e => e.Idaeroportoorigem).HasColumnName("IDAEROPORTOORIGEM");

            entity.Property(e => e.Numerovoo)
                .IsRequired()
                .HasColumnName("NUMEROVOO")
                .HasMaxLength(7)
                .IsUnicode(false);

            entity.HasOne(d => d.Aeronave)
                .WithMany(p => p.PlanosVoo)
                .HasForeignKey(d => d.Idaeronave)
                .HasConstraintName("FK__PLANO_VOO__IDAER__2A4B4B5E");

            entity.HasOne(d => d.AeroportoDestino)
                .WithMany(p => p.PlanoVooIdaeroportodestinoNavigation)
                .HasForeignKey(d => d.Idaeroportodestino)
                .HasConstraintName("FK__PLANO_VOO__IDAER__2C3393D0");

            entity.HasOne(d => d.AeroportoOrigem)
                .WithMany(p => p.PlanoVooIdaeroportoorigemNavigation)
                .HasForeignKey(d => d.Idaeroportoorigem)
                .HasConstraintName("FK__PLANO_VOO__IDAER__2B3F6F97");
        }
    }
}
