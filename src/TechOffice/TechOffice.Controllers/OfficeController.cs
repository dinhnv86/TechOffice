using AnThinhPhat.Services;
using AnThinhPhat.Utilities;
using Ninject;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using System.Web;
using System.Security.Claims;

namespace AnThinhPhat.WebUI.Controllers
{
    public class OfficeController : Controller
    {
        protected IAuthenticationManager AuthenticationManager
        {
            get
            {
                var ctx = Request.GetOwinContext();
                return ctx.Authentication;
            }
        }

        protected string UserName
        {
            get
            {
#if DEBUG
                return "admin";
#endif
                var claim = User as ClaimsPrincipal;
                if (claim != null)
                    return claim.FindFirst(ClaimTypes.Name).Value;
                else return string.Empty;
            }
        }

        protected JsonResult ExecuteWithErrorHandling(Func<JsonResult> action)
        {
            CheckModelState();

            if (action != null)
            {
                try
                {
                    return action();
                }
                catch (Exception ex)
                {
                    LogService.Error(ex);
                }
            }

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { code = "SB02" }
            };
        }

        protected async Task<JsonResult> ExecuteWithErrorHandling(Func<Task<JsonResult>> action)
        {
            CheckModelState();

            if (action != null)
            {
                try
                {
                    return await action();
                }
                catch (Exception ex)
                {
                    LogService.Error(ex);
                }
            }

            return new JsonResult()
            {
                JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                Data = new { code = "SB02" }
            };
        }

        protected async Task<JsonResult> ExecuteResultAsync(Func<Task<SaveResult>> func)
        {
            if (func == null)
                throw new Exception();

            var result = await func();

            switch (result)
            {
                case SaveResult.SUCCESS:
                    Response.StatusCode = (int)HttpStatusCode.OK;
                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SB01" }
                    };
                default:
                    return new JsonResult()
                    {
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                        Data = new { code = "SB02" }
                    };
            }
        }

        private void CheckModelState()
        {
            if (!ModelState.IsValid)
            {
                throw new ArgumentException();
            }
        }

        [Inject]
        public ILogService LogService { get; set; }
    }
}