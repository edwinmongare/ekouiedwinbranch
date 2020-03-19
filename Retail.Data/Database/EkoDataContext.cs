using Microsoft.EntityFrameworkCore;
using Retail.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Data.Database
{
    public class EkoDataContext : DbContext
    {
        public EkoDataContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agent>();
            modelBuilder.Entity<AgentGroup>();
            modelBuilder.Entity<AuditLog>();
            modelBuilder.Entity<Business>();
            modelBuilder.Entity<BusinessAccount>();
            modelBuilder.Entity<BusinessBranch>();
            modelBuilder.Entity<Currency>();
            modelBuilder.Entity<Customer>();
            modelBuilder.Entity<Expense>();
            modelBuilder.Entity<Inventory>();
            modelBuilder.Entity<Invoice>();
            modelBuilder.Entity<InvoiceLineItem>();
            modelBuilder.Entity<Payment>();
            modelBuilder.Entity<Plan>();
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<Receipt>();
            modelBuilder.Entity<ShoppingCart>();
            modelBuilder.Entity<ShoppingCartItem>();
            modelBuilder.Entity<Supplier>();
            modelBuilder.Entity<Tax>();
            modelBuilder.Entity<Transaction>();
            modelBuilder.Entity<UserProfile>();
        }
        public DbSet<Agent> Agents { get; set; }
        public DbSet<AgentGroup> AgentGroups { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessAccount> BusinessAccounts { get; set; }
        public DbSet<BusinessBranch> BusinessBranches { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceLineItem> InvoiceLineItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Plan> Plans { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tax> Taxes { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
