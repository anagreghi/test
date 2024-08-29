using BankSolution.Models;

namespace BankSolution.DTO
{
    public class AddCustomer
    {
        public string DocumentNumber { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }
        public Address Address { get; set; }
        
    }
}
