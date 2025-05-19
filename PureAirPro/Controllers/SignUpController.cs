using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using PureAirPro.Common;
using PureAirPro.DBContext;
using PureAirPro.DBContext.ViewModels;
using System.Security.Claims;

namespace PureAirPro.Controllers
{
	public class SignUpController : Controller
	{
		private readonly PureAirProWebContext _context;

		public SignUpController(PureAirProWebContext context)
		{
			_context = context;
		}

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
				try
				{
					_context.Users.Add(User);
					_context.SaveChanges();
					SMTPEmail sMTPmail = new SMTPEmail();
					await sMTPmail.TaskSendEmail(User.Email, User.FirstName, User.LastName);

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
					var UserByEmail = _context.Users.Where(x => x.Email == loginViewModel.Email && x.UserPassWord == loginViewModel.PassWord).FirstOrDefault();
					if (UserByEmail != null)
					{
						TempData["LoginUser"] = UserByEmail.FirstName + " " + UserByEmail.LastName;
						TempData.Keep("LoginUser");
						var claims = new List<Claim>{
								new Claim(ClaimTypes.Name, loginViewModel.Email)
						};

						var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
						var principal = new ClaimsPrincipal(identity);

						await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
						return RedirectToAction("Index", "Home");
					}
					else
					{
						ModelState.AddModelError("UserErrorMessage", "Please enter valid email and password");
						return View("Login", loginViewModel);
					}
				}
				else
				{
					ModelState.AddModelError("UserErrorMessage", "Please enter email and password");
					return View("Login", loginViewModel);
				}
			}
			catch (Exception ex)
			{

			}
			return View("Login", loginViewModel);

		}

		[HttpPost]
		public async Task<IActionResult> LogoutAsync()
		{
			try
			{
				await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			}
			catch (Exception ex)
			{

			}
			return RedirectToAction("Login");
		}

	}
}
