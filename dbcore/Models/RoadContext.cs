using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace dbcore.Models;

public partial class RoadContext : DbContext
{
    public RoadContext(DbContextOptions<RoadContext> options)
        : base(options)
    {
    }

    public virtual DbSet<aaaa> aaaa { get; set; }

    public virtual DbSet<map> map { get; set; }

    public virtual DbSet<sssd> sssd { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<aaaa>(entity =>
        {
            entity.HasKey(e => e.sssa);

            entity.Property(e => e.sssa)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<map>(entity =>
        {
            entity.HasKey(e => e.title);

            entity.Property(e => e.title).HasMaxLength(10);
        });

        modelBuilder.Entity<sssd>(entity =>
        {
            entity.HasKey(e => e.title);

            entity.Property(e => e.title).HasMaxLength(10);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
