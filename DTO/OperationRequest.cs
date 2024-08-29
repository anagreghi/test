namespace BankSolution.DTO
{
    public class OperationRequest
    {
        public Guid CustomerId { get; set; }
        public Guid AccountId { get; set; }
        public OperationType OperationType { get; set; }
        public int Amount { get; set; }
    }
}
