using Invoices.Core.Models;
using Invoices.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Invoices.Data
{
    public class InvoicesDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceItems> InvoiceItems { get; set; }

        public InvoicesDbContext(DbContextOptions<InvoicesDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new ProductConfiguration());

            builder
                .ApplyConfiguration(new InvoiceConfiguration());

            builder
               .ApplyConfiguration(new InvoiceItemsConfiguration());
        }
    }
}