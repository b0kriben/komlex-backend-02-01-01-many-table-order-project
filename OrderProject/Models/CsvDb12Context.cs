using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace OrderProject.Models;

public partial class CsvDb12Context : DbContext
{
    public CsvDb12Context()
    {
    }

    public CsvDb12Context(DbContextOptions<CsvDb12Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Megrendelesek> Megrendeleseks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=\"csv_db 12\";user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Megrendelesek>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("megrendelesek");

            entity.Property(e => e.Id)
                .HasMaxLength(2)
                .HasColumnName("Id");
            entity.Property(e => e.MegrendeloId)
                .HasMaxLength(13)
                .HasColumnName("MegrendeloId");
            entity.Property(e => e.Datum)
                .HasMaxLength(10)
                .HasColumnName("Datum");
            entity.Property(e => e.Teljesitve)
                .HasMaxLength(10)
                .HasColumnName("Teljesitve");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
