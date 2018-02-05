using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using mvcinstance2.ViewModels;

namespace mvcinstance2.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        // DataAnnotations 装饰属性
        //[Required(ErrorMessage ="Enter First Name")]
        [FirstNameValidation]
        public string FirstName { get; set; }
        [StringLength(5,ErrorMessage ="长度不能超过5")]
        public string LastName { get; set; }
        public int  Salary { get; set; }
    }
}