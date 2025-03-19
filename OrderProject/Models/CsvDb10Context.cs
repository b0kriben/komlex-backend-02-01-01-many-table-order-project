using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace OrderProject.Models;

public partial class CsvDb10Context : DbContext
{
    public CsvDb10Context()
    {
    }

    public CsvDb10Context(DbContextOptions<CsvDb10Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Beszallitok> Beszallitoks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=\"csv_db 10\";user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.28-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Beszallitok>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("beszallitok");

            entity.Property(e => e.Id)
                .HasMaxLength(2)
                .HasColumnName("Id");
            entity.Property(e => e.BeszallitoNev)
                .HasMaxLength(14)
                .HasColumnName("BeszallitoNev");
            entity.Property(e => e.BeszallitoTelephely)
                .HasMaxLength(20)
                .HasColumnName("BeszallitoTelephely");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
