using Microsoft.EntityFrameworkCore;

namespace BankSolution.Models
{
    public class AddressContext : DbContext
    {
        public AddressContext(DbContextOptions<AddressContext> options)
            : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; } = null!;
    }
}
