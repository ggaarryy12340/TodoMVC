using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Models;
using TodoMVC.Models.ViewModel;

namespace TodoMVC.Controllers
{
    public class TodoMVCController : Controller
    {
        public ActionResult All()
        {
            AllViewModel vm = new AllViewModel();

            using (TodoContext db = new TodoContext())
            {
                vm.AllList = db.Todos.ToList();//全部Todo
                vm.NotCompleteCount = db.Todos.Where(x => !x.IsComplete).Count();
            }
            return View(vm);
        }

        public ActionResult Active()
        {
            ActiveViewModel vm = new ActiveViewModel();

            using (TodoContext db = new TodoContext())
            {
                vm.ActiveList = db.Todos.Where(x => !x.IsComplete).ToList();//未完成的Todo
                vm.NotCompleteCount = db.Todos.Where(x => !x.IsComplete).Count();
            }
            return View(vm);
        }

        public ActionResult Completed()
        {
            CompletedViewModel vm = new CompletedViewModel();

            using (TodoContext db = new TodoContext())
            {
                vm.CompletedList = db.Todos.Where(x => x.IsComplete).ToList();//完成的Todo
                vm.NotCompleteCount = db.Todos.Where(x => !x.IsComplete).Count();
            }
            return View(vm);
        }

        /// <summary>
        /// 儲存新增的Todo
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult Save(Todo model)
        {
            using (TodoContext db = new TodoContext())
            {
                db.Todos.Add(model);
                db.SaveChanges();
            }
            return RedirectToAction("All");
        }

        /// <summary>
        /// ajax儲存編輯過的Todo內容
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="Id"></param>
        public void EditContent(string Content, Guid Id)
        {
            using (TodoContext db = new TodoContext())
            {
                var Single = db.Todos.Find(Id);
                Single.Content = Content;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// ajax儲存點擊過後的Todo checkbox
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult EditIsComplete(Guid Id)
        {
            int NotCompleteCount = 0;

            using (TodoContext db = new TodoContext())
            {
                var Single = db.Todos.Find(Id);
                Single.IsComplete = !Single.IsComplete;//直接反轉 bool
                db.SaveChanges();

                NotCompleteCount = db.Todos.Where(x => !x.IsComplete).Count();
            }
            return Json(new { NotCompleteCount = NotCompleteCount }, JsonRequestBehavior.AllowGet);//return未完成Todo數量
        }
    }
}