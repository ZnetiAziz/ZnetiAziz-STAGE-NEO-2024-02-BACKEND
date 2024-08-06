
// Expense.cs
namespace ExpenseTrackingApp.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public string ApprovalStatus { get; set; } // "Pending", "Approved", "Rejected"
    }
}
