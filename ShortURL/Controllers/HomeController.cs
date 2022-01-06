using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ShortURL.Models;
using ShortURL.Services;
using ShortURL.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURL.Controllers
{
    public class HomeController : Controller
    {
        readonly IShortUrlService shortUrlService;

        public HomeController(IShortUrlService _shortUrlService)
        {
            shortUrlService = _shortUrlService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //Creating the short URL and saving it to db
        public async Task<IActionResult> ShortenedURL(string longUrl, int tokenLength)
        {
            if (!IsValidUri(longUrl))
            {
                return RedirectToAction("InvalidURL");
            }

            string token = await shortUrlService.GenerateNonDuplShortUrlAsync(tokenLength);

            ViewBag.token = token;
            ViewBag.longUrl = longUrl;

            await shortUrlService.SaveShortUrlInfoAsync(
                new ShortUrlInfo()
                {
                    Token = token,
                    LongUrl = longUrl,
                    CreateDate = DateTime.Now,
                    ClickNum = 0
                });

            return View();
        }

        /*public IActionResult RedirectByToken(string token)
        {
            return Redirect("");
        }*/

        public IActionResult InvalidUrl()
        {
            return View();
        }

        public IActionResult ShortUrlAllStats()
        {
            return View(shortUrlService.GetAllShortUrls());
        }

        public bool IsValidUri(string uri) => Uri.TryCreate(uri, UriKind.Absolute, out _);
    }
}
