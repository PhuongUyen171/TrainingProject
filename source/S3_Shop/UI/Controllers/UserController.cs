using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using UI.Models;
using Model;
using Model.Common;
using WebMatrix.WebData;

namespace UI.Controllers
{
    public class UserController : Controller
    {
        string url;
        ServiceRepository serviceObj;
        //public ActionResult Index()
        //{
        //    return View();
        //}
        public UserController()
        {
            serviceObj = new ServiceRepository();
            url = "https://localhost:44379/api/User_API/";
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin model)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage response = serviceObj.GetResponse(url + "GetLoginResultByUsernamePassword?user=" + model.UserName + "&pass=" + model.Password);
                response.EnsureSuccessStatusCode();
                int resultLogin = response.Content.ReadAsAsync<int>().Result;
                switch (resultLogin)
                {
                    case 1:
                        {
                            HttpResponseMessage responseUser = serviceObj.GetResponse(url + "GetCustomerByUsername?user=" + model.UserName);
                            responseUser.EnsureSuccessStatusCode();
                            CustomerModel customLogin = responseUser.Content.ReadAsAsync<CustomerModel>().Result;

                            var userSession = new UserLogin();
                            userSession.UserName = customLogin.Username;
                            userSession.Password = customLogin.Pass;

                            //Chưa xử lý quên mật khẩu
                            Session.Add(Constants.USER_SESSION, userSession);
                            //if (model.RememberMe)
                            //{
                            //    HttpCookie ckUser = new HttpCookie("username");
                            //    ckUser.Expires = DateTime.Now.AddHours(48);
                            //    ckUser.Value = model.UserName;
                            //    Response.Cookies.Add(ckUser);
                            //    HttpCookie ckPass = new HttpCookie("password");
                            //    ckPass.Expires = DateTime.Now.AddHours(48);
                            //    ckPass.Value = model.Password;
                            //    Response.Cookies.Add(ckPass);
                            //}
                            //Constants.COUNT_LOGIN_FAIL_ADMIN = 0;
                            return RedirectToAction("Index", "User");
                        }
                    case 0:
                        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không tồn tại.");
                        break;
                    //case -1:
                    //    ModelState.AddModelError("", "Tài khoản đang bị khoá.");
                    //    break;
                    //case -2:
                    //    ModelState.AddModelError("", "Mật khẩu không đúng.");
                    //    break;
                    //case -3:
                    //    ModelState.AddModelError("", "Đăng nhập sai quá 3 lần. Tài khoản bạn đã bị khóa.");
                    //    break;
                    default:
                        ModelState.AddModelError("", "Đăng nhập thất bại.");
                        break;
                }
            }
            return this.View();
        }
        public ActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signin(RegisterModel model)
        {
            return this.View();
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                //if (WebSecurity.UserExists(model.Email))
                //{
                //    string To = model.Email, UserID, Password, SMTPPort, Host;
                //    string token = WebSecurity.GeneratePasswordResetToken(model.Email);
                //    if (token == null)
                //    {
                //        // If user does not exist or is not confirmed.  
                //        return View("Index");
                //    }
                //    else
                //    {
                //        //Create URL with above token
                //        var lnkHref = "<a href='" + Url.Action("ResetPassword", "Account", new { email = model.Email, code = token }, "http") + "'>Reset Password</a>";


                //        //HTML Template for Send email
                //        string subject = "Your changed password";
                //        string body = "<b>Please find the Password Reset Link. </b><br/>" + lnkHref;

                //        //Get and set the AppSettings using configuration manager.  
                //        EmailManager.AppSettings(out UserID, out Password, out SMTPPort, out Host);

                //        //Call send email methods.  
                        EmailManager.SendPasswordResetEmail(model.Email,"you",);
                //    }
                //}
            }
            return View();
        }
    }
}