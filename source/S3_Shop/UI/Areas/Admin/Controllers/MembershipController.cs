using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class MembershipController : Controller
    {
        string url;
        ServiceRepository serviceObj;
        public MembershipController()
        {
            serviceObj = new ServiceRepository();
            url = "https://localhost:44379/api/Membership_API/";
        }
        public ActionResult Index()
        {
            try
            {
                HttpResponseMessage response = serviceObj.GetResponse(url + "GetAllMemberships");
                response.EnsureSuccessStatusCode();
                List<Model.MembershipModel> list = response.Content.ReadAsAsync<List<Model.MembershipModel>>().Result;
                return View(list);
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}