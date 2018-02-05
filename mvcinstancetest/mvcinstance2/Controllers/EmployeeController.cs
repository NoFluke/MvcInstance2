using mvcinstance2.DataAccessLayer;
using mvcinstance2.Models;
using mvcinstance2.ViewModels;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvcinstance2.Controllers
{
    public class Customer
    {
        private string name;
        private string address;

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }
        public override string ToString()
        {
            return this.name+"1"+this.address;
        }
    }
    public class EmployeeController : Controller
    {

     
        public string GetString()
        {
            return "this is controll";
        }
        public Customer getCustomer()
        {
            Customer c = new Customer();
            c.Address = "11";
            c.Name = "22";
            return c;
        }
        [NonAction]
        public string NonActionMethod()
        {
            return "this is no action";
        }
        public ActionResult Index()
        {
            Employee emp = new Employee() { FirstName = "11", LastName = "22", Salary = 10 };
            //ViewData["Employee"] = emp;
            EmployeeViewModel vmEmp = new EmployeeViewModel();
            vmEmp.EmployeeName = string.Format(@"{0}{1}", emp.FirstName, emp.LastName);
            vmEmp.Salary = emp.Salary.ToString();
            if (emp.Salary > 20)
            {
                vmEmp.SalaryColor = "blue";
            }
            else
            {
                vmEmp.SalaryColor = "red";
            }
            EmployeeViewModel vmEmp2 = new EmployeeViewModel() { EmployeeName = "233", Salary = "23333", SalaryColor = "yellow" };
            //vmEmp = "liuyd";
            EmployeeListViewModel listEmployee = new EmployeeListViewModel();
            List<EmployeeViewModel> listEmployeeViewModel = new List<EmployeeViewModel>();
            EmployeeBusinessLayer empBuss = new EmployeeBusinessLayer();
            List<Employee> employees = empBuss.GetEmployees();
            //if (employees.Count <= 0 || employees == null)
            //    return View("MyView");
            foreach (var employee in employees)
            {
                EmployeeViewModel empVm = new EmployeeViewModel();
                empVm.EmployeeName = string.Format(@"{0},{1}", employee.FirstName, employee.LastName);
                empVm.Salary = Convert.ToString(employee.Salary);
                if (employee.Salary > 1000)
                    empVm.SalaryColor = "yellow";
                else
                    empVm.SalaryColor = "bule";
                listEmployeeViewModel.Add(empVm);
            }
            listEmployeeViewModel.Add(vmEmp);
            listEmployeeViewModel.Add(vmEmp2);
            listEmployee.listEmployeeViewModel = listEmployeeViewModel;
            //listEmployee.UserName = "liuyd";

            return View("Index", listEmployee);
        }
        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }
        //public ActionResult SaveEmployee(Employee e,string BtnSubmit)
        //{

        //    if (BtnSubmit== "SaveEmployee")
        //    {
        //        return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
        //    }
        //    if (BtnSubmit == "Cancel")
        //    {
        //        return RedirectToAction("Index");
        //    }
        //    return new EmptyResult();
        //}
        //@* 如果控件名称与类属性名称不匹配会发生什么情况？ *@
        //    @* 三种解决方案*@
        //1.内部action 方法，获取请求中的post数据。Form 语法和手动构建Model对象
        //public ActionResult SaveEmployee()
        //{
        //    Employee e = new Employee();
        //    e.FirstName = Request["FName"];
        //    e.LastName = Request["LName"];
        //    e.Salary = Convert.ToInt32(Request["Salary"]);
        //    return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
        //}
        //2.使用参数名称和手动创建Model对象
        //public ActionResult SaveEmployee(string FName,string LName, int Salary)
        //{
        //    Employee e = new Employee();
        //    e.FirstName = FName;
        //    e.LastName = LName;
        //    e.Salary = Convert.ToInt32(Salary);
        //    return Content(e.FirstName + "|" + e.LastName + "|" + e.Salary);
        //}
        //3. 创建自定义Model Binder
        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {

            if (BtnSubmit == "SaveEmployee")
            {
                if(ModelState.IsValid)
                {
                    EmployeeBusinessLayer layer = new EmployeeBusinessLayer();
                    layer.SaveEmployee(e);
                    return RedirectToAction("Index");
                }
                else
                    {
                    return View("CreateEmployee");//转到试图
                }
              
            }
            if (BtnSubmit == "Cancel")
            {
                return RedirectToAction("Index");//重定向
            }
            return new EmptyResult();
        }
    }
}