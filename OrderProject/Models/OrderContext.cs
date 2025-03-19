using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrderProject.Models;

public partial class OrderContext : DbContext
{
    public OrderContext()
    {
    }

    public OrderContext(DbContextOptions<OrderContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Database\\order.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("category");

            entity.Property(e => e.CategoryName).HasColumnName("categoryname");
            entity.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("id");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("customer");

            entity.Property(e => e.Budget)
                .HasColumnType("INT")
                .HasColumnName("budget");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("product");

            entity.Property(e => e.CategoryId)
                .HasColumnType("INT")
                .HasColumnName("category_id");
            entity.Property(e => e.Id)
                .HasColumnType("INT")
                .HasColumnName("id");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("INT")
                .HasColumnName("price");
            entity.Property(e => e.Stock)
                .HasColumnType("INT")
                .HasColumnName("stock");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("purchase");

            entity.Property(e => e.CustomerId)
                .HasColumnType("id")
                .HasColumnName("CustomerID");
            entity.Property(e => e.ProductId)
                .HasColumnType("INT")
                .HasColumnName("ProductID");
            entity.Property(e => e.Quantity).HasColumnType("INT");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
