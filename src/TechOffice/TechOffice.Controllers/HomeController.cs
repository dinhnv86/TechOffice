using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnThinhPhat.Services.Abstracts;
using AnThinhPhat.Utilities;
using AnThinhPhat.Utilities.Mail;
using AnThinhPhat.ViewModel;
using AnThinhPhat.ViewModel.Home;
using CaptchaMvc.HtmlHelpers;
using Ninject;
using PagedList;

namespace AnThinhPhat.WebUI.Controllers
{
    [AllowAnonymous]
    public class HomeController : OfficeController
    {
        [Inject]
        public INewsRepository NewsRepository { get; set; }

        [Inject]
        public INewsCategoryRepository NewsCategoryRepository { get; set; }

        public ActionResult Index(int? newsCategoryId)
        {
            return View(newsCategoryId);
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactViewModel model, HttpPostedFileBase files)
        {
            var xacNhan = this.IsCaptchaValid("Mã xác nhận không hợp lệ");
            if (!xacNhan)
            {
                ModelState.AddModelError("", "Mã xác nhận không hợp lệ");
            }
            MailSender.SendFeedback(model.Email, model.Title, model.NoiDung, new[]
            {
                new MailAttachment(ReadFully(files.InputStream), files.FileName)
            });

            return View();
        }

        public ActionResult Article()
        {
            return View();
        }

        public ActionResult ReadNews(int id)
        {
            var model = NewsRepository.Single(id).ToViewModel();
            return View(model);
        }

        public PartialViewResult News(int? newsCategoryId, int? page)
        {
            var items = newsCategoryId != null
                ? NewsRepository.GetAllByNewsCategoryId(newsCategoryId.Value).Select(x => x.ToViewModel())
                : NewsRepository.GetAll().Where(x => !x.IsDeleted).Select(x => x.ToViewModel());

            return PartialView("~/Views/Home/_News.cshtml", items.ToPagedList(page ?? 1, TechOfficeConfig.PAGESIZE));
        }

        public PartialViewResult MenuDanhMuc()
        {
            var model = NewsCategoryRepository.GetAll().Select(x => x.ToDataViewModel());
            return PartialView("~/Views/Shared/Menu/_MenuDanhMuc.cshtml", model);
        }

        public static MemoryStream ReadFully(Stream input)
        {
            var buffer = new byte[16*1024];
            using (var ms = new MemoryStream())
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