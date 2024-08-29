using BankSolution.Models;

namespace BankSolution.Models
{
    public class CheckingAccount : Account
    {
        public CheckingAccount(Guid accountId) : base(accountId)
        {
        }

        public int Limit { get; set; } = 50;

        public override bool Withdraw(int value)
        {
            if (Balance + Limit < value)
            {
                return false;
            }

            Balance -= value;
            return true;

        }
        
        public void ApplyFee(int interestRate)
        {
            if (Balance < 0)
            {
                Balance -= Balance * interestRate;
            }
        }

        public int CalculateFeeValue(int feeRate)
        {
            int fee = (Balance * feeRate) / 10000;
            return fee;
        }

        public void CalculateMonthlyFee(int feeRate)
        {
            int fee = CalculateFeeValue(feeRate);
            fee *= -1;
            Balance += Balance * fee;
        }
    }
}
