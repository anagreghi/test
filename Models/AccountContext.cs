using contaBancaria.Models;
using Microsoft.EntityFrameworkCore;

namespace BankSolution.Models
{
    public class AccountContext : DbContext
    {
        public AccountContext(DbContextOptions<AccountContext> options)
            : base(options)
        {

        }

        public DbSet<Account> Accounts { get; set; } = null!;
    }
}