using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities.Mail;
using AnThinhPhat.ViewModel;
using AnThinhPhat.ViewModel.Home;
using CaptchaMvc.HtmlHelpers;
using Ninject;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Collections;
using AnThinhPhat.ViewModel.News;
using PagedList;
using System.Collections.Generic;
using AnThinhPhat.Utilities;

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
            MailSender.SendFeedback(model.Email, model.Title, model.NoiDung, new MailAttachment[]
            {
                new MailAttachment(ReadFully(files.InputStream), files.FileName)
            });

            return View();
        }

        public ActionResult Article()
        {
            return View();
        }

        public PartialViewResult News(int? newsCategoryId, int? page)
        {
            IEnumerable<AddNewsViewModel> items;

            if (newsCategoryId != null)
                items = NewsRepository.GetAllByNewsCategoryId(newsCategoryId.Value).Select(x => x.ToViewModel());
            else
                items = NewsRepository.GetAll().Select(x => x.ToViewModel());

            return PartialView("~/Views/Home/_News.cshtml",items.ToPagedList(page ?? 1, TechOfficeConfig.PAGESIZE));
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

        [Inject]
        public INewsRepository NewsRepository { get; set; }
    }
}