using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortURL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURL.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Shortener(string longURL)
        {
            if (!IsValidUri(longURL))
            {
                return RedirectToAction("InvalidURL");
            }

            if (longURL != null)
            {
                ViewBag.longURL = longURL;

                return View();
            }
            else return RedirectToAction("Index");
        }

        public IActionResult InvalidURL()
        {
            return View();
        }

        public IActionResult ShortURLStats()
        {
            return View();
        }

        public bool IsValidUri(string uri)
        {
            Uri validatedUri;
            return Uri.TryCreate(uri, UriKind.RelativeOrAbsolute, out validatedUri);
        }
    }
}
