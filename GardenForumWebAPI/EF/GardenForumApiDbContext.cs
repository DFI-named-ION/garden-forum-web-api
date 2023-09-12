using System;
using System.Collections.Generic;
using GardenForumWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GardenForumWebAPI.EF;

public partial class GardenForumApiDbContext : DbContext
{
    public GardenForumApiDbContext() {}

    public GardenForumApiDbContext(DbContextOptions<GardenForumApiDbContext> options) : base(options) {}

    public virtual DbSet<Article> Articles { get; set; }

    public virtual DbSet<ArticleLike> ArticleLikes { get; set; }

    public virtual DbSet<Receipt> Receipts { get; set; }

    public virtual DbSet<ReceiptLike> ReceiptLikes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GardenForumApiDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("articles_id_primary");

            entity.ToTable("articles");

            entity.HasIndex(e => e.Slug, "articles_slug_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Body)
                .HasMaxLength(1023)
                .HasColumnName("body");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Publish)
                .HasColumnType("datetime")
                .HasColumnName("publish");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(100)
                .HasColumnName("short_description");
            entity.Property(e => e.ShortTitle)
                .HasMaxLength(50)
                .HasColumnName("short_title");
            entity.Property(e => e.Slug)
                .HasMaxLength(1023)
                .HasColumnName("slug");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Articles)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("articles_author_id_foreign");
        });

        modelBuilder.Entity<ArticleLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("article_likes_id_primary");

            entity.ToTable("article_likes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ArticleId).HasColumnName("article_id");
            entity.Property(e => e.Publish)
                .HasColumnType("datetime")
                .HasColumnName("publish");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Article).WithMany(p => p.ArticleLikes)
                .HasForeignKey(d => d.ArticleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("article_likes_article_id_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.ArticleLikes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("article_likes_user_id_foreign");
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("receipts_id_primary");

            entity.ToTable("receipts");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Body)
                .HasMaxLength(1023)
                .HasColumnName("body");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.Publish)
                .HasColumnType("datetime")
                .HasColumnName("publish");
            entity.Property(e => e.ShortDescription)
                .HasMaxLength(100)
                .HasColumnName("short_description");
            entity.Property(e => e.ShortTitle)
                .HasMaxLength(50)
                .HasColumnName("short_title");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Receipts)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("receipts_author_id_foreign");
        });

        modelBuilder.Entity<ReceiptLike>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("receipt_likes_id_primary");

            entity.ToTable("receipt_likes");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Publish)
                .HasColumnType("datetime")
                .HasColumnName("publish");
            entity.Property(e => e.ReceiptId).HasColumnName("receipt_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Receipt).WithMany(p => p.ReceiptLikes)
                .HasForeignKey(d => d.ReceiptId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("receipt_likes_receipt_id_foreign");

            entity.HasOne(d => d.User).WithMany(p => p.ReceiptLikes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("receipt_likes_user_id_foreign");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("roles_id_primary");

            entity.ToTable("roles");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .HasColumnName("description");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("users_id_primary");

            entity.ToTable("users");

            entity.HasIndex(e => e.Login, "users_login_unique").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DisplayName)
                .HasMaxLength(50)
                .HasColumnName("display_name");
            entity.Property(e => e.LastOnline)
                .HasColumnType("datetime")
                .HasColumnName("last_online");
            entity.Property(e => e.Login)
                .HasMaxLength(50)
                .HasColumnName("login");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .HasColumnName("password");
            entity.Property(e => e.RoleId).HasColumnName("role_id");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_role_id_foreign");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
