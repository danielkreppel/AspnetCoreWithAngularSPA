using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.TypeConfiguration
{
    class UserRoleTypeConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> entity)
        {
            entity.ToTable("UserRoles");
            entity.HasKey(e => e.IdUserRole)
                     .HasName("PK_UserRole");

            entity.HasOne(d => d.Role)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.IdRole)
                .HasConstraintName("FK_UserRoles_Roles");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_UserRoles_Users");
        }
    }
}
