using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model.TypeConfiguration;

namespace Model
{
    public partial class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext()
        {
        }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
         
        }

        public virtual DbSet<Aeronaves> Aeronaves { get; set; }
        public virtual DbSet<Aeroportos> Aeroportos { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<PlanoVoo> PlanoVoo { get; set; }
        public virtual DbSet<TiposAeronaves> TiposAeronaves { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=ApplicationDB;Trusted_Connection=True;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.ApplyConfiguration(new AeronavesTypeConfiguration());

            modelBuilder.ApplyConfiguration(new AeroportosTypeConfiguration());

            modelBuilder.ApplyConfiguration(new RoleTypeConfiguration());

            modelBuilder.ApplyConfiguration(new PlanoVooTypeConfiguration());

            modelBuilder.ApplyConfiguration(new TiposAeronavesTypeConfiguration());

            modelBuilder.ApplyConfiguration(new UserTypeConfiguration());

            modelBuilder.ApplyConfiguration(new UserRoleTypeConfiguration());
        }
    }
}
