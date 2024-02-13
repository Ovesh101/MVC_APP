using MVC_Demo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Demo.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            DBEmployee db = new DBEmployee();
            List<Employee> Emp = db.GetEmployee();

           
            return View(Emp);
        }
        public ActionResult About()
        {
            return View();
        }
      

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if(ModelState.IsValid == true)
                {
                    DBEmployee db = new DBEmployee();
                   bool succes =  db.AddEmployee(emp);
                    if(succes == true ) {
                        TempData["InsertMessage"] = "Data Inserted Successfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");

                    }
                }
                return View();

            }
            catch (Exception ex)
            {
                return View();

            }

          
        }
        public ActionResult Edit(int id)
        {
            DBEmployee db = new DBEmployee();
            var row = db.GetEmployee().Find(model => model.EmployeeID == id);
            return View();
        }



    }
}