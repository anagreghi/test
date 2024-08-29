using BankSolution.Models;

namespace BankSolution.Models
{
    public class SavingsAccount : Account
    {
        public SavingsAccount(Guid accountId) : base(accountId)
        {
        }

        public int CalculateInterest(int interestRate)
        {
            int interest = (Balance * interestRate) / 10000;
            return interest;
        }

        public void CalculateMonthlyInterest(int interestRate)
        {
            int interest = CalculateInterest(interestRate);
            Balance += Balance * interest;
        }

        public override bool Withdraw(int value)
        {
            if (Balance < value) return false;

            Balance -= value;

            return true;
        }
    }
}

