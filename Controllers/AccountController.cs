using BankSolution.DTO;
using BankSolution.Infrastructure.Database;
using BankSolution.MemoryCache;
using BankSolution.Models;
using Microsoft.AspNetCore.Mvc;

namespace BankSolution.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly DatabaseContext _context;

        //public AccountController(DatabaseContext context)
        //{
        //    _context = context;
        //}

        [HttpPost("AddAccount")]
        public async Task<IActionResult> CreateAccount([FromBody] CreateAccountRequest createAccountRequest)
        {
            var customer = MemoryContext.CustomerList.FirstOrDefault(x => x.Id == createAccountRequest.CustomerId);

            if (customer == null)
            {
                return NotFound();
            }

            if (createAccountRequest.AccountType == AccountType.Savings)
            {
                customer.Accounts.Add(new SavingsAccount(System.Guid.NewGuid()));
            }
            else
            {
                customer.Accounts.Add(new CheckingAccount(System.Guid.NewGuid()));
            }

            return Created();

        }
        [HttpPost("AddOperation")]
        //TODO Rename this to a better option latter on
        public async Task<IActionResult> Transaction([FromBody] OperationRequest operationRequest)
        {
            var customer = MemoryContext.CustomerList.FirstOrDefault(x => x.Id == operationRequest.CustomerId);

            if (customer == null)
            {
                return NotFound();
            }

            var account = customer.Accounts.FirstOrDefault(x => x.Id == operationRequest.AccountId);

            if (account == null)
            {
                return NotFound();
            }

            if (operationRequest.OperationType == OperationType.Deposit)
            {
                account.Deposit(operationRequest.Amount);
                return Ok();
            }
            else
            {
                var withdrawPossible = account.Withdraw(operationRequest.Amount);
                if (!withdrawPossible)
                {
                    return Forbid();
                }

                return Ok();
            }
        }

        [HttpPost("CalculateFee")]
        //TODO Rename this to a better option latter on
        public async Task<IActionResult> CalculateFee([FromBody] AdjustMontlyBalance adjustMontlyBalance)
        {
            var customer = MemoryContext.CustomerList.FirstOrDefault(x => x.Id == adjustMontlyBalance.CustomerId);

            if (customer == null)
            {
                return NotFound();
            }

            var account = customer.Accounts.FirstOrDefault(x => x.Id == adjustMontlyBalance.AccountId);

            if (account == null)
            {
                return NotFound();
            }

            //TODO add validation for type to check whether or not this operation is been done into a saving account which is now allowed
            var checkingAccount = (CheckingAccount)account;

            checkingAccount.ApplyFee(adjustMontlyBalance.Rate);

            return Ok(); 
        }

        [HttpPost("CalculateInterest")]
        //TODO Rename this to a better option latter on
        public async Task<IActionResult> CalculateInterest([FromBody] AdjustMontlyBalance adjustMontlyBalance)
        {
            var customer = MemoryContext.CustomerList.FirstOrDefault(x => x.Id == adjustMontlyBalance.CustomerId);

            if (customer == null)
            {
                return NotFound();
            }

            var account = customer.Accounts.FirstOrDefault(x => x.Id == adjustMontlyBalance.AccountId);

            if (account == null)
            {
                return NotFound();
            }

            //TODO add validation for type to check whether or not this operation is been done into a saving account which is now allowed
            var checkingAccount = (SavingsAccount)account;

            checkingAccount.CalculateInterest(adjustMontlyBalance.Rate);

            return Ok();
        }
    }
}
