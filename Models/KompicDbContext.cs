﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewCompicStore.Models;

public partial class KompicDbContext : DbContext
{
    public KompicDbContext()
    {
    }

    public KompicDbContext(DbContextOptions<KompicDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=KompicDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Order__3214EC07E2CA24B2");

            entity.ToTable("Order");

            entity.Property(e => e.DataOrder).HasColumnType("date");
            entity.Property(e => e.FinalPrice).HasColumnType("decimal(19, 4)");
            entity.Property(e => e.NameClient).HasMaxLength(50);
            entity.Property(e => e.PhoneNumber).HasColumnType("decimal(20, 0)");
            entity.Property(e => e.SurnameClient).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07B210031A");

            entity.ToTable("User");

            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
