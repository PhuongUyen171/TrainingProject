using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        string url;
        ServiceRepository serviceObj;
        public CategoryController()
        {
            serviceObj = new ServiceRepository();
            url = "https://localhost:44379/api/Category_API/";
        }
        public ActionResult Index()
        {
            try
            {
                HttpResponseMessage response = serviceObj.GetResponse(url + "GetAllCategories");
                response.EnsureSuccessStatusCode();
                List<Model.CategoryModel> list = response.Content.ReadAsAsync<List<Model.CategoryModel>>().Result;
                return View(list);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}