using GeekForLess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GeekForLess.Controllers
{
    public class HomeController : Controller
    {
        private GeekForLessContext db;
        private HomeModel homeModel;
        private string folderOwner;
        
        public HomeController(GeekForLessContext Context)
        {
            db = Context;
            homeModel = new HomeModel(db);
        }

        public IActionResult Index()
        {
            return View(homeModel.CreateLink());
        }

        public IActionResult SecondPage(string folderOwner)
        {
            return View(homeModel.CreateLink(folderOwner));
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}