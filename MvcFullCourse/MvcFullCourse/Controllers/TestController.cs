using MvcFullCourse.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcFullCourse.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            MvcTutorialEntities db = new MvcTutorialEntities();
            List<Employee> employees = db.Employee.ToList();

            List<EmployeeViewModel> employeModels = employees.Where(x=>x.Id>0).Select(x => new EmployeeViewModel
            {
                name = x.name,
                adress = x.adress,
                Id = x.Id,
                departmentname = x.department.departmentname

            }).ToList();
            ViewBag.employeList = employeModels;

            ViewBag.MyName = "METİN TEKİN";
            List<string> Names = new List<string>();
            Names.Add("Ayşe");
            Names.Add("Merve");
            Names.Add("Sıla");
            ViewBag.Names = Names;


            //List<Employee> employes = new List<Employee>();
            //employes.Add(new Employee { EmployeeId = 1, EmployeeName = "SARAH CUKA", Department = "IT" });
            //employes.Add(new Employee { EmployeeId = 2, EmployeeName = "MARTIN GARRIX", Department = "GEO" });
            //employes.Add(new Employee { EmployeeId = 3, EmployeeName = "TIM CRUL", Department = "HEA" });
            //employes.Add(new Employee { EmployeeId = 4, EmployeeName = "MENSAH HAVAI", Department = "SP" });
            //Employee emp = new Employee();
            return View();
        }
        public ActionResult DepartmentDropdown()
        {
            MvcTutorialEntities db = new MvcTutorialEntities();
            List<Employee> employees = db.Employee.ToList();

            List<EmployeeViewModel> employeModels = employees.Where(x => x.Id > 0).Select(x => new EmployeeViewModel
            {
                name = x.name,
                adress = x.adress,
                Id = x.Id,
                departmentname = x.department.departmentname

            }).ToList();
            ViewBag.employeList = employeModels;
            //dropdown
            List<department> departments = db.department.ToList();
            ViewBag.departmentList = new SelectList(departments, "Id", "departmentname");
            //

            return View();
        }

        [HttpPost]
        public ActionResult DepartmentDropdown(EmployeeViewModel model)
        {
            //if (ModelState.IsValid == true)
            //{
            MvcTutorialEntities db = new MvcTutorialEntities();

            //dropdown
            List<department> departments = db.department.ToList();
            ViewBag.departmentList = new SelectList(departments, "Id", "departmentname");
            //
            Employee employee = new Employee();
            employee.name = model.name;
            employee.adress = model.adress;
            employee.departmentId = model.departmentId;
            db.Employee.Add(employee);
            db.SaveChanges();

            //}


            return View();
        }

        [HttpPost]
        public ActionResult DeleteEmployee(int employeId)
        {
            MvcTutorialEntities db = new MvcTutorialEntities();
            Employee employee = db.Employee.Where(e => e.Id == employeId).FirstOrDefault();
            db.Employee.Remove(employee);
            db.SaveChanges();
            return View();
        }

        public ActionResult EmployeDetail(int ID)
        {
            MvcTutorialEntities db = new MvcTutorialEntities();
            Employee employee = db.Employee.Where(x => x.Id == ID).FirstOrDefault();
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.Id = employee.Id;
            employeeViewModel.name = employee.name;
            employeeViewModel.adress = employee.adress;
            employeeViewModel.departmentname = employee.department.departmentname;


            return View(employeeViewModel);
        }

        public ActionResult _PartialEmployeDetail(int ID)
        {
            MvcTutorialEntities db = new MvcTutorialEntities();
            Employee employee = db.Employee.Where(x => x.Id == ID).FirstOrDefault();
            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.Id = employee.Id;
            employeeViewModel.name = employee.name;
            employeeViewModel.adress = employee.adress;
            employeeViewModel.departmentname = employee.department.departmentname;

            ViewBag.Id = employee.Id;
            ViewBag.name = employee.name;
            ViewBag.adress = employee.adress;
            ViewBag.departmentname = employee.department.departmentname;




            return PartialView("/Views/Shared/_PartialEmployeDetail.cshtml");
        }
    }
}