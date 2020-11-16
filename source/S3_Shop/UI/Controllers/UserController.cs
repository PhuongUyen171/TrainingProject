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
using System.Net.Mail;
using System.Net;
using System.Net.Http.Formatting;
<<<<<<< HEAD
using UI.Models;
=======
using Facebook;
using System.Configuration;
using System.Web.Script.Serialization;
>>>>>>> feature/sprint-04

namespace UI.Controllers
{
    public class UserController : Controller
    {
        string url;
        ServiceRepository serviceObj;
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }
        public UserController()
        {
            serviceObj = new ServiceRepository();
            url = "https://localhost:44379/api/User_API/";
        }

        #region chức năng đăng nhập user
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

                            Session.Add(Constants.USER_SESSION, userSession);
                            //if (model.RememberMe)
                            //{
                            HttpCookie ckUserAccount = new HttpCookie("usernameCustomer");
                            ckUserAccount.Expires = DateTime.Now.AddHours(48);
                            ckUserAccount.Value = model.UserName;
                            Response.Cookies.Add(ckUserAccount);
                            HttpCookie ckPassAccount = new HttpCookie("passwordCustomer");
                            ckPassAccount.Expires = DateTime.Now.AddHours(48);
                            ckPassAccount.Value = model.Password;
                            Response.Cookies.Add(ckPassAccount);
                            //}
                            return RedirectToAction("ProfileUser", "User", new { custom=customLogin});
                        }
                    case 0:
                        ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không tồn tại.");
                        break;
                    default:
                        ModelState.AddModelError("", "Đăng nhập thất bại.");
                        break;
                }
            }
            return this.View();
        }
        public ActionResult Logout()
        {
            try
            {
<<<<<<< HEAD
                Session.Remove("USER_SESSION");
                //if (Response.Cookies["username"] != null)
                //{
                //    HttpCookie ckUser = new HttpCookie("username");
                //    ckUser.Expires = DateTime.Now.AddHours(-48);
                //    Response.Cookies.Add(ckUser);
                //}
                //if (Response.Cookies["password"] != null)
                //{
                //    HttpCookie ckPass = new HttpCookie("password");
                //    ckPass.Expires = DateTime.Now.AddHours(-48);
                //    Response.Cookies.Add(ckPass);
                //}
=======
                Session.Remove(Constants.USER_SESSION);
                if (Response.Cookies["usernameCustomer"] != null)
                {
                    HttpCookie ckUserAccount = new HttpCookie("usernameCustomer");
                    ckUserAccount.Expires = DateTime.Now.AddHours(-48);
                    Response.Cookies.Add(ckUserAccount);
                }
                if (Response.Cookies["passwordCustomer"] != null)
                {
                    HttpCookie ckPassAccount = new HttpCookie("passwordCustomer");
                    ckPassAccount.Expires = DateTime.Now.AddHours(-48);
                    Response.Cookies.Add(ckPassAccount);
                }
>>>>>>> feature/sprint-04
                Constants.COUNT_LOGIN_FAIL_USER = 0;
                return RedirectToAction("Index","Home");
            }
            catch (Exception)
            {
                return View("Login");
            }
        }
<<<<<<< HEAD
=======
        
>>>>>>> feature/sprint-04
        #endregion

        #region chức năng quên mật khẩu
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                string resetCode = Guid.NewGuid().ToString();
                var verifyUrl = "/User/ResetPassword?id=" + resetCode+"&mail="+model.Email;
                var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
                HttpResponseMessage response = serviceObj.GetResponse(url + "GetCustomerByEmail?mail=" + model.Email);
                response.EnsureSuccessStatusCode();
                CustomerModel result = response.Content.ReadAsAsync<CustomerModel>().Result;
                if (result != null)
                {
                    ResetPasswordModel resetModel = new ResetPasswordModel();
                    resetModel.ResetCode = resetCode;
                    resetModel.Id = result.CustomID;
                    //This line I have added here to avoid confirm password not match issue , as we had added a confirm password property
                    var subject = "Password Reset Request";
                    var body = "Hi " + result.CustomName + ", <br/> You recently requested to reset your password for your account. Click the link below to reset it. " +
                            " <br/><br/><a href='" + link + "'>" + link + "</a> <br/><br/>" +
                            "If you did not request a password reset, please ignore this email or reply to let us know.<br/><br/> Thank you";
                    SendEmail(result.Email, body, subject);
                    ModelState.AddModelError("", "Mã code đã được gửi vào email của bạn");
                }
                else
                    ModelState.AddModelError("", "Địa chỉ email không tồn tại.") ;
                return View();
            }
            return View();
        }
        private void SendEmail(string emailAddress, string body, string subject)
        {
            using (MailMessage mm = new MailMessage("mlem1701@gmail.com", emailAddress))
            {
                mm.Subject = subject;
                mm.Body = body;
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential("mlem1701@gmail.com", "ntpu1234");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
        }
        public CustomerModel GetCustomerByEmail(string mail)
        {
            HttpResponseMessage response = serviceObj.GetResponse(url + "GetCustomerByEmail?mail=" + mail);
            response.EnsureSuccessStatusCode();
            CustomerModel result = response.Content.ReadAsAsync<CustomerModel>().Result;
            return result;
        }
        public ActionResult ResetPassword(string id,string mail)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrEmpty(mail))
            {
                return View("~/Views/Shared/404.cshtml");
            }

            //using (var context = new LoginRegistrationInMVCEntities())
            //{
            //var user = context.RegisterUsers.Where(a => a.ResetPasswordCode == id).FirstOrDefault();
            //if (user != null)
            //{
            //HttpResponseMessage response = serviceObj.GetResponse(url + "GetCustomerByEmail?mail=" + mail);
            //response.EnsureSuccessStatusCode();
            CustomerModel result = GetCustomerByEmail(mail);
            ResetPasswordModel mode = new ResetPasswordModel();
            mode.Id = result.CustomID;
            mode.Mail = mail;
            mode.ResetCode = id;
            return View(mode);
                //}
                //else
                //{
                //     return View("~/Views/Shared/404.cshtml");
                //}
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResetPassword(ResetPasswordModel model)
        {
            CustomerModel resultReset = GetCustomerByEmail(model.Mail);
            resultReset.Pass = model.NewPassword;
            HttpResponseMessage responseUpdate = serviceObj.PutResponse(url + "UpdateCustomer", resultReset);
            responseUpdate.EnsureSuccessStatusCode();
            bool result= responseUpdate.Content.ReadAsAsync<bool>().Result;
            if (result)
                return RedirectToAction("Login");
            ViewBag.Warning = "Có lỗi xảy ra trong quá trình đặt lại mật khẩu.";
            return this.View();
        }
        #endregion

        #region chức năng đăng kí
        public ActionResult Signin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signin(RegisterModel model)
        {
            return this.View();
        }
        #endregion
