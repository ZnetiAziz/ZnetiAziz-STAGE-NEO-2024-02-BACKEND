using Microsoft.EntityFrameworkCore;
using ExpenseTrackingApp.Models;

namespace ExpenseTrackingApp.Data
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<Expense>().ToTable("Expense");
            modelBuilder.Entity<Admin>().ToTable("Admin");
        }
    }
}
