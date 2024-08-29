namespace BankSolution.Infrastructure.Entities
{
    public class AddressEntity : DBEntity<Guid>
    {
        public Guid CustomerId { get; set; }
        public virtual CustomerEntity Customer { get; set; }
        public required string Address { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public required string Neighborhood { get; set; }
        public required string City { get; set; }
        public required string State { get; set; }
        public required string PostalCode { get; set; }
        public required string Country { get; set; }
    }
}
