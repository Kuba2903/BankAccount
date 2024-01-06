using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WindowApp;
using WindowApp.DBModels;
namespace WindowApp.Data;

public partial class BankContext : DbContext
{
    public BankContext()
    {
    }

    public BankContext(DbContextOptions<BankContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=HP;Initial Catalog=Bank;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Accounts__46A222CDE41DA9CA");

            entity.HasIndex(e => e.Pesel);

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.Budget)
                .HasColumnType("money")
                .HasColumnName("budget");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("date")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Pesel)
                .HasMaxLength(11)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pesel");
            entity.Property(e => e.Surname)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("surname");
            entity.Property(e => e.Password)
            .HasMaxLength(30)
            .IsRequired()
            .HasColumnName("password");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
