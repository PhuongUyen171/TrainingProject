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
            try
            {
                HttpResponseMessage response = serviceObj.GetResponse(url + "GetEmployeeInforByUsernamePassword/?user=" + user + "&pass=" + pass);
                response.EnsureSuccessStatusCode();
                Model.EmployeeModel resultLogin = response.Content.ReadAsAsync<Model.EmployeeModel>().Result;
                return View(resultLogin);
            }
            catch (Exception)
            {
                return View("Login");
            }
            
        }
        public ActionResult Logout()
        {
            try
            {
                Session.Remove("ADMIN_SESSION");
                if (Response.Cookies["username"] != null)
                {
                    HttpCookie ckUser = new HttpCookie("username");
                    ckUser.Expires = DateTime.Now.AddHours(-48);
                    Response.Cookies.Add(ckUser);
                }
                if (Response.Cookies["password"] != null)
                {
                    HttpCookie ckPass = new HttpCookie("password");
                    ckPass.Expires = DateTime.Now.AddHours(-48);
                    Response.Cookies.Add(ckPass);
                }
                return View("Login");
            }
            catch (Exception)
            {
                return View("Login"); 
            }
        }
        public ActionResult Login()
        {
            LoginModel model = CheckAccount();
            if (model == null)
                return View();
            else
            {
                Session["ADMIN_SESSION"] = model;
                return RedirectToAction("Index","Login",new { user=model.UserName,pass=model.Password});
            }
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = serviceObj.GetResponse(url + "GetEmployeeByUsernamePassword/?user=" + model.UserName + "&pass=" + model.Password);
                response.EnsureSuccessStatusCode();
                int resultLogin = response.Content.ReadAsAsync<int>().Result;
                switch (resultLogin)
                {
                    case 1:
                        {
                            HttpResponseMessage responseUser = serviceObj.GetResponse(url + "GetEmployeeByUsername?user=" + model.UserName);
                            responseUser.EnsureSuccessStatusCode();
                            Model.EmployeeModel employLogin = responseUser.Content.ReadAsAsync<Model.EmployeeModel>().Result;

                            var adSession = new LoginModel();
                            adSession.UserName = employLogin.EmployName;
                            adSession.Password = employLogin.Pass;
                            adSession.GroupID = employLogin.GroupID;

                            //Lấy list danh sách phân quyền
                            HttpResponseMessage responsePermision = serviceObj.GetResponse(url + "GetPermisionByUsername?name=" + model.UserName);
                            responsePermision.EnsureSuccessStatusCode();
                            List<int> listPermision = responsePermision.Content.ReadAsAsync<List<int>>().Result;
                            Session.Add(Constants.SESSION_CREDENTIALS, listPermision);

                            //Xử lý remember me
                            Session.Add(Constants.ADMIN_SESSION, adSession);
                            if (model.RememberMe)
                            {
                                HttpCookie ckUser = new HttpCookie("username");
                                ckUser.Expires = DateTime.Now.AddHours(48);
                                ckUser.Value = model.UserName;
                                Response.Cookies.Add(ckUser);
                                HttpCookie ckPass = new HttpCookie("password");
                                ckPass.Expires = DateTime.Now.AddHours(48);
                                ckPass.Value = model.Password;
                                Response.Cookies.Add(ckPass);
                            }
                            Constants.COUNT_LOGIN_FAIL_ADMIN = 0;
                            return RedirectToAction("Index", "Login", new { user = adSession.UserName, pass = adSession.Password });
                        }
                    case 0:
                        ModelState.AddModelError("", "Tài khoản không tồn tại.");
                        break;
                    case -1:
                        ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                        break;
                    case -2:
                        if (Constants.COUNT_LOGIN_FAIL_ADMIN == 3)
                        {
                            HttpResponseMessage responseUser = serviceObj.GetResponse(url + "GetEmployeeByUsername?user=" + model.UserName);
                            responseUser.EnsureSuccessStatusCode();
                            /*[HttpPost]
        //Không tác động thêm xóa sỬA
        public ActionResult UpdateRole(RoleModel role)
        {
            HttpResponseMessage response = serviceObj.PutResponse(url + "UpdateRole/", role);
            response.EnsureSuccessStatusCode();
            return RedirectToAction("Index");
        }*/
                            EmployeeModel employLogin = responseUser.Content.ReadAsAsync<EmployeeModel>().Result;
                            //Chưa gọn: rảnh xử lý cho gọn
                            if(UpdateStatusEmployee(employLogin))
                                ModelState.AddModelError("", "Đăng nhập sai quá 3 lần. Tài khoản bạn đã bị khóa.");
                            else
                                ModelState.AddModelError("", "Đăng nhập sai quá 3 lần. Tài khoản không khóa được");
                        }
                        else
                        {
                            Constants.COUNT_LOGIN_FAIL_ADMIN++;
                            ModelState.AddModelError("", "Mật khẩu không đúng.");
                        }
                        break;
                    default:
                        ModelState.AddModelError("", "Đăng nhập thất bại.");
                        break;
                }
            }
            return this.View();
        }
        [HttpPost]
        public bool UpdateStatusEmployee(EmployeeModel employLogin)
        {
            try
            {
                HttpResponseMessage responseBlock = serviceObj.PutResponse(url + "UpdateStatusEmployee/", employLogin);
                responseBlock.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }
        public LoginModel CheckAccount()
        {
            LoginModel result=null;
            string username = string.Empty;
            string password = string.Empty;
            if (Request.Cookies["username"] != null)
                username = Request.Cookies["username"].Value;
            if (Request.Cookies["password"] != null)
                password = Request.Cookies["password"].Value;
            if (!string.IsNullOrEmpty(username) & !string.IsNullOrEmpty(password))
                result = new LoginModel { UserName = username, Password = password};
            return result;
        }
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