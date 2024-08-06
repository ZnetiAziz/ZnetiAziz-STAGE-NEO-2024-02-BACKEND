using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ExpenseTrackingApp.Data;
using ExpenseTrackingApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseTrackingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly ExpenseContext _context;

        public AdminsController(ExpenseContext context)
        {
            _context = context;
        }

        // GET: api/Admins/Expenses
        [HttpGet("Expenses")]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpenses()
        {
            return await _context.Expenses.ToListAsync();
        }

        // PUT: api/Admins/ApproveExpense/5
        [HttpPut("ApproveExpense/{id}")]
        public async Task<IActionResult> ApproveExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            expense.Status = "Approved";
            _context.Entry(expense).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Admins/RejectExpense/5
        [HttpPut("RejectExpense/{id}")]
        public async Task<IActionResult> RejectExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            expense.Status = "Rejected";
            _context.Entry(expense).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
