using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvcinstance2.ViewModels
{
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> listEmployeeViewModel { get; set; }
        public string UserName { get; set; }
    }
}