using System.Data;
using Cook_Book.DataAccess;
using Cook_Book.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cook_Book.Controllers
{
    public class UserController : Controller
    {
        public IActionResult ViewUserHomePage()
        {
            var userName = HttpContext.Session.GetString("UserName");

            if (string.IsNullOrEmpty(userName))
            {
                return RedirectToAction("GetLogInForm", "Home");
            }
            ViewBag.Login = HttpContext.Session.GetString("UserId") != null;
            return View();
        }

        public IActionResult ViewAllRecipes()
        {
            var viewModelFactory = new ViewModelFactory(new DB_Helper());
            CookBookViewModel cookBookViewModel = viewModelFactory.GetAllRecieps();
            ViewBag.Login = HttpContext.Session.GetString("UserId") != null;
            return View(cookBookViewModel);
        }


        public IActionResult GetOwnRecipeForm()
        {
            ViewBag.Login = HttpContext.Session.GetString("UserId") != null;
            return View();
        }

        // הפעולה שהייתה חסרה לך ב-Controller:
        public IActionResult GetOwnRecipes()
        {
            string currentUserId = HttpContext.Session.GetString("UserId");

            if (currentUserId != null)
            {
                var viewModelFactory = new ViewModelFactory(new DB_Helper());
                CookBookViewModel userRecipes = viewModelFactory.GetRecipesByUserId(currentUserId);
                ViewBag.Login = true;

                return View("ViewAllRecipes", userRecipes);
            }

            return RedirectToAction("GetLogInForm", "Home");
        }

        [HttpPost]
        public IActionResult AddOwnRecipe(string DishPhoto, string PreperationMethod, string RecipesName, int CatId)
        {
            string currentUserId = HttpContext.Session.GetString("UserId");

            if (currentUserId != null)
            {
                if (string.IsNullOrEmpty(RecipesName) || string.IsNullOrEmpty(PreperationMethod) || string.IsNullOrEmpty(DishPhoto))
                {
                    TempData["ErrorMessage"] = "All fields are required.";
                    return RedirectToAction("GetOwnRecipeForm", "User");
                }

                var viewModelFactory = new ViewModelFactory(new DB_Helper());

                Recipes recipe = new Recipes(DishPhoto, PreperationMethod, currentUserId, RecipesName, CatId);

                bool cookBookViewModel = viewModelFactory.AddNewRecipes(recipe);
                if (cookBookViewModel)
                {
                    return RedirectToAction("GetOwnRecipes", "User");
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to add the recipe. Please try again.";
                    return RedirectToAction("GetOwnRecipeForm", "User");
                }
            }

            return RedirectToAction("GetLogInForm", "Home");
        }

        public IActionResult ViewUserAbout()
        {
            return View();
        }
        public IActionResult DeleteAccount()
        {
            string currentUserId = HttpContext.Session.GetString("UserId");

            if (currentUserId != null)
            {
                var viewModelFactory = new ViewModelFactory(new DB_Helper());

                bool isDeleted = viewModelFactory.DeleteUser(currentUserId);

                if (isDeleted)
                {
                    HttpContext.Session.Clear();
                    return RedirectToAction("GetLogInForm", "Home");
                }
                else
                {
                    TempData["ErrorMessage"] = "Failed to delete account. Please try again.";
                    return RedirectToAction("ViewUserHomePage", "User");
                }
            }

            return RedirectToAction("GetLogInForm", "Home");
        }
        public IActionResult ViewRecipeDetails(string name)
        {
            var viewModelFactory = new ViewModelFactory(new DB_Helper());
            Recipes recipe = viewModelFactory.GetRecipeByName(name);

            if (recipe == null)
            {
                return RedirectToAction("ViewAllRecipes");
            }

            return View(recipe);
        }
    }
}
