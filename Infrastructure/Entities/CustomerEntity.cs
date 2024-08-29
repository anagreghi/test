namespace BankSolution.Infrastructure.Entities
{
    public class CustomerEntity : DBEntity<Guid>
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public virtual AddressEntity AddressEntity {get;set;}
        public virtual ICollection<AccountEntity> AccountEntities { get; set; } = [];
    }
}
