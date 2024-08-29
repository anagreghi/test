namespace BankSolution.DTO
{
    public class AdjustMontlyBalance
    {
        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public int Rate { get; set; }
    }
}
