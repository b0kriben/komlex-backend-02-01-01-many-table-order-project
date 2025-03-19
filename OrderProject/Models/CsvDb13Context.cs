using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace OrderProject.Models;

public partial class CsvDb13Context : DbContext
{
    public CsvDb13Context()
    {
    }

    public CsvDb13Context(DbContextOptions<CsvDb13Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Megrendelok> Megrendeloks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=\"csv_db 13\";user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Megrendelok>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("megrendelok");

            entity.Property(e => e.Id)
                .HasMaxLength(2)
                .HasColumnName("Id");
            entity.Property(e => e.MegrendeloNev)
                .HasMaxLength(14)
                .HasColumnName("MegrendeloNev");
            entity.Property(e => e.Lakhely)
                .HasMaxLength(14)
                .HasColumnName("Lakhely");
            entity.Property(e => e.Ferfi)
                .HasMaxLength(5)
                .HasColumnName("Ferfi");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
