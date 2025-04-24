using Microsoft.AspNetCore.Mvc;
using PureAirPro.Common;
using PureAirPro.DBContext;
using PureAirPro.DBContext.ViewModels;

namespace PureAirPro.Controllers
{
    public class SignUpController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }

        public IActionResult Login()
        {
            LoginViewModel loginViewModel = new LoginViewModel();
            return View("Login", loginViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> SignUpAsync(Users User)
        {
            if (User != null)
            {
                var context = new PureAirProWebContext();
                try
                {
                    context.Users.Add(User);
                    context.SaveChanges();
                    SMTPEmail sMTPmail = new SMTPEmail();
                    await sMTPmail.TaskSendEmail(User.Email,User.FirstName,User.LastName);
                    
                }
                catch (Exception ex)
                {

                }
            }
            return Json(true);
        }

        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            try
            {

                if (!string.IsNullOrEmpty(loginViewModel.Email) && (!string.IsNullOrEmpty(loginViewModel.PassWord)))
                {
                    SMTPEmail sMTPmail = new SMTPEmail();
                    var dbContext = new PureAirProWebContext();
                    var UserByEmail = dbContext.Users.Where(x => x.Email == loginViewModel.Email && x.UserPassWord == loginViewModel.PassWord).FirstOrDefault();
                    if (UserByEmail != null)
                    {
                        TempData["LoginUser"] = UserByEmail.FirstName + " " + UserByEmail.LastName;
                        TempData.Keep("LoginUser");
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Email", "Please enter valid email and password");
                        return View("Login", loginViewModel);
                    }
                }
                else
                {
                    ModelState.AddModelError("Email", "Please enter email and password");
                    return View("Login", loginViewModel);
                }
            }
            catch (Exception ex)
            {

            }
            return View("Login", loginViewModel);

        }

    }
}
