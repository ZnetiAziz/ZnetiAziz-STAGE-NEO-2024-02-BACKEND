
// Expense.cs
namespace ExpenseTrackingApp.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string type { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = "En attente";
        public int EmployeeId { get; set; }
        
    }
}
