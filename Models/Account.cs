using BankSolution.Models;

namespace BankSolution.Models
{
    public abstract class Account
    {
        public int Id { get; set; }
        public required Customer Customer { get; set; }
        public required int AccountNumber { get; set; }
        public required int BranchNumber { get; set; }
        public required string AccountType { get; set; }
        //criar enum para AccountType
        public decimal Balance { get; protected set; }

        //public Account(Customer customer, int accountNumber, int branchNumber)
        //{
        //    Customer = customer;
        //    AccountNumber = accountNumber;
        //    BranchNumber = branchNumber;
        //    Balance = 0;
        //}
         
        public void Deposit(decimal value)
        {
            Balance += value;
        }

        public abstract bool Withdraw(decimal value);
    }
}
