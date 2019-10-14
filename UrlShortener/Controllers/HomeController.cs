using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.BusinessLogic;
using UrlShortener.Models;

namespace UrlShortener.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(UrlViewModel model)
        {
            var viewModel = Service.Save(model);

            var formattableString = $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}/";
            viewModel.ShortUrl = formattableString + viewModel.ShortUrl;
            return View("UrlInfo", viewModel);
        }

        public IActionResult NavigateTo(string url)
        {
            return Redirect(Service.GetRedirectUrl(url));
        }

    }
}
