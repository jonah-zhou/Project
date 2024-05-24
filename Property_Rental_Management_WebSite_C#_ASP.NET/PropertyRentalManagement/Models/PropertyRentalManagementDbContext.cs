using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PropertyRentalManagement.Models;

public partial class PropertyRentalManagementDbContext : DbContext
{
    public PropertyRentalManagementDbContext()
    {
    }

    public PropertyRentalManagementDbContext(DbContextOptions<PropertyRentalManagementDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Apartment> Apartments { get; set; }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=JONAH-DELL\\SQLEXPRESS;Initial Catalog=PropertyRentalManagementDB;User=sa;Password=123;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Apartment>(entity =>
        {
            entity.HasKey(e => e.ApartmentId).HasName("PK__Apartmen__CBDF576434EBC52D");

            entity.Property(e => e.ApartmentId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasColumnType("text");

            entity.HasOne(d => d.Building).WithMany(p => p.Apartments)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK__Apartment__Build__412EB0B6");

            entity.HasOne(d => d.Status).WithMany(p => p.Apartments)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Apartment__Statu__4222D4EF");
        });

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC2B416412E");

            entity.Property(e => e.AppointmentId).ValueGeneratedNever();
            entity.Property(e => e.AppointmentDateTime).HasColumnType("datetime");
            

            entity.HasOne(d => d.Apartment).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.ApartmentId)
                .HasConstraintName("FK__Appointme__Apart__46E78A0C");

            entity.HasOne(d => d.PropertyManager).WithMany(p => p.AppointmentPropertyManagers)
                .HasForeignKey(d => d.PropertyManagerId)
                .HasConstraintName("FK__Appointme__Prope__44FF419A");

            entity.HasOne(d => d.Tenant).WithMany(p => p.AppointmentTenants)
                .HasForeignKey(d => d.TenantId)
                .HasConstraintName("FK__Appointme__Tenan__45F365D3");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDC40DAFC510");

            entity.Property(e => e.BuildingId).ValueGeneratedNever();
            entity.Property(e => e.BuildingName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__Messages__C87C0C9C5A6962E5");

            entity.Property(e => e.MessageId).ValueGeneratedNever();
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.Timestamp).HasColumnType("datetime");

            entity.HasOne(d => d.Receiver).WithMany(p => p.MessageReceivers)
                .HasForeignKey(d => d.ReceiverId)
                .HasConstraintName("FK__Messages__Receiv__4AB81AF0");

            entity.HasOne(d => d.Sender).WithMany(p => p.MessageSenders)
                .HasForeignKey(d => d.SenderId)
                .HasConstraintName("FK__Messages__Sender__49C3F6B7");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Statuses__C8EE20638278DAE2");

            entity.Property(e => e.StatusId).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CFCF88952");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Status).WithMany(p => p.Users)
                .HasForeignKey(d => d.StatusId)
                .HasConstraintName("FK__Users__StatusId__3C69FB99");

            entity.HasOne(d => d.UserTypeNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserType)
                .HasConstraintName("FK__Users__UserType__3B75D760");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.HasKey(e => e.UserTypeId).HasName("PK__UserType__40D2D816B2ACB725");

            entity.Property(e => e.UserTypeId).ValueGeneratedNever();
            entity.Property(e => e.UserTypeDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
