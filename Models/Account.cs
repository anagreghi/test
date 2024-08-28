namespace contaBancaria.Models
{
    public abstract class Account
    {
        public Customer Customer { get; set; }
        public int AccountNumber { get; set; }
        public int BranchNumber { get; set; }
        public decimal Balance { get; protected set; }

        public Account(Customer customer, int accountNumber, int branchNumber)
        {
            Customer = customer;
            AccountNumber = accountNumber;
            BranchNumber = branchNumber;
            Balance = 0;
        }

        public void Deposit(decimal value)
        {
            Balance += value;
        }

        public abstract bool Withdraw(decimal value);
    }
}
