using Krop.DataAccess.Configurations;
using Krop.Entities.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Krop.DataAccess.Context
{
    public class KropContext:IdentityDbContext<AppUser,AppUserRole,Guid>
	{
        public KropContext()
        {
            
        }
        public KropContext(DbContextOptions<KropContext> options) :base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
		public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Supplier>  Suppliers { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductReceipt> ProductReceipts { get; set; }
        public DbSet<StockInput> StockInputs { get; set; }
        public DbSet<StockTransfer> StockTransfers { get; set; }
        public DbSet<Production> Productions { get; set; }
        public DbSet<ProductionStockExit> ProductionStockExits { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
		{
            builder.ApplyConfiguration(new CategoryConfiguration());
            builder.ApplyConfiguration(new ProductConfiguration());
            builder.ApplyConfiguration(new AppUserConfiguration());
            builder.ApplyConfiguration(new BranchConfiguration());
            builder.ApplyConfiguration(new DepartmentConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new StockConfiguration());
            builder.ApplyConfiguration(new BrandConfiguration());
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new SupplierConfiguration());
            builder.ApplyConfiguration(new ProductReceiptConfiguration());
            builder.ApplyConfiguration(new StockInputConfiguration());
            builder.ApplyConfiguration(new StockTransferConfiguration());
            builder.ApplyConfiguration(new  ProductionConfiguration());
            builder.ApplyConfiguration(new ProductionStockExitConfiguration());
			base.OnModelCreating(builder);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            optionsBuilder.UseSqlServer("server=DESKTOP-RL3FR4V;database=KropDB;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");

            base.OnConfiguring(optionsBuilder);
		}
	}
}
