using BankSolution.DTO;
using BankSolution.Models;

namespace BankSolution.Models
{
    public abstract class Account
    {
        protected Account(Guid accountId)
        {

            Id = accountId;

        }
        public Guid Id { get; set; }
        //public required Customer Customer { get; set; }
        public int AccountNumber { get; set; }
        public  int BranchNumber { get; set; }
        public  AccountType AccountType { get; set; }
        public int Balance { get; protected set; }

        public void Deposit(int value)
        {
            Balance += value;
        }

        public abstract bool Withdraw(int value);
    }
}
