using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace ExpenseTrackerSystem.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        [DataType((DataType.Date))]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}",ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public string ApplicationUserId { get; set; }
    }
}