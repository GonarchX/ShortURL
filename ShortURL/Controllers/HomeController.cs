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

        #region Controllers
        public IActionResult Index()
        {
            return View();
        }

        //Creates the short URL and saving it to db
        public async Task<IActionResult> ShortenedURL(string longUrl, int tokenLength)
        {
            if (!IsValidUri(longUrl))
            {
                return RedirectToAction("InvalidURL");
            }

            string token = shortUrlService.GenerateNonDuplTokenAsync(tokenLength).Result;

            //Builds full short url address
            ViewBag.shortUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/{token}";
            ViewBag.token = token;
            ViewBag.longUrl = longUrl;

            //Creates new ShortUrlInfo with specified data and save it to our context
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

        public async Task<IActionResult> RedirectByToken(string token)
        {
            if (token == null) return RedirectToAction("InvalidUrl");

            await shortUrlService.IncrementTokenClicksAsync(token);
            var task = shortUrlService.GetShortUrlInfoByTokenAsync(token);
            task.Wait();
            return Redirect(task.Result.LongUrl);
        }

        public IActionResult InvalidUrl() => View();

        public IActionResult ShortUrlAllStats(int currentPage = 1)
        {
            IEnumerable<ShortUrlInfo> entriesToShow = shortUrlService.GetAllShortUrlsAsync().Result;
            int pageSize = 50;
            Pager pager = new Pager(entriesToShow.Count(), pageSize, currentPage);
            ViewBag.Pager = pager;
            return View(entriesToShow.Skip((pager.CurrentPage - 1) * pageSize).Take(pageSize));
        }
        #endregion

        public bool IsValidUri(string uri) => Uri.TryCreate(uri, UriKind.Absolute, out _);
    }
}