using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace OrderProject.Models;

public partial class CsvDb14Context : DbContext
{
    public CsvDb14Context()
    {
    }

    public CsvDb14Context(DbContextOptions<CsvDb14Context> options)
        : base(options)
    {
    }

    public virtual DbSet<RendelesTetelek> RendelesTeteleks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=\"csv_db 14\";user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<RendelesTetelek>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("rendeles_tetelek");

            entity.Property(e => e.MegrendelesId)
                .HasMaxLength(14)
                .HasColumnName("MegrendelesId");
            entity.Property(e => e.AruId)
                .HasMaxLength(6)
                .HasColumnName("AruId");
            entity.Property(e => e.AruMennyiseg)
                .HasMaxLength(13)
                .HasColumnName("AruMennyiseg");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
