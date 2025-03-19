using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace OrderProject.Models;

public partial class CsvDb9Context : DbContext
{
    public CsvDb9Context()
    {
    }

    public CsvDb9Context(DbContextOptions<CsvDb9Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Alkatreszek> Alkatreszeks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=\"csv_db 9\";user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Alkatreszek>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("alkatreszek");

            entity.Property(e => e.Id)
                .HasMaxLength(2)
                .HasColumnName("Id");
            entity.Property(e => e.Nev)
                .HasMaxLength(12)
                .HasColumnName("Nev");
            entity.Property(e => e.Ar)
                .HasMaxLength(6)
                .HasColumnName("Ar");
            entity.Property(e => e.Raktaron)
                .HasMaxLength(8)
                .HasColumnName("Raktaron");
            entity.Property(e => e.LaptopAlkatresz)
                .HasMaxLength(16)
                .HasColumnName("LaptopAlkatresz");
            entity.Property(e => e.BeszallitoId)
                .HasMaxLength(13)
                .HasColumnName("BeszallitoId");
            entity.Property(e => e.KategoriaId)
                .HasMaxLength(12)
                .HasColumnName("KategoriaId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
