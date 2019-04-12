namespace dbproject
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class qahwa : DbContext
    {
        public qahwa()
            : base("qahwa")
        {
        }

        public virtual DbSet<Access_level> Access_level { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Company_Expenses> Company_Expenses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Order_details> Order_details { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Reward> Rewards { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Access_level>()
                .Property(e => e.access_value)
                .IsUnicode(false);

            modelBuilder.Entity<Access_level>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Access_level)
                .HasForeignKey(e => e.employee_access_code);

            modelBuilder.Entity<Category>()
                .Property(e => e.category_name)
                .IsUnicode(false);

            modelBuilder.Entity<Company_Expenses>()
                .Property(e => e.cost)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Company_Expenses>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Company_Expenses1)
                .HasForeignKey(e => e.units_in_stock);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_email)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.phone_number)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Rewards)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.employee_email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.employee_first_name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.employee_last_name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.sex)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Customers)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.created_by);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Employees1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.hired_by_id);

            modelBuilder.Entity<Order_details>()
                .Property(e => e.discount)
                .HasPrecision(10, 0);

            modelBuilder.Entity<Product>()
                .Property(e => e.product_name)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.price)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Company_Expenses)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.product_id);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supplier_name)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supplier_email)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.supplier_phone_number)
                .IsUnicode(false);
        }
    }
}
