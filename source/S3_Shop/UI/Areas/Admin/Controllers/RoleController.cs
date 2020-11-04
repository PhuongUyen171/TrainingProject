using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class RoleController : Controller
    {
        private ServiceRepository serviceObj;
        private string url;
        public RoleController()
        {
            url = "https://localhost:44379/api/Role_API/";
            serviceObj = new ServiceRepository();
        }
        // GET: Admin/Role
        public ActionResult Index()
        {
            try
            {
                HttpResponseMessage response = serviceObj.GetResponse(url + "GetAllRoles");
                response.EnsureSuccessStatusCode();
                List<Model.RoleModel> list = response.Content.ReadAsAsync<List<Model.RoleModel>>().Result;
                return View(list);
            }
            catch (Exception)
            {
                throw;
            }
        }
        //[HttpGet]  
        public ActionResult EditRole(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse(url+"GetDetailRole/" + id);
            response.EnsureSuccessStatusCode();
            Model.RoleModel role  = response.Content.ReadAsAsync<Model.RoleModel>().Result;
            return View(role);
        }
        //[HttpPost]  
        public ActionResult UpdateRole(Model.RoleModel role)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PutResponse("api/Role/UpdateRole/",role);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllRoles");
        }
        public ActionResult DetailRole(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.GetResponse(url+"GetDetailRole/" + id);
            response.EnsureSuccessStatusCode();
            Model.RoleModel role = response.Content.ReadAsAsync<Model.RoleModel>().Result;
            return View(role);
        }
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(Model.RoleModel role)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.PostResponse(url+"api/Role/InsertRole/", role);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllRoles");
        }
        public ActionResult Delete(int id)
        {
            ServiceRepository serviceObj = new ServiceRepository();
            HttpResponseMessage response = serviceObj.DeleteResponse(url+"DeleteRole/" + id);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("GetAllProducts");
        }
    }
}