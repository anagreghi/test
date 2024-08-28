using BankSolution.Models;
using System.Net;

namespace contaBancaria.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Profession { get; set; }

        public Customer(string cpf, string name, Address address, string profession)
        {
            CPF = cpf ?? throw new ArgumentNullException(nameof(cpf));
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Address = address ?? throw new ArgumentNullException(nameof(address));
            Profession = profession ?? throw new ArgumentNullException(nameof(profession));
        }
        public List<Account> Accounts { get; set; } = new List<Account>();
    }
}
