using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerSystem.Models;

namespace ExpenseTrackerSystem.Interface
{
    interface IExpenseRepo
    {
        IEnumerable<Expense> AllExpenses();
    }
}
