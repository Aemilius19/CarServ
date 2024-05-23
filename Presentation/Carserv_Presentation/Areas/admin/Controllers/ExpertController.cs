using Carserv_Application;
using Carserv_Domain;
using Carserv_Domain.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.OleDb;
using System.IO;

namespace Carserv_Presentation.Areas.admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "Admin")]
    public class ExpertController : Controller
    {
        IExpertService _service;
        private readonly IWebHostEnvironment environment;

        public ExpertController(IExpertService service, IWebHostEnvironment environment)
        {
            _service = service;
            this.environment = environment;
        }

        public IActionResult Index()
        {
            return View(_service.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ExpertSliderVM slidervm)
        {
            if (!ModelState.IsValid) { return View(); }
            if (!slidervm.ImgFIle.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImgFIle", "Must be image type");
                return View();
            }
            string path = environment.WebRootPath + @"\admin\upload\experts\";
            string filename = slidervm.ImgFIle.FileName;
            string fullpath = Path.Combine(path, filename);
            using (FileStream stream = new FileStream(fullpath, FileMode.Create))
            {
                slidervm.ImgFIle.CopyTo(stream);
                _service.Create(slidervm);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {

            return View();
        }
        [HttpPost]
        public IActionResult Update(ExpertSliderVM expertSliderVM)
        {
            if (!ModelState.IsValid) { return View(); }
            if (!expertSliderVM.ImgFIle.ContentType.Contains("image/"))
            {
                ModelState.AddModelError("ImgFIle", "Must be image type");
                return View();
            }
            var old=_service.Get(expertSliderVM.ID);
            string path = environment.WebRootPath + @"\admin\upload\experts\";
            string filename = expertSliderVM.ImgFIle.FileName;
            string fullpath = Path.Combine(path, filename);
            FileInfo fileinfo = new FileInfo(path + old.ImgURl);
            if (fileinfo.Exists) { fileinfo.Delete(); }
            using (FileStream stream = new FileStream(fullpath, FileMode.Create))
            {
                expertSliderVM.ImgFIle.CopyTo(stream);
                _service.Update(expertSliderVM);
            }
            return RedirectToAction("Index");
        }
    }
}
