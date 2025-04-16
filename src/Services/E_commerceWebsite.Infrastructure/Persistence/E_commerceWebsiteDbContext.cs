using E_commerceWebsite.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_commerceWebsite.Infrastructure.Persistence
{
    public class E_commerceWebsiteDbContext : DbContext
    {
        public E_commerceWebsiteDbContext(DbContextOptions<E_commerceWebsiteDbContext> options) 
            : base(options) 
        {
        }

        public virtual DbSet<WarehouseInvoiceDetail> Warehouse_Invoice_Details {  get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }
        public virtual DbSet<Voucher> Vouchers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product_Warehouse> Product_Warehouses { get; set; }
        public virtual DbSet<Product_Price_Discount> Product_Price_Discounts { get; set; }
        public virtual DbSet<Product_Detail> Product_Details { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Order_Detail> Order_Details { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Gift> Gifts { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Cart> Carts { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<UserRoles> UsersRoles { get; set; }
        public virtual DbSet<Permissions> Permissions { get; set; }
        public virtual DbSet<RolePermissions> RolePermissions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.ToTable("Brand");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Name).HasMaxLength(250);
                entity.Property(e => e.Description).HasMaxLength(250);
                entity.Property(e => e.Date_Create).HasColumnType("datetime");
                entity.Property(e => e.Date_Update).HasColumnType("datetime");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Product_name).HasMaxLength(250);
                entity.Property(e => e.Image_url).HasMaxLength(250);
                entity.Property(e => e.Quantity).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Unit_price).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Total_price).HasColumnType("decimal(28, 10)");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Name).HasMaxLength(250);
                entity.Property(e => e.Description).HasMaxLength(250);
                entity.Property(e => e.Product_Type).HasMaxLength(250);
                entity.Property(e => e.Date_Create).HasColumnType("datetime");
            });

            modelBuilder.Entity<Gift>(entity =>
            {
                entity.ToTable("Gift");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Name).HasMaxLength(250);
                entity.Property(e => e.Description).HasMaxLength(250);
                entity.Property(e => e.Image_url).HasMaxLength(250);
                entity.Property(e => e.DiscountValue).HasColumnType("decimal(28, 10)");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Type).HasMaxLength(250);
                entity.Property(e => e.Note).HasMaxLength(250);
                entity.Property(e => e.Image_url).HasMaxLength(250);
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Date_Create).HasColumnType("datetime");
                entity.Property(e => e.Date_Update).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Total_amount).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Full_name).HasMaxLength(250);
                entity.Property(e => e.Phone).HasMaxLength(250);
                entity.Property(e => e.Email).HasMaxLength(250);
                entity.Property(e => e.Address).HasMaxLength(250);
                entity.Property(e => e.Note).HasMaxLength(250);
                entity.Property(e => e.Date_Create).HasColumnType("datetime");
                entity.Property(e => e.Date_Update).HasColumnType("datetime");
            });

            modelBuilder.Entity<Order_Detail>(entity =>
            {
                entity.ToTable("Order_Detail");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Product_name).HasMaxLength(250);
                entity.Property(e => e.Unit_price).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Total_price).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Image_url).HasMaxLength(250);
                entity.Property(e => e.Quantity).HasColumnType("decimal(28, 10)");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Code).HasMaxLength(50);
                entity.Property(e => e.Name).HasMaxLength(250);
                entity.Property(e => e.Description).HasMaxLength(250);
                entity.Property(e => e.Colors).HasMaxLength(50);
                entity.Property(e => e.Image_url).HasMaxLength(250);
                entity.Property(e => e.Date_Create).HasColumnType("datetime");
                entity.Property(e => e.Date_Update).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product_Detail>(entity =>
            {
                entity.ToTable("Product_Detail");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Weight).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Product_Warehouse_quantity).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Image_url).HasMaxLength(50);
                entity.Property(e => e.Date_Create).HasColumnType("datetime");
                entity.Property(e => e.Date_Update).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product_Price_Discount>(entity =>
            {
                entity.ToTable("Product_Price_Discount");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Price).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Discount_percentage).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Discount_amount).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Type).HasMaxLength(50);
                entity.Property(e => e.Start_date).HasColumnType("datetime");
                entity.Property(e => e.End_date).HasColumnType("datetime");
                entity.Property(e => e.Date_Create).HasColumnType("datetime");
                entity.Property(e => e.Date_Update).HasColumnType("datetime");
            });

            modelBuilder.Entity<Product_Warehouse>(entity =>
            {
                entity.ToTable("Product_Warehouse");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Quantity).HasColumnType("decimal(28, 10)");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Last_name).HasMaxLength(250);
                entity.Property(e => e.First_name).HasMaxLength(250);
                entity.Property(e => e.Email).HasMaxLength(250);
                entity.Property(e => e.Password).HasMaxLength(250);
                entity.Property(e => e.Gender).HasMaxLength(50);
                entity.Property(e => e.Phone).HasMaxLength(10);
                entity.Property(e => e.Date_of_birth).HasMaxLength(50);
                entity.Property(e => e.Date_Create).HasColumnType("datetime");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.ToTable("Voucher");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Code).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(250);
                entity.Property(e => e.Discount_value).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Min_purchase_amount).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Start_date).HasColumnType("datetime");
                entity.Property(e => e.End_date).HasColumnType("datetime");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Location).HasMaxLength(250);
                entity.Property(e => e.Date_Create).HasColumnType("datetime");
                entity.Property(e => e.Date_Update).HasColumnType("datetime");
            });

            modelBuilder.Entity<WarehouseInvoiceDetail>(entity =>
            {
                entity.ToTable("WarehouseInvoiceDetail");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Quantity).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.UnitPrice).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(28, 10)");
                entity.Property(e => e.Date_Create).HasColumnType("datetime");
                entity.Property(e => e.Date_Update).HasColumnType("datetime");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Department");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Name).HasMaxLength(250);
                entity.Property(e => e.Description).HasMaxLength(250);
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("Roles");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Name).HasMaxLength(250);
                entity.Property(e => e.Description).HasMaxLength(250);
            });

            modelBuilder.Entity<UserRoles>(entity =>
            {
                entity.ToTable("UserRoles");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.User_Id).HasMaxLength(50);
                entity.Property(e => e.User_Name).HasMaxLength(250);
                entity.Property(e => e.Role_Id).HasMaxLength(50);
                entity.Property(e => e.Role_Name).HasMaxLength(250);
            });

            modelBuilder.Entity<Permissions>(entity =>
            {
                entity.ToTable("Permissions");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Name).HasMaxLength(50);
                entity.Property(e => e.Description).HasMaxLength(50);
            });

            modelBuilder.Entity<RolePermissions>(entity =>
            {
                entity.ToTable("RolePermissions");
                entity.HasKey(e => e.GuidId);

                entity.Property(e => e.Role_Id).HasMaxLength(50);
                entity.Property(e => e.Role_Name).HasMaxLength(250);
                entity.Property(e => e.Permission_Id).HasMaxLength(50);
                entity.Property(e => e.FunctionCode).HasMaxLength(250);
                entity.Property(e => e.CommandCode).HasMaxLength(250);
            });
        }
    }
}
