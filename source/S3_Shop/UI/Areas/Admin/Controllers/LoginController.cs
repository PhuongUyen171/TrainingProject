using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using API.Models;
using System.Net.Http;
using UI.Models;
using Model.Common;

namespace UI.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        string url;
        ServiceRepository serviceObj;
        public LoginController()
        {
            serviceObj = new ServiceRepository();
            url = "https://localhost:44379/api/Employee_API/";
        }
        public ActionResult Index(string user, string pass)
        {
            HttpResponseMessage response = serviceObj.GetResponse(url + "GetEmployeeInforByUsernamePassword/?user=" + user + "&pass=" + pass);
            response.EnsureSuccessStatusCode();
            Model.EmployeeModel resultLogin = response.Content.ReadAsAsync<Model.EmployeeModel>().Result;
            return View(resultLogin);
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = serviceObj.GetResponse(url + "GetEmployeeByUsernamePassword/?user="+model.UserName+"&pass="+model.Password);
                response.EnsureSuccessStatusCode();
                int resultLogin= response.Content.ReadAsAsync<int>().Result;
                if (resultLogin == 1)
                {
                    HttpResponseMessage responseUser = serviceObj.GetResponse(url + "GetEmployeeByUsername?user=" + model.UserName);
                    responseUser.EnsureSuccessStatusCode();
                    Model.EmployeeModel employLogin = responseUser.Content.ReadAsAsync<Model.EmployeeModel>().Result;
   
                    var adSession = new LoginModel();
                    adSession.UserName = employLogin.EmployName;
                    adSession.Password = employLogin.Pass;

                    //Chưa xử lý remember me
                    //userSession.RememberMe = user.RememberMe;
                    //var listCredentials = dao.GetListCredential(model.UserName);
                    //Session.Add(Constants.SESSION_CREDENTIALS, listCredentials);

                    Session.Add(Constants.ADMIN_SESSION, adSession);
                    Constants.COUNT_LOGIN_FAIL_ADMIN = 0;
                    return RedirectToAction("Index", "Login", new { user = adSession.UserName, pass = adSession.Password });
                }
                else if(resultLogin==0)
                    ModelState.AddModelError("", "Tài khoản không tồn tại.");
                else if(resultLogin==-1)
                    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                else if (resultLogin == -2)
                {
                    if(Constants.COUNT_LOGIN_FAIL_ADMIN==3)
                    {
                        HttpResponseMessage responseUser = serviceObj.GetResponse(url + "GetEmployeeByUsername?user=" + model.UserName);
                        responseUser.EnsureSuccessStatusCode();
                        Model.EmployeeModel employLogin = responseUser.Content.ReadAsAsync<Model.EmployeeModel>().Result;
                        //Chưa gọn: rảnh xử lý cho gọn
                        HttpResponseMessage responseBlock = serviceObj.PutResponse(url + "UpdateStatusEmployee/", employLogin);
                        responseBlock.EnsureSuccessStatusCode();
                        ModelState.AddModelError("", "Đăng nhập sai quá 3 lần. Tài khoản bạn đã bị khóa.");
                    }
                    else
                    {
                        Constants.COUNT_LOGIN_FAIL_ADMIN++;
                        ModelState.AddModelError("", "Mật khẩu không đúng.");
                    }
                }
                else
                    ModelState.AddModelError("", "Đăng nhập thất bại.");
            }   
            return this.View();
            //{
            //    var dao = new customerdaL();
            //    var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.Password), true);
            //    if (result == 1)
            //    {
            //        var user = dao.GetById(model.UserName);
            //        var userSession = new UserLogin();
            //        userSession.UserName = user.UserName;
            //        userSession.UserID = user.ID;
            //        userSession.GroupID = user.GroupID;
            //        var listCredentials = dao.GetListCredential(model.UserName);

            //        Session.Add(CommonConstants.SESSION_CREDENTIALS, listCredentials);
            //        Session.Add(CommonConstants.USER_SESSION, userSession);
            //        return RedirectToAction("Index", "Home");
            //    }
            //    else if (result == 0)
            //    {
            //        ModelState.AddModelError("", "Tài khoản không tồn tại.");
            //    }
            //    else if (result == -1)
            //    {
            //        ModelState.AddModelError("", "Tài khoản đang bị khoá.");
            //    }
            //    else if (result == -2)
            //    {
            //        ModelState.AddModelError("", "Mật khẩu không đúng.");
            //    }
            //    else if (result == -3)
            //    {
            //        ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập.");
            //    }
            //    else
            //    {
            //        ModelState.AddModelError("", "đăng nhập không đúng.");
            //    }
            //}
            //return View("Index");
        }
    }
}