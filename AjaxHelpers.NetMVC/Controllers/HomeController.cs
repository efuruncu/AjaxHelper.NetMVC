using AjaxHelpers.NetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxHelpers.NetMVC.Controllers
{
    public class HomeController : Controller
    {
        //Ajax
        //Sayfalar yenilenmeden istenilen dataların gönderilip istenilen dataların gelmesini sağlar.
        //Daha az veri gidip geliyor. Bundle dostu.Performansı artırır.
        //Sayfa tamamen yenilenmediği için kullanıcı dostu
        
            // GET: Home
        public ActionResult Index()
        {
            List<string> veriler = new List<string>()
            {
                "elif","yunus","esra","emir","yasemin"
            };
            Session["listem"] = veriler;
            return View();
        }

        public PartialViewResult LoadData()
        {
            List<string> veriler = Session["listem"] as List<string>;
            //butona bastığımızda 3 sn bekle verileri getirmek için
            System.Threading.Thread.Sleep(3000);
            return PartialView("_VeriListesiPartialView",veriler);
        }
        public MvcHtmlString RemoveData(int id)
        {
            List<string> veriler = Session["listem"] as List<string>;
            veriler.RemoveAt(id);
            Session["listem"] = veriler;
            System.Threading.Thread.Sleep(3000);
            return MvcHtmlString.Empty;
        }


        //Index2
        public ActionResult Index2()
        {
            List<TodoItem> list = null;
            if (Session["todolist"] != null)
            {
                list = Session["todolist"] as List<TodoItem>;
            }
            else
            {
                list = new List<TodoItem>();
            }
            ViewBag.List = list;
            return View(new TodoItem());
        }
        [HttpPost]
        public PartialViewResult Index2(TodoItem model)
        {
            List<TodoItem> list = null;
            if (Session["todolist"] != null)
            {
                list = Session["todolist"] as List<TodoItem>;
            }
            else
            {
                list = new List<TodoItem>();
            }
            model.Id = Guid.NewGuid();
            list.Add(model);

            Session["todolist"] = list;

            System.Threading.Thread.Sleep(3000);
            return PartialView("_TodoItemPartialView",model);
        }
    }
}