namespace BankSolution.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Occupation { get; set; }
        public IList<Account> Accounts { get; set; }
    }
}
