using System.Diagnostics;
using System.Net.NetworkInformation;
using Cook_Book.DataAccess;
using Cook_Book.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cook_Book.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult ViewHomePage()
        {

            return View();
        }

        public IActionResult ViewAbout()
        {
            return View();
        }

        public IActionResult GetLogInForm()
        {

            return View();
        }
     
        [HttpPost]
        public IActionResult LogIn(string username, string password)
        {
            ViewModelFactory viewModelFactory = new ViewModelFactory(new DB_Helper());
            UserData userData = viewModelFactory.LoginUser(username, password);

            if (userData == null)
            {
                ViewBag.LoginError = true;
                return View("GetLogInForm");
            }

            HttpContext.Session.SetString("UserId", userData.GetUserId());
            HttpContext.Session.SetString("UserName", userData.GetUserName());
            ViewBag.Login = HttpContext.Session.GetString("UserId") != null;
            return RedirectToAction("ViewUserHomePage", "User");
        }

        public IActionResult GetSignUpForm()
        {

            return View();
        }


        [HttpPost]
        public IActionResult SignUp(string userId, string userName, string userTel, string userEmail, string userPassword)
        {
            ViewModelFactory viewModelFactory = new ViewModelFactory(new DB_Helper());
            DB_Helper dbHelper = new DB_Helper();
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(userName) ||
                string.IsNullOrEmpty(userTel) ||
                string.IsNullOrEmpty(userEmail) ||
                string.IsNullOrEmpty(userPassword))
            {
                ViewBag.ErrorMessage = true;
                return View("GetSignUpForm");
            }

            User user = new User(userId,userName, userTel, userEmail, userPassword);
            string id=viewModelFactory.AddNewUser(user);


            if (id != null)
            {
                HttpContext.Session.SetString("UserId", userId);
                HttpContext.Session.SetString("UserName", userName);
                return RedirectToAction("ViewUserHomePage", "User");
            }
            else
            {
                ViewBag.SignUpError = true;
                return View("GetSignUpForm");
            }
        }
    }
}
