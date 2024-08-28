using contaBancaria.Models;

namespace BankSolution.Models
{
    public class CheckingAccount : Account
    {
        public decimal Limit { get; set; }

        public CheckingAccount(Customer customer, int accountNumber, int branchNumber, decimal limit)
            : base(customer, accountNumber, branchNumber)
        {
            Limit = limit;
        }
        //verificando o balance (saldo) da conta para saque
        public override bool Withdraw(decimal value)
        {
            if (Balance + Limit >= value)
            {
                Balance -= value;
                return true;
            }
            return false;
                        
        }
        //aplicando a taxa de juros informada pelo usuario quando a conta está negativa
        public void ApplyInterest(decimal interestRate)
        {
            if (Balance < 0)
            {
                Balance -= Balance * interestRate;
            }
        }

    }
}