<<<<<<< HEAD
=======

        #region đăng nhập bằng FB, GG
        public ActionResult LoginFacebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }
        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = ConfigurationManager.AppSettings["FbAppId"],
                client_secret = ConfigurationManager.AppSettings["FbAppSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code
            });


            var accessToken = result.access_token;
            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                // Get the user's information, like email, first name, middle name etc
                dynamic me = fb.Get("me?fields=first_name,middle_name,last_name,id,email");
                string email = me.email;
                string userName = me.email;
                string firstname = me.first_name;
                string middlename = me.middle_name;
                string lastname = me.last_name;

                var user = new CustomerModel();
                user.Email = email;
                user.Username = email;
                user.Statu = true;

                user.CustomName = firstname + " " + middlename + " " + lastname;
                //user.CreatedDate = DateTime.Now;


                var resultInsert = InsertByFacebook(user);
                if (resultInsert > 0)
                {
                    var userSession = new UserLogin();
                    userSession.UserName = email;
                    userSession.UserID = resultInsert;
                    Session.Add(Constants.USER_SESSION, userSession);

                    //if (model.RememberMe)
                    //{
                    HttpCookie ckUserAccount = new HttpCookie("usernameCustomer");
                    ckUserAccount.Expires = DateTime.Now.AddHours(48);
                    ckUserAccount.Value = email;
                    Response.Cookies.Add(ckUserAccount);
                    HttpCookie ckIDAccount = new HttpCookie("idCustomer");
                    ckIDAccount.Expires = DateTime.Now.AddHours(48);
                    ckIDAccount.Value = resultInsert.ToString();
                    Response.Cookies.Add(ckIDAccount);
                }
            }
            return Redirect("/");
        }
        [HttpPost]
        public JsonResult LoginGoogle(string googleACModel)
        {
            ViewBag.GoogleSignIn = ConfigurationManager.AppSettings["GgAppId"].ToString();
            var accountSocialsList = new JavaScriptSerializer().Deserialize<List<AccountSocial>>(googleACModel);
            var accountSocials = accountSocialsList.FirstOrDefault();
            var memberAccount = new CustomerModel();
            memberAccount.Email = accountSocials.Email;
            memberAccount.Username = accountSocials.Email;
            memberAccount.CustomName = accountSocials.FullName;
            var resultInsert = InsertByGoogle(memberAccount);

            CustomerModel model = new CustomerModel();
            model.CustomID = resultInsert;
            model.CustomName = accountSocials.FullName;
            model.Username = accountSocials.Email;

            Session.Remove(Constants.USER_SESSION);
            Session.Add(Constants.USER_SESSION, model);

            HttpCookie ckUserAccount = new HttpCookie("usernameCustomer");
            ckUserAccount.Expires = DateTime.Now.AddHours(48);
            ckUserAccount.Value = model.Username;
            Response.Cookies.Add(ckUserAccount);
            HttpCookie ckNameAccount = new HttpCookie("passwordCustomer");
            ckNameAccount.Expires = DateTime.Now.AddHours(48);
            ckNameAccount.Value = model.CustomName;
            Response.Cookies.Add(ckNameAccount);

            return Json(new { status = true });
        }
        #endregion
>>>>>>> feature/sprint-04
        public ActionResult ProfileUser(CustomerModel custom)
        {
            return View(custom);
        }
<<<<<<< HEAD
=======
        public int InsertByFacebook(CustomerModel customer)
        {
            HttpResponseMessage response = serviceObj.PostResponse(url + "InsertForFacebook/",customer);
            response.EnsureSuccessStatusCode();
            int resultInsert = response.Content.ReadAsAsync<int>().Result;
            return resultInsert;
        }
        public int InsertByGoogle(CustomerModel customer)
        {
            HttpResponseMessage response = serviceObj.PostResponse(url + "InsertForGoogle/", customer);
            response.EnsureSuccessStatusCode();
            int resultInsert = response.Content.ReadAsAsync<int>().Result;
            return resultInsert;
        }
>>>>>>> feature/sprint-04
    }
}