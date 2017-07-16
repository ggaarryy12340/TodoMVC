using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoMVC.Models.ViewModel
{
    public class ActiveViewModel
    {
        public List<Todo> ActiveList { get; set; }

        public int NotCompleteCount { get; set; }
    }
}