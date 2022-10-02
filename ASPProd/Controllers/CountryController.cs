using ASPProd.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace ASPProd.Controllers
{
    public class CountryController : Controller
    {
        private ApplicationContext _db;
        private IWebHostEnvironment _appEnvironment;
        public CountryController(ApplicationContext db, IWebHostEnvironment appEnvironment)
        {
            _db = db;
            _appEnvironment = appEnvironment;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(PlaceViewModel plcViewModel)
        {
            if (plcViewModel != null)
            {
                string path;
                if (plcViewModel.Image != null)
                    path = $@"/images/{plcViewModel.Image.FileName}";
                else
                    path = "";
                string fullPath = _appEnvironment.WebRootPath + path;

                Directory.CreateDirectory(Path.GetDirectoryName(fullPath)!);
                if (plcViewModel.Image != null)
                {
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await plcViewModel.Image.CopyToAsync(fileStream);
                    }
                }

                Place adv = new Place
                {
                    Name = plcViewModel.Name,
                    Language = plcViewModel.Language,
                    Information = plcViewModel.Information,
                    Image = path,
                };
                _db.Places.Add(adv);
                _db.SaveChanges();
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
