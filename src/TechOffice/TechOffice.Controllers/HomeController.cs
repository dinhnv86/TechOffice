using AnThinhPhat.Utilities.Mail;
using AnThinhPhat.ViewModel.Home;
using CaptchaMvc.HtmlHelpers;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace AnThinhPhat.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : OfficeController
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model, HttpPostedFileBase files)
        {
            bool xacNhan = this.IsCaptchaValid("Mã xác nhận không hợp lệ");
            if (!xacNhan)
            {
                ModelState.AddModelError("", "Mã xác nhận không hợp lệ");
            }
            MailSender.SendFeedback(model.Email, model.Title, new Utilities.MailAttachment[]
            {
                new Utilities.MailAttachment(ReadFully(files.InputStream), files.FileName)
            });

            return View();
        }

        public ActionResult Article()
        {
            return View();
        }

        public static MemoryStream ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms;
            }
        }
    }
}