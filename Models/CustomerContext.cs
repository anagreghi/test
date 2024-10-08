﻿using BankSolution.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSolution.Models
{
    public class CustomerContext : DbContext
    {
        public CustomerContext(DbContextOptions<CustomerContext> options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; } = null!;
    }
}