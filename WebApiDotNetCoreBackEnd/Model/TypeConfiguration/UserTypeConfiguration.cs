using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.TypeConfiguration
{
    class UserTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.ToTable("Users");
            entity.HasKey(e => e.IdUser)
                    .HasName("PK_User");

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.Property(e => e.Salt)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(300)
                .IsUnicode(false);

            entity.Property(e => e.Active).IsRequired();
        }
    }
}
