using AnThinhPhat.Entities.Results;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.ViewModel.Users;
using Ninject;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace AnThinhPhat.WebUI.Controllers
{
    public class AccountController : OfficeController
    {
        /// <summary>
        ///     Logs the in.
        /// </summary>
        /// <param name="ReturnUrl">The return URL.</param>
        /// <returns></returns>
        [HttpGet, AllowAnonymous]
        public ActionResult LogIn(string ReturnUrl)
        {
            var userLogin = new UserLoginViewModel
            {
                ReturnUrl = ReturnUrl
            };

            return View(userLogin);
        }

        /// <summary>
        ///     Logins the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns></returns>
        [HttpPost, AllowAnonymous]
        public ActionResult Login(UserLoginViewModel user)
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
                        ModelState.AddModelError("Locked", Resources.Messages.Account_Login_Locked);
                        return View(user);
                    }

                    var userLogin = UserRepository.Login(user.UserName, user.Password);
                    if (userLogin != null)
                    {
                        //Get all role of current user login
                        var userRoleInfo = UserRoleRepository.GetRolesByUserId(userLogin.Id);

                        var roles = GetRolesOfUser(userRoleInfo, userLogin);

                        var identities = new ClaimsIdentity(new[]
                        {
                            new Claim(ClaimTypes.NameIdentifier,userLogin.Id.ToString()),
                            new Claim(ClaimTypes.Name, userLogin.UserName),
                            new Claim(ClaimTypes.Surname, userLogin.HoVaTen)
                        }.Concat(roles), "ApplicationCookie", ClaimTypes.Name, ClaimTypes.Role);

                        AuthenticationManager.SignIn(identities);

                        return Redirect(GetRedirectUrl(user.ReturnUrl));
                    }
                    ModelState.AddModelError("", Resources.Messages.Account_Login_Incorrect);
                    return View(user);
                }
                ModelState.AddModelError("", Resources.Messages.Account_Login_Incorrect);
                return View(user);
            }
            return View();
        }

        [HttpPost, Authorize]
        public ActionResult LogOut()
        {
            AuthenticationManager.SignOut("ApplicationCookie");

            return RedirectToRoute(UrlLink.TRANGCHU);
        }
        /// <summary>
        ///     Gets the redirect URL.
        /// </summary>
        /// <param name="returnUrl">The return URL.</param>
        /// <returns></returns>
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                var user = User;
                return Url.Action("Index", "Home");
            }

            return returnUrl;
        }

        private IEnumerable<Claim> GetRolesOfUser(IEnumerable<UserRoleResult> userRole, UserResult user)
        {
            var role = userRole.Select(x => new Claim(ClaimTypes.Role, x.RoleInfo.Name)).ToList();

            //Get co quan of user
            if (user.CoQuanId == TechOfficeConfig.IDENTITY_PHONGNOIVU)
                role.Add(new Claim(ClaimTypes.Role, RoleConstant.PHONGNOIVU));

            //Get chuc vu of user
            if (user.ChucVuId == TechOfficeConfig.IDENTITY_LANHDAO)
                role.Add(new Claim(ClaimTypes.Role, RoleConstant.LANHDAO));

            return role;
        }

        #region Inject

        [Inject]
        public IUserRoleRepository UserRoleRepository { get; set; }

        #endregion
    }
}