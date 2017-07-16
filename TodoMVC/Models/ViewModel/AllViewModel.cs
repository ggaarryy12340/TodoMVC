using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoMVC.Models.ViewModel
{
    public class AllViewModel
    {
        public List<Todo> AllList { get; set; }

        public int NotCompleteCount { get; set; }
    }
}