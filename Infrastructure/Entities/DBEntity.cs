namespace BankSolution.Infrastructure.Entities
{
    public abstract class DBEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set;}
        public DateTime DeletedAt { get; set; }
    }
}
