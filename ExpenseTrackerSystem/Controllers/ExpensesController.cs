using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExpenseTrackerSystem.Models;
using Microsoft.AspNet.Identity;

namespace ExpenseTrackerSystem.Controllers
{
    public class ExpensesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Expenses
        public ActionResult Index()
        {
            var userid = User.Identity.GetUserId();

            var expenses = db.Expenses.Where(u => u.ApplicationUserId == userid).Include(e => e.Category);
            return View(expenses.ToList());
        }

        // GET: Expenses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // GET: Expenses/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        // POST: Expenses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Price,Date,CategoryId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                var userid = User.Identity.GetUserId();
                expense.ApplicationUserId = userid;
                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        // GET: Expenses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        // POST: Expenses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Date,CategoryId")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                var userid = User.Identity.GetUserId();
                expense.ApplicationUserId = userid;
                db.Entry(expense).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", expense.CategoryId);
            return View(expense);
        }

        // GET: Expenses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Expense expense = db.Expenses.Find(id);
            ViewBag.catName = db.Expenses.Where(e => e.Id == id).Select(c => c.Category.Name).SingleOrDefault();
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }

        // POST: Expenses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Expense expense = db.Expenses.Find(id);
            db.Expenses.Remove(expense);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Reports()
        {
            return View();
        }

        public JsonResult WeeklyResult()
        {
            var UserId = User.Identity.GetUserId();
            var lastMonthDate = DateTime.Now.AddMonths(-1);
            var qry = db.Expenses.Where(u => u.ApplicationUserId == UserId).Include(c => c.Category);
            var weekqry = qry.Where(e => e.Date > lastMonthDate).GroupBy(c => c.Category.Name).Select(e => new
            {
                CatName = e.Key,
                Price = e.Sum(u => u.Price)
            }).ToList();

            return (Json(weekqry, JsonRequestBehavior.AllowGet));
        }

    
        public JsonResult MonthlyResult()
        {
            var userId = User.Identity.GetUserId();
            var lastMonthDate = DateTime.Now.AddMonths(-6);
            var qry = db.Expenses.Where(u => u.ApplicationUserId == userId).Include(c => c.Category);
            var monthqry = qry.Where(e => e.Date > lastMonthDate).GroupBy(c => c.Category.Name).Select(e => new
            {
                CatName = e.Key,
                Price = e.Sum(u => u.Price)
            }).ToList();

            return (Json(monthqry, JsonRequestBehavior.AllowGet));
        }
    }
}
