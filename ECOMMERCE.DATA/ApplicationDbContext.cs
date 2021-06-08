using ECOMMERCE.CORE.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECOMMERCE.DATA
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<BrandModels> BrandModels { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Customers> Customers { get; set; }
        public virtual DbSet<District> Districts { get; set; }
        public virtual DbSet<Neighborhood> Neighborhoods { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<OrderStatuses> OrderStatuses { get; set; }
        public virtual DbSet<PaymentTypes> PaymentTypes { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductImages> ProductImages { get; set; }
        public virtual DbSet<ProductProperties> ProductProperties { get; set; }
        public virtual DbSet<ProductPropertyValues> ProductPropertyValues { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCart { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<SubCategories> SubCategories { get; set; }
        public virtual DbSet<Sliders> Sliders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BrandModels>(entity =>
            {
                entity.ToTable("BRAND_MODELS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.CreatedById)
                    .HasColumnName("CreatedBy")
                    .IsRequired();

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("ProductType_ID")
                    .IsRequired();

                entity.Property(e => e.BrandId)
                    .HasColumnName("Brand_ID")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne<Brands>(x => x.Brand)
                    .WithMany(x => x.Models)
                    .HasForeignKey(x => x.BrandId);

                entity.HasOne<ProductTypes>(x => x.ProductType)
                    .WithMany(x => x.BrandModels)
                    .HasForeignKey(x => x.ProductTypeId);
            });

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.ToTable("BRANDS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.CreatedById)
                    .HasColumnName("CreatedBy")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProductTypes>(entity =>
            {
                entity.ToTable("PRODUCT_TYPES");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.CreatedById)
                    .HasColumnName("CreatedBy")
                    .IsRequired();

                entity.Property(e => e.SubCategoryId)
                    .HasColumnName("Sub_Category_ID")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasColumnName("Code")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne<SubCategories>(x => x.SubCategory)
                    .WithMany(x => x.ProductTypes)
                    .HasForeignKey(x => x.SubCategoryId);
            });

            modelBuilder.Entity<SubCategories>(entity =>
            {
                entity.ToTable("SUB_CATEGORIES");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.CreatedById)
                    .HasColumnName("CreatedBy")
                    .IsRequired();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("Category_ID")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasColumnName("Code")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne<Categories>(x => x.Category)
                    .WithMany(x => x.SubCategories)
                    .HasForeignKey(x => x.CategoryId);
            });

            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("CATEGORIES");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.CreatedById)
                    .HasColumnName("CreatedBy")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Code)
                    .HasColumnName("Code")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.ToTable("DISTRICT");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.CityId)
                    .HasColumnName("City_ID")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne<City>(x => x.City)
                    .WithMany(x => x.Districts)
                    .HasForeignKey(x => x.CityId);
            });

            modelBuilder.Entity<Neighborhood>(entity =>
            {
                entity.ToTable("NEIGHBORHOOD");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.DistrictId)
                    .HasColumnName("District_ID")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne<District>(x => x.District)
                    .WithMany(x => x.Neighborhoods)
                    .HasForeignKey(x => x.DistrictId);
            });

            modelBuilder.Entity<Customers>(entity =>
            {
                entity.ToTable("CUSTOMERS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.CityId)
                    .HasColumnName("City_ID")
                    .IsRequired();

                entity.Property(e => e.DistrictId)
                    .HasColumnName("District_ID")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("Password")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasColumnName("Address")
                    .IsUnicode(false);

                entity.Property(e => e.GSM1)
                    .HasColumnName("GSM1")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.GSM2)
                    .HasColumnName("GSM2")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasColumnName("Phone")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IsActive")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne<City>(x => x.City)
                    .WithMany(x => x.Customers)
                    .HasForeignKey(x => x.CityId);

                entity.HasOne<District>(x => x.District)
                    .WithMany(x => x.Customers)
                    .HasForeignKey(x => x.DistrictId);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.BrandModelId)
                    .HasColumnName("Brand_Model_ID")
                    .IsRequired();

                entity.Property(e => e.CreatedById)
                    .HasColumnName("CreatedBy")
                    .IsRequired();

                entity.Property(e => e.Title)
                    .HasColumnName("Title")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Weight)
                    .HasColumnName("Weight")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Width)
                    .HasColumnName("Width")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Height)
                    .HasColumnName("Height")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Color)
                    .HasColumnName("Color")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasColumnName("Price")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Discount)
                    .HasColumnName("Discount")
                    .IsUnicode(false);

                entity.Property(e => e.DateOfProduction)
                    .HasColumnName("Date_Of_Production")
                    .IsUnicode(false);

                entity.Property(e => e.ProductCode)
                    .HasColumnName("Product_Code")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Currency)
                    .HasColumnName("Currency")
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("Image")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.StockQuantity)
                    .HasColumnName("StockQuantity")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne<BrandModels>(x => x.BrandModel)
                    .WithMany(x => x.Products)
                    .HasForeignKey(x => x.BrandModelId);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENT");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_ID")
                    .IsRequired();

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_ID")
                    .IsRequired();

                entity.Property(e => e.ApprovedById)
                    .HasColumnName("ApprovedBy")
                    .IsRequired();

                entity.Property(e => e.Title)
                    .HasColumnName("Title")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CommentText)
                    .HasColumnName("CommentText")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CommentDate)
                    .HasColumnName("CommentDate")
                    .IsUnicode(false);

                entity.Property(e => e.IsApproved)
                    .HasColumnName("IsApproved")
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedDate)
                    .HasColumnName("ApprovedDate")
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne<Customers>(x => x.Customer)
                    .WithMany(x => x.Comments)
                    .HasForeignKey(x => x.CustomerId);

                entity.HasOne<Product>(x => x.Product)
                    .WithMany(x => x.Comments)
                    .HasForeignKey(x => x.ProductId);
            });

            modelBuilder.Entity<PaymentTypes>(entity =>
            {
                entity.ToTable("PAYMENT_TYPES");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.PaymentType)
                    .HasColumnName("PaymentType")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<OrderStatuses>(entity =>
            {
                entity.ToTable("ORDER_STATUSES");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.Status)
                    .HasColumnName("Status")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("ORDERS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_ID")
                    .IsRequired();

                entity.Property(e => e.PaymentTypeId)
                    .HasColumnName("PaymentType_ID")
                    .IsRequired();

                entity.Property(e => e.StatusId)
                    .HasColumnName("Status")
                    .IsRequired();

                entity.Property(e => e.ApprovedById)
                    .HasColumnName("ApprovedBy")
                    .IsRequired();

                entity.Property(e => e.OrderDate)
                    .HasColumnName("OrderDate")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("TotalAmount")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedDate)
                    .HasColumnName("ApprovedDate")
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne<Customers>(x => x.Customer)
                    .WithMany(x => x.Orders)
                    .HasForeignKey(x => x.CustomerId);

                entity.HasOne<PaymentTypes>(x => x.PaymentType)
                    .WithMany(x => x.Orders)
                    .HasForeignKey(x => x.PaymentTypeId);

                entity.HasOne<OrderStatuses>(x => x.Status)
                    .WithMany(x => x.Orders)
                    .HasForeignKey(x => x.StatusId);
            });

            modelBuilder.Entity<OrderDetails>(entity =>
            {
                entity.ToTable("ORDER_DETAILS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_ID")
                    .IsRequired();

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_ID")
                    .IsRequired();

                entity.Property(e => e.Count)
                    .HasColumnName("Count")
                    .IsRequired();

                entity.HasOne<Orders>(x => x.Order)
                    .WithMany(x => x.OrderDetails)
                    .HasForeignKey(x => x.OrderId);

                entity.HasOne<Product>(x => x.Product)
                    .WithMany(x => x.OrderDetails)
                    .HasForeignKey(x => x.ProductId);
            });

            modelBuilder.Entity<ProductImages>(entity =>
            {
                entity.ToTable("PRODUCT_IMAGES");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_ID")
                    .IsRequired();

                entity.Property(e => e.CreatedById)
                    .HasColumnName("CreatedBy")
                    .IsRequired();

                entity.Property(e => e.Thumbnail)
                    .HasColumnName("Thumbnail")
                    .HasMaxLength(1000)
                    .IsRequired();

                entity.Property(e => e.Image)
                    .HasColumnName("Image")
                    .HasMaxLength(1000)
                    .IsRequired();

                entity.Property(e => e.IsActive)
                    .HasColumnName("IsActive")
                    .IsRequired();

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .IsRequired();

                entity.HasOne<Product>(x => x.Product)
                    .WithMany(x => x.ProductImages)
                    .HasForeignKey(x => x.ProductId);
            });

            modelBuilder.Entity<ProductProperties>(entity =>
            {
                entity.ToTable("PRODUCT_PROPERTIES");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.ProductTypeId)
                    .HasColumnName("ProductType_ID")
                    .IsRequired();

                entity.Property(e => e.CreatedById)
                    .HasColumnName("CreatedBy")
                    .IsRequired();

                entity.Property(e => e.Property)
                    .HasColumnName("Property")
                    .HasMaxLength(50)
                    .IsRequired();

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .IsRequired();

                entity.Property(e => e.IsProduct)
                    .HasColumnName("IsProduct")
                    .IsRequired();

                entity.HasOne<ProductTypes>(x => x.ProductType)
                    .WithMany(x => x.ProductProperties)
                    .HasForeignKey(x => x.ProductTypeId);
            });

            modelBuilder.Entity<ProductPropertyValues>(entity =>
            {
                entity.ToTable("PRODUCT_PROPERTY_VALUES");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.BrandModelId)
                    .HasColumnName("Brand_Model_ID")
                    .IsRequired();

                entity.Property(e => e.ProductPropertyId)
                    .HasColumnName("ProductProperty_ID")
                    .IsRequired();

                entity.Property(e => e.CreatedById)
                    .HasColumnName("CreatedBy")
                    .IsRequired();

                entity.Property(e => e.Value)
                    .HasColumnName("Value")
                    .HasMaxLength(50);

                entity.Property(e => e.ValueReferenceModelId)
                    .HasColumnName("Value_Reference_Model_ID")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .IsRequired();

                entity.HasOne<BrandModels>(x => x.BrandModel)
                    .WithMany(x => x.ProductPropertyValues)
                    .HasForeignKey(x => x.BrandModelId);

                entity.HasOne<ProductProperties>(x => x.ProductProperty)
                    .WithMany(x => x.ProductPropertyValues)
                    .HasForeignKey(x => x.ProductPropertyId);
            });

            modelBuilder.Entity<ShoppingCart>(entity =>
            {
                entity.ToTable("SHOPPING_CART");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.CustomerId)
                    .HasColumnName("Customer_ID")
                    .IsRequired();

                entity.Property(e => e.ProductId)
                    .HasColumnName("Product_ID")
                    .IsRequired();

                entity.Property(e => e.Quantity)
                    .HasColumnName("Quantity")
                    .IsRequired();

                entity.Property(e => e.AddDate)
                    .HasColumnName("AddDate")
                    .IsRequired();

                entity.HasOne<Customers>(x => x.Customer)
                    .WithMany(x => x.ShoppingCarts)
                    .HasForeignKey(x => x.CustomerId);

                entity.HasOne<Product>(x => x.Product)
                    .WithMany(x => x.ShoppingCarts)
                    .HasForeignKey(x => x.ProductId);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("USERS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CreatedBy")
                    .IsRequired();

                entity.Property(e => e.Name)
                    .HasColumnName("Name")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnName("Email")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("Password")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsActive)
                    .HasColumnName("IsActive")
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sliders>(entity =>
            {
                entity.ToTable("SLIDERS");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id)
                    .UseIdentityColumn();

                entity.Property(e => e.CreatedBy)
                    .HasColumnName("CreatedBy")
                    .IsRequired();

                entity.Property(e => e.Title)
                    .HasColumnName("Title")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasColumnName("Description")
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LinkTitle)
                    .HasColumnName("LinkTitle")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasColumnName("Image")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedDate)
                    .HasColumnName("CreatedDate")
                    .IsRequired()
                    .IsUnicode(false);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}