using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Server.Model
{
    public partial class OnlineShop2Context : DbContext
    {
        public OnlineShop2Context()
        {
        }

        public OnlineShop2Context(DbContextOptions<OnlineShop2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PurchaceItem> PurchaceItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-7QFC9M6C\\SQLEXPRESS;Initial Catalog=OnlineShop2;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Category1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Category");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.Comment)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.PurchaseItemId).HasColumnName("PurchaseItem_Id");

                entity.HasOne(d => d.PurchaseItem)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.PurchaseItemId)
                    .HasConstraintName("FK__Orders__Purchase__47DBAE45");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.CategoryId).HasColumnName("Category_id");

                entity.Property(e => e.Discription).HasColumnType("text");

                entity.Property(e => e.Image)
                    .HasColumnType("text")
                    .HasColumnName("image");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Product__Categor__4222D4EF");
            });

            modelBuilder.Entity<PurchaceItem>(entity =>
            {
                entity.ToTable("PurchaceItem");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.PurchaceItems)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__PurchaceI__Produ__44FF419A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
