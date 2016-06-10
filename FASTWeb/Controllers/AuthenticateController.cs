using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FASTWeb.Models.Authenticate;
using FASTService.Enum;
using FASTService.Model;
using FASTService.Process;
using System.Web.Security;
using RestSharp;

namespace FASTWeb.Controllers
{
    public class AuthenticateController : Controller
    {
        //
        // GET: /Authenticate/
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        //TODO : Added just to create a login view. Change this if needed
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginCredentialModel loginCredentials)
        {
            AuthenticateProcess authenticate = new AuthenticateProcess();
            if (ModelState.IsValid)
            {

                var loginStatus = authenticate.ValidateLogin(loginCredentials.Username, loginCredentials.Password);
                if (loginStatus == LoginStatus.Successful)
                {
                    // set the forms auth cookie
                    FormsAuthentication.SetAuthCookie(loginCredentials.Username.ToString(), false);

                    // reset request.isauthenticated
                    var authCookie = System.Web.HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                    if (authCookie != null)
                    {
                        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                        if (authTicket != null && !authTicket.Expired)
                        {
                            var roles = authTicket.UserData.Split(',');
                            System.Web.HttpContext.Current.User = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);
                        }
                    }

                    return RedirectToAction("MyAssets", "Employee");
                }
                else
                {
                    ModelState.AddModelError("", "Wrong Employee Employee ID or Password");
                }
            }
            return View();
        }

        //TODO : Added just to create a login view. Change this if needed
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(RegistrationModel registrationModel)
        {
        
            var client = new RestClient("http://localhost:8090/api/User/Registration");
            var request = new RestRequest();
            string body=String.Format("{{'EmployeeID':{0}}}",registrationModel.EmployeeID.ToString());
            request.Method = Method.POST;
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;

            TempData["Result"] = content.Replace('"',' ').Trim();
            TempData["Source"] = "User Registration";
            
            return View("~/Views/Shared/Result.cshtml");
        }

        //TODO : Added just to create a login view. Change this if needed
        [AllowAnonymous]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult ChangePassword(ChangePasswordModel changePasswordModel)
        {
            FASTService.Process.AuthenticateProcess authProcess= new AuthenticateProcess();
            var client = new RestClient("http://localhost:8090/api/User/ChangePassword");
            var request = new RestRequest();
            string body = String.Format("{{'EmployeeID':{0},'HashedOldPassword':'{1}','HashedNewPassword':'{2}'}}",
                                          changePasswordModel.Username.ToString(),
                                          authProcess.HashString(changePasswordModel.OldPassword),
                                          authProcess.HashString(changePasswordModel.NewPassword));

            request.Method = Method.PUT;
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;

            TempData["Result"] = content.Replace('"', ' ').Trim();
            TempData["Source"] = "Change Password";

            return View("~/Views/Shared/Result.cshtml");
        }

        [Authorize]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Authenticate");
        }

        [AllowAnonymous]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult ResetPassword(RegistrationModel resetModel)
        {
            var client = new RestClient("http://localhost:8090/api/User/ResetPassword");
            var request = new RestRequest();
            string body = String.Format("{{'EmployeeID':{0}}}", resetModel.EmployeeID.ToString());
            request.Method = Method.PUT;
            request.AddHeader("Accept", "application/json");
            request.Parameters.Clear();
            request.AddParameter("application/json", body, ParameterType.RequestBody);

            var response = client.Execute(request);
            var content = response.Content;

            TempData["Result"] = content.Replace('"', ' ').Trim();
            TempData["Source"] = "Reset Password";

            return View("~/Views/Shared/Result.cshtml");
        }

	}
}