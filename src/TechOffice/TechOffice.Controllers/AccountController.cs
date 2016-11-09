using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.ViewModel.Users;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AnThinhPhat.WebUI.Controllers
{
    public class AccountController : OfficeController
    {
        /// <summary>
        /// Logs the in.
        /// </summary>
        /// <param name="ReturnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public ActionResult LogIn(string ReturnUrl)
        {
            var userLogin = new UserLoginViewModel()
            {
                ReturnUrl = ReturnUrl
            };

            return View(userLogin);
        }

        /// <summary>
        /// Logins the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        public async Task<ActionResult> Login(UserLoginViewModel user)
        {
            if (!ModelState.IsValid)
                return View(user);

            if (ModelState.IsValid)
            {
                //1. check user as status?
                var checkUser = UserRepository.CheckUserName(user.UserName);
                if (checkUser != null)
                {
                    if (checkUser.IsLocked)
                    {
                        ModelState.AddModelError("Locked", "Your account is currently locked. Please contact System Administrator!");
                        return View(user);
                    }

                    var userLogin = await UserRepository.LoginAsync(user.UserName, user.Password);
                    if (userLogin != null)
                    {
                        //Get all role of current user login
                        var userRoleInfo = UserRoleRepository.GetRolesByUserId(userLogin.Id);
                        var roles = userRoleInfo.Select(x => x.RoleInfo.Name).Aggregate((current, next) => current + "," + next);
                        var identities = new ClaimsIdentity(new[] {
                        new Claim(ClaimTypes.Name,userLogin.UserName),
                        new Claim(ClaimTypes.Role,roles),
                        new Claim(ClaimTypes.Email, user.UserName),},
                        "ApplicationCookie", ClaimTypes.Name, ClaimTypes.Role);
                        AuthenticationManager.SignIn(identities);

                        return Redirect(GetRedirectUrl(user.ReturnUrl));
                    }
                    else
                    {
                        ModelState.AddModelError("", "Login data is incorrect or User is not yet allowed. Contact System Administrator!");
                        return View(user);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect or User is not yet allowed. Contact System Administrator!");
                    return View(user);
                }
            }
            return View();
        }

        #region Inject
        /// <summary>
        /// Gets or sets the user repository.
        /// </summary>
        /// <value>
        /// The user repository.
        /// </value>
        [Inject]
        public IUsersRepository UserRepository { get; set; }

        public IUserRoleRepository UserRoleRepository { get; set; }

        #endregion

        /// <summary>
        /// Gets the redirect URL.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        private string GetRedirectUrl(string returnUrl)
        {
            if (String.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                var user = User;
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }
    }
}
