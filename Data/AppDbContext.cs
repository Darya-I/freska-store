using Microsoft.EntityFrameworkCore;
using Store_microservice.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Store_microservice.Models.Rec;

namespace Store_microservice.Data

{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<UserPreference> UserPreferences { get; set; }
        public virtual ICollection<UserSession> UserSessions { get; set; }
        public virtual ICollection<UserCartItem> UserCartItems { get; set; }
    }

    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<ClothesSize> Sizes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Item> Products { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ItemSize> ItemSizes { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public DbSet<UserPreference> UserPreferences { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
        public DbSet<UserCartItem> UserCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subcategory>()
                .HasKey(sc => sc.SubcategoryId);

            modelBuilder.Entity<Item>()
                .HasKey(p => p.ProductId);

            modelBuilder.Entity<Gender>()
                .HasKey(g => g.GenderId);

            modelBuilder.Entity<Image>()
                .HasKey(i => i.ImageId);

            modelBuilder.Entity<ClothesSize>()
                .HasKey(s => s.SizeId);

            modelBuilder.Entity<Subcategory>()
                .HasOne(sc => sc.Category)
                .WithMany(c => c.Subcategories)
                .HasForeignKey(sc => sc.FK_CategoryId);

            modelBuilder.Entity<Item>()
                .HasOne(p => p.Subcategory)
                .WithMany(sc => sc.Items)
                .HasForeignKey(p => p.FK_SubcategoryId);

            modelBuilder.Entity<Item>()
                .HasOne(p => p.Gender)
                .WithMany()
                .HasForeignKey(p => p.FK_GenderId); // Указываем внешний ключ явно

            modelBuilder.Entity<Image>()
            .HasOne(i => i.Item)
            .WithMany(p => p.Images)
            .HasForeignKey(i => i.ProductId);


            modelBuilder.Entity<ItemSize>()
                .HasKey(isz => new { isz.ProductId, isz.SizeId });

            modelBuilder.Entity<ItemSize>()
                .HasOne<Item>(isz => isz.Product)
                .WithMany(p => (IEnumerable<ItemSize>)p.ItemSizes)
                .HasForeignKey(isz => isz.ProductId);


            modelBuilder.Entity<ItemSize>()
                .HasOne<ClothesSize>(isz => isz.Size)
                .WithMany(s => (IEnumerable<ItemSize>)s.Items)
                .HasForeignKey(isz => isz.SizeId);

            // Настройка связи Cart -> ApplicationUser
            modelBuilder.Entity<Cart>()
                .HasOne(c => c.User)
                .WithMany(u => u.Carts)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Настройка связи CartItem -> Cart
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.Items)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            // Настройка связи CartItem -> Product
            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Item)
                .WithMany(p => p.CartItems)
                .HasForeignKey(ci => ci.ProductId)
                .OnDelete(DeleteBehavior.Cascade);




            // Настройка связи UserPreference -> ApplicationUser
            modelBuilder.Entity<UserPreference>()
                .HasOne(up => up.User)
                .WithMany(u => u.UserPreferences)
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Настройка связи UserPreference -> Category
            modelBuilder.Entity<UserPreference>()
                .HasOne(up => up.Category)
                .WithMany()
                .HasForeignKey(up => up.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Настройка связи UserSession -> ApplicationUser
            modelBuilder.Entity<UserSession>()
                .HasOne(us => us.User)
                .WithMany(u => u.UserSessions)
                .HasForeignKey(us => us.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Настройка связи UserCartItem -> ApplicationUser
            modelBuilder.Entity<UserCartItem>()
                .HasOne(uci => uci.User)
                .WithMany(u => u.UserCartItems)
                .HasForeignKey(uci => uci.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Настройка связи UserCartItem -> Item
            modelBuilder.Entity<UserCartItem>()
                .HasOne(uci => uci.Product)
                .WithMany()
                .HasForeignKey(uci => uci.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        
    }

}
