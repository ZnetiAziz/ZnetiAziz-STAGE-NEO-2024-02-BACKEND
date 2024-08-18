// ExpensesController.cs
using ExpenseTrackingApp.Data;
using ExpenseTrackingApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        private static List<Expense> expenses = new List<Expense>();
        private static List<Employee> employees = new List<Employee>();

        [HttpGet]
        public ActionResult<IEnumerable<Expense>> GetExpenses()
        {
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public ActionResult<Expense> GetExpense(int id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        [HttpPost]
        public ActionResult<Expense> CreateExpense([FromBody] Expense expense)
        {
            var employee = employees.FirstOrDefault(e => e.Id == expense.EmployeeId);
            if (employee == null)
            {
                return BadRequest("Employee not found.");
            }

            expense.Id = expenses.Count > 0 ? expenses.Max(e => e.Id) + 1 : 1;
            expense.Status = "En attente"; // Définir le statut par défaut
            expenses.Add(expense);
            return CreatedAtAction(nameof(GetExpense), new { id = expense.Id }, expense);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateExpense(int id, [FromBody] Expense expense)
        {
            var existingExpense = expenses.FirstOrDefault(e => e.Id == id);
            if (existingExpense == null)
            {
                return NotFound();
            }

            var employee = employees.FirstOrDefault(e => e.Id == expense.EmployeeId);
            if (employee == null)
            {
                return BadRequest("Employee not found.");
            }

            existingExpense.type = expense.type;
            existingExpense.Amount = expense.Amount;
            existingExpense.Date = expense.Date;
            existingExpense.Status = expense.Status;
            existingExpense.EmployeeId = expense.EmployeeId;

            return NoContent();
        }

        [HttpPatch("{id}/status")]
        public ActionResult UpdateExpenseStatus(int id, [FromQuery] string status)
        {
            var existingExpense = expenses.FirstOrDefault(e => e.Id == id);
            if (existingExpense == null)
            {
                return NotFound();
            }

            if (status != "Acceptée" && status != "Rejetée")
            {
                return BadRequest("Invalid status. Valid statuses are 'Acceptée' or 'Rejetée'.");
            }

            existingExpense.Status = status;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteExpense(int id)
        {
            var expense = expenses.FirstOrDefault(e => e.Id == id);
            if (expense == null)
            {
                return NotFound();
            }
            expenses.Remove(expense);
            return NoContent();
        }
    }
}
