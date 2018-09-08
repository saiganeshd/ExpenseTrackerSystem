using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ExpenseTrackerSystem.Interface;
using ExpenseTrackerSystem.Models;
using Microsoft.AspNet.Identity;

namespace ExpenseTrackerSystem.Gateway
{
    public class ExpenseRepo : IExpenseRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        IEnumerable<Expense> IExpenseRepo.AllExpenses()
        {
            var userid = HttpContext.Current.User.Identity.GetUserId();

            return db.Expenses.Where(u => u.ApplicationUserId == userid).Include(e => e.Category);
        }
    }
}