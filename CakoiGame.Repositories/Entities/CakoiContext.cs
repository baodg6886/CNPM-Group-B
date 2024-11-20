using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace CakoiGame.Repositories.Entities;

public partial class CakoiContext : DbContext
{
    public CakoiContext()
    {
    }

    public CakoiContext(DbContextOptions<CakoiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fishgrowth> Fishgrowths { get; set; }

    public virtual DbSet<ProductCakoi> ProductCakois { get; set; }

    public virtual DbSet<QlUser> QlUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=cakoi;user=root;password=@DaoGiaBao2710", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.34-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Fishgrowth>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fishgrowth");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AgeRange)
                .HasMaxLength(20)
                .HasColumnName("age_range");
            entity.Property(e => e.GrowthLevel)
                .HasMaxLength(20)
                .HasColumnName("growth_level");
            entity.Property(e => e.MaxGrowthCm).HasColumnName("max_growth_cm");
        });

        modelBuilder.Entity<ProductCakoi>(entity =>
        {
            entity.HasKey(e => e.IdproductCakoi).HasName("PRIMARY");

            entity
                .ToTable("product_cakoi")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.MaGc, "FK_MaGC");

            entity.Property(e => e.IdproductCakoi).HasColumnName("idproduct_cakoi");
            entity.Property(e => e.ImgCakoi)
                .HasColumnType("text")
                .HasColumnName("img_cakoi");
            entity.Property(e => e.MaGc).HasColumnName("maGC");
            entity.Property(e => e.NameCakoi)
                .HasColumnType("text")
                .HasColumnName("name_cakoi");
            entity.Property(e => e.OriginCakoi)
                .HasMaxLength(45)
                .HasColumnName("origin_cakoi");
            entity.Property(e => e.PriceCakoi)
                .HasPrecision(10, 2)
                .HasColumnName("price_cakoi");
            entity.Property(e => e.SexCakoi)
                .HasMaxLength(45)
                .HasColumnName("sex_cakoi");
            entity.Property(e => e.SizeCakoi).HasColumnName("size_cakoi");
            entity.Property(e => e.WeightCakoi).HasColumnName("weight_cakoi");
        });

        modelBuilder.Entity<QlUser>(entity =>
        {
            entity.HasKey(e => new { e.IdqlUser, e.UsernameUser })
                .HasName("PRIMARY")
                .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

            entity
                .ToTable("ql_user")
                .HasCharSet("utf8mb3")
                .UseCollation("utf8mb3_bin");

            entity.HasIndex(e => e.UsernameUser, "username_user_UNIQUE").IsUnique();

            entity.Property(e => e.IdqlUser)
                .ValueGeneratedOnAdd()
                .HasColumnName("idql_user");
            entity.Property(e => e.UsernameUser)
                .HasMaxLength(45)
                .HasColumnName("username_user");
            entity.Property(e => e.AccessUser)
                .HasMaxLength(10)
                .HasDefaultValueSql("'user'")
                .HasColumnName("access_user");
            entity.Property(e => e.EmailUser)
                .HasMaxLength(45)
                .HasColumnName("email_user");
            entity.Property(e => e.PasswordUser)
                .HasMaxLength(45)
                .HasColumnName("password_user");
            entity.Property(e => e.PhoneUser)
                .HasMaxLength(45)
                .HasColumnName("phone_user");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
