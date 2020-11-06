using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using Model;

namespace API.Areas.Admin.Controllers
{
    public class Employee_APIController : ApiController
    {
        private EmployeeBLL empBLL = new EmployeeBLL();
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        [HttpGet]
        public List<Model.EmployeeModel> GetAllEmployees()
        {
            return empBLL.GetAllEmployees();
        }
        public int GetEmployeeByUsernamePassword(string user, string pass)
        {
            return empBLL.LoginEmployee(user, pass);
        }
        public Model.EmployeeModel GetEmployeeByUsername(string user)
        {
            return empBLL.GetEmployeeByUsername(user);
        }
        public Model.EmployeeModel GetEmployeeInforByUsernamePassword(string user, string pass)
        {
            return empBLL.GetEmployeeInforByUsernamePassword(user, pass);
        }
        [HttpPut]
        public bool UpdateStatusEmployee(EmployeeModel user)
        {
            return empBLL.UpdateStatusEmployee(user);
        }
    }
}
