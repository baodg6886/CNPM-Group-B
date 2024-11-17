using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Koi.Repositories.Models;

public partial class KoiFishGameContext : DbContext
{
    public KoiFishGameContext()
    {
    }

    public KoiFishGameContext(DbContextOptions<KoiFishGameContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Breeding> Breedings { get; set; }

    public virtual DbSet<Breedingformula> Breedingformulas { get; set; }

    public virtual DbSet<Growthformula> Growthformulas { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Koifish> Koifishes { get; set; }

    public virtual DbSet<Pond> Ponds { get; set; }

    public virtual DbSet<Trade> Trades { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Valuation> Valuations { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=KoiFishGame;user=root;password=tram2005", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.40-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Breeding>(entity =>
        {
            entity.HasKey(e => e.BreedingId).HasName("PRIMARY");

            entity.ToTable("breeding");

            entity.HasIndex(e => e.FatherId, "FatherID");

            entity.HasIndex(e => e.MotherId, "MotherID");

            entity.Property(e => e.BreedingId).HasColumnName("BreedingID");
            entity.Property(e => e.FatherId).HasColumnName("FatherID");
            entity.Property(e => e.MotherId).HasColumnName("MotherID");
            entity.Property(e => e.Status).HasColumnType("enum('InProgress','Hatched','Completed')");
            entity.Property(e => e.Type).HasColumnType("enum('Manual','Automatic')");

            entity.HasOne(d => d.Father).WithMany(p => p.BreedingFathers)
                .HasForeignKey(d => d.FatherId)
                .HasConstraintName("breeding_ibfk_1");

            entity.HasOne(d => d.Mother).WithMany(p => p.BreedingMothers)
                .HasForeignKey(d => d.MotherId)
                .HasConstraintName("breeding_ibfk_2");
        });

        modelBuilder.Entity<Breedingformula>(entity =>
        {
            entity.HasKey(e => e.BreedingFormulaId).HasName("PRIMARY");

            entity.ToTable("breedingformula");

            entity.Property(e => e.BreedingFormulaId).HasColumnName("BreedingFormulaID");
            entity.Property(e => e.FatherBreed).HasMaxLength(255);
            entity.Property(e => e.MotherBreed).HasMaxLength(255);
        });

        modelBuilder.Entity<Growthformula>(entity =>
        {
            entity.HasKey(e => e.GrowthFormulaId).HasName("PRIMARY");

            entity.ToTable("growthformula");

            entity.Property(e => e.GrowthFormulaId).HasColumnName("GrowthFormulaID");
            entity.Property(e => e.Breed).HasMaxLength(255);
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PRIMARY");

            entity.ToTable("item");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Type).HasColumnType("enum('Food','Medicine')");
        });

        modelBuilder.Entity<Koifish>(entity =>
        {
            entity.HasKey(e => e.KoiId).HasName("PRIMARY");

            entity.ToTable("koifish");

            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.Breed).HasMaxLength(255);
            entity.Property(e => e.Color).HasMaxLength(255);
            entity.Property(e => e.Gender).HasColumnType("enum('Male','Female')");
            entity.Property(e => e.Image).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Origin).HasMaxLength(255);
            entity.Property(e => e.Status).HasColumnType("enum('Breeding','Growing','ForSale')");
        });

        modelBuilder.Entity<Pond>(entity =>
        {
            entity.HasKey(e => e.PondId).HasName("PRIMARY");

            entity.ToTable("pond");

            entity.Property(e => e.PondId).HasColumnName("PondID");
            entity.Property(e => e.Environment).HasMaxLength(255);
        });

        modelBuilder.Entity<Trade>(entity =>
        {
            entity.HasKey(e => e.TradeId).HasName("PRIMARY");

            entity.ToTable("trade");

            entity.HasIndex(e => e.BuyerId, "BuyerID");

            entity.HasIndex(e => e.KoiId, "KoiID");

            entity.HasIndex(e => e.SellerId, "SellerID");

            entity.Property(e => e.TradeId).HasColumnName("TradeID");
            entity.Property(e => e.BuyerId).HasColumnName("BuyerID");
            entity.Property(e => e.KoiId).HasColumnName("KoiID");
            entity.Property(e => e.SellerId).HasColumnName("SellerID");
            entity.Property(e => e.Time).HasColumnType("datetime");

            entity.HasOne(d => d.Buyer).WithMany(p => p.TradeBuyers)
                .HasForeignKey(d => d.BuyerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trade_ibfk_2");

            entity.HasOne(d => d.Koi).WithMany(p => p.Trades)
                .HasForeignKey(d => d.KoiId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trade_ibfk_3");

            entity.HasOne(d => d.Seller).WithMany(p => p.TradeSellers)
                .HasForeignKey(d => d.SellerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("trade_ibfk_1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "Username").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Balance)
                .HasPrecision(18, 2)
                .HasDefaultValueSql("'0.00'");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.UserRole).HasColumnType("enum('Player','Moderator','Admin')");
        });

        modelBuilder.Entity<Valuation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("valuation");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Breed).HasMaxLength(255);
            entity.Property(e => e.Gender).HasColumnType("enum('Male','Female')");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
