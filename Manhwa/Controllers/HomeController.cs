using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Manhwa.Models;

namespace Manhwa.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Url"] = HttpContext.Request.Path;

            var model = new HomepageModel();

            return View(model);
        }

        public IActionResult Series()
        {
            ViewData["Url"] = HttpContext.Request.Path;

            return View();
        }

        public IActionResult Chapters(string series)
        {
            ViewData["Url"] = HttpContext.Request.Path;

            var model = new ChapterPageModel
            {
                Series = series.ToLower()
            };

            return View(model);
        }

        public IActionResult Reader(string series, int chapter)
        {
            ViewData["Url"] = HttpContext.Request.Path;

            var model = new ReaderPageModel
            {
                Series = series.ToLower(),
                Chapter = chapter
            };

            if (model.BadPage())
            {
                Response.Redirect("/" + series);
            }
            
            return View(model);
        }

        public IActionResult Staff()
        {
            ViewData["Url"] = HttpContext.Request.Path;

            var model = new StaffPageModel();

            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}