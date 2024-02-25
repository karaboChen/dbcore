using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dbcore.Models;

public partial class testContext : DbContext
{
    public testContext(DbContextOptions<testContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Paw> Paw { get; set; }

    public virtual DbSet<_3_line> _3_line { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Paw>(entity =>
        {
            entity.HasKey(e => e.coli_id);

            entity.Property(e => e.coli_id).HasMaxLength(5);
            entity.Property(e => e.name).HasMaxLength(10);
            entity.Property(e => e.ssv).HasMaxLength(10);
            entity.Property(e => e.wwh).HasMaxLength(10);
        });

        modelBuilder.Entity<_3_line>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("3_line");

            entity.Property(e => e.coli_id).HasMaxLength(5);
            entity.Property(e => e.name).HasMaxLength(10);
            entity.Property(e => e.ssv).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
