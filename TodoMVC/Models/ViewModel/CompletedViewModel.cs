using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoMVC.Models.ViewModel
{
    public class CompletedViewModel
    {
        public List<Todo> CompletedList { get; set; }

        public int NotCompleteCount { get; set; }
    }
}