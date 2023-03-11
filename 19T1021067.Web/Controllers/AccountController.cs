using _19T1021067.BusinessLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace _19T1021067.Web.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit()
        {
           
            return View();
        }
        /// <summary>
        /// Trang dùng để đăng nhập vào hệ thống 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(string userName="",string password = "")
        {
            ViewBag.UserName = userName;
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Thông tin không đầy đủ");
                return View();
            }
            var userAccount = UserAccountService.Authorize(AccountTypes.Employee, userName, password);
            if (userAccount == null)
            {
                ModelState.AddModelError("", "Đăng nhập thất bại");
                return View();
            }
            //ghi cookie cho phiên đăng nhập 
            string cookiesString = Newtonsoft.Json.JsonConvert.SerializeObject(userAccount);
            FormsAuthentication.SetAuthCookie(cookiesString, false);
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        public ActionResult ChangePassword(string UserName, string oldPassword, string newPassword, string newPasswordAgain)
        {
            if (newPassword != newPasswordAgain)
            {
                ModelState.AddModelError("", "Mật khẩu xác nhận không đúng");
                return View("Edit");
            }
            bool changePass = UserAccountService.ChangePassword(AccountTypes.Employee, UserName, oldPassword, newPassword);

            if (changePass == false)
            {
                ModelState.AddModelError("", "Sai mật khẩu cũ");
                return View("Edit");
            }

            return RedirectToAction("Edit");
        }
    }
}