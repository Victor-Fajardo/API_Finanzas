using API_Finanzas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Finanzas.Domain.Persistence.Contexts
{
    public class AppDbContext : DbContext
    {
        public DbSet<Operation> Operations { get; set; }
        public DbSet<PaymentLetter> PaymentLetters { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //User Entity
            builder.Entity<User>().ToTable("Users");
            builder.Entity<User>().HasKey(p => p.UserId);
            builder.Entity<User>().Property(p => p.UserId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().Property(p => p.UserName).IsRequired().HasMaxLength(25);
            builder.Entity<User>().Property(p => p.Password).IsRequired();
            builder.Entity<User>().Property(p => p.CompanyName).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.RUC).IsRequired();
            builder.Entity<User>().Property(p => p.Email).IsRequired();
            builder.Entity<User>().Property(p => p.Connected).IsRequired().HasDefaultValue(true);
            
            //PaymentLetter Entity
            builder.Entity<PaymentLetter>().ToTable("PaymentLetters");
            builder.Entity<PaymentLetter>().HasKey(p => p.PaymentLetterId);
            builder.Entity<PaymentLetter>().Property(p => p.PaymentLetterId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<PaymentLetter>().Property(p => p.Currency).IsRequired();
            builder.Entity<PaymentLetter>().Property(p => p.Amount).IsRequired();
            builder.Entity<PaymentLetter>().Property(p => p.EmisisonDate).IsRequired();
            builder.Entity<PaymentLetter>().Property(p => p.ExpirationDate).IsRequired();
            builder.Entity<PaymentLetter>().HasOne(pt => pt.User).WithMany(p => p.PaymentLetters).HasForeignKey(pt => pt.UserId);

            //Operation Entity
            builder.Entity<Operation>().ToTable("Operations");
            builder.Entity<Operation>().HasKey(p => p.OperationId);
            builder.Entity<Operation>().Property(p => p.OperationId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Operation>().Property(p => p.Rate).IsRequired();
            builder.Entity<Operation>().Property(p => p.Discount).IsRequired();
            builder.Entity<Operation>().Property(p => p.NetValue).IsRequired();
            builder.Entity<Operation>().Property(p => p.OutputValue).IsRequired();
            builder.Entity<Operation>().Property(p => p.Flow).IsRequired();
            builder.Entity<Operation>().Property(p => p.TCEA).IsRequired();
            builder.Entity<Operation>().HasOne(pt => pt.PaymentLetter).WithOne(p => p.Operation).HasForeignKey<Operation>(pt => pt.PaymentLetterId);
        }
    }
}
