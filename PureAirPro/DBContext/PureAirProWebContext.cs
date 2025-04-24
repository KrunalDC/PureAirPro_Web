using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PureAirPro.DBContext
{
    public partial class PureAirProWebContext : DbContext
    {
        public PureAirProWebContext()
        {
        }

        public PureAirProWebContext(DbContextOptions<PureAirProWebContext> options)
            : base(options)
        {
        }

        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Users> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server= DESKTOP-2UKJO7T; Database=PureAirProWeb;Trusted_Connection=True; TrustServerCertificate=True; Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK__OrderDet__C3905BAF0AA682CB");

                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.InsertedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.OrderName).HasMaxLength(200);
                entity.Property(e => e.AddressLine1);
                entity.Property(e => e.AddressLine2);
                entity.Property(e => e.Province).HasMaxLength(200);
                entity.Property(e => e.Country).HasMaxLength(200);
                entity.Property(e => e.City).HasMaxLength(200);

                entity.Property(e => e.PostalCode).HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UpdatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserID)
                    .HasName("PK__Users__1788CCACBB19605D");

                entity.Property(e => e.FirstName).HasColumnName("FirstName");

                entity.Property(e => e.LastName)
                    .HasColumnName("LastName");

                entity.Property(e => e.Email)
                    .HasColumnName("Email");

                entity.Property(e => e.UserPassWord)
                    .HasColumnName("UserPassWord");

                entity.Property(e => e.ConfirmPassword)
                    .HasColumnName("ConfirmPassword");

                entity.Property(e => e.CreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsDeleted).HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
