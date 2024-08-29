namespace BankSolution.DTO
{
    public class CreateAccountRequest
    {
        public Guid CustomerId { get; set; }
        public AccountType AccountType { get; set; }
    }
}
