using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SSAApp.Web.Domain.Entities;

namespace SSAApp.Web.Infraestructure
{
    public partial class SSAAppContext : DbContext
    {
        public SSAAppContext()
        {
        }

        public SSAAppContext(DbContextOptions<SSAAppContext> options)
            : base(options)
        {

        }

        public virtual DbSet<Server> Server { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Username=postgres;Password=4dm1n3214dm1n321;Host=database-test.cnbndhjcuspi.us-east-2.rds.amazonaws.com;Port=5432;Database=ssaapp;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Server>(entity =>
            {
                entity.ToTable("Server", "private");
                entity.HasKey(e => e.IdServer);
                entity.Property(e => e.IdServer).UseIdentityAlwaysColumn();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
