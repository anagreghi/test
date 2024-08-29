using BankSolution.Models;

namespace BankSolution.MemoryCache
{
    // This class was created to abstract the usage of a database and keep the storing data InMemory
    public static class MemoryContext
    {
        public static List<Customer> CustomerList { get; set; } = new List<Customer>();
    }
}
