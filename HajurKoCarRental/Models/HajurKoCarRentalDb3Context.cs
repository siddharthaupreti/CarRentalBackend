﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EMusic.Models;

public partial class HajurKoCarRentalDb3Context : DbContext
{
    public HajurKoCarRentalDb3Context()
    {
    }

    public HajurKoCarRentalDb3Context(DbContextOptions<HajurKoCarRentalDb3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CurrentStatus> CurrentStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=HajurKoCarRentalDB3");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.ToTable("Attachment");

            entity.Property(e => e.AttachmentId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Attachment_ID");
            entity.Property(e => e.Attachment1).HasColumnName("Attachment");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.User).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Attachment_User_ID");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.Property(e => e.CarId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Car_ID");
            entity.Property(e => e.CarCompany)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Car_Company");
            entity.Property(e => e.CarImage).HasColumnName("Car_Image");
            entity.Property(e => e.CarModel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Car_Model");
            entity.Property(e => e.CarStatusId).HasColumnName("Car_Status_ID");
            entity.Property(e => e.CarYear)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Car_Year");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PricePerday)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("Price_Perday");

            entity.HasOne(d => d.CarStatus).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Current_Status_ID");
        });

        modelBuilder.Entity<CurrentStatus>(entity =>
        {
            entity.ToTable("Current_Status");

            entity.Property(e => e.CurrentStatusId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("Current_Status_ID");
            entity.Property(e => e.CurrentStatus1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Current_Status");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("User_ID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.ContactNo)
                .HasMaxLength(50)
                .HasColumnName("Contact_No");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .HasColumnName("Full_Name");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.ToTable("UserRole");

            entity.Property(e => e.UserRoleId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("UserRoleID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_Role_ID");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_User_ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
