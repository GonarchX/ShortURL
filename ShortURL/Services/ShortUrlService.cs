using ShortURL.Models;
using ShortURL.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortURL.Services
{
    public class ShortUrlService : IShortUrlService
    {
        private readonly ApplicationContext context;

        public ShortUrlService(ApplicationContext _context)
        {
            context = _context;
        }

        public string GetShortUrlById(int id) => context.ShortUrlInfos.Find(id).Token;

        public string GetShortUrlByLongUrl(string longUrl) => context.ShortUrlInfos.FirstOrDefault(x => x.LongUrl == longUrl)?.Token;

        public IEnumerable<ShortUrlInfo> GetAllShortUrls() => context.ShortUrlInfos.ToList();

        public bool IsDuplicate(string shortUrl) => context.ShortUrlInfos.FirstOrDefault(x => x.Token == shortUrl) != null;

        /// <summary>
        /// Generate non duplicated short URL
        /// </summary>
        public async Task<string> GenerateNonDuplShortUrlAsync(int shortUrlLength)
        {
            string shortURL = "";

            await Task.Run(() =>
            {
                do
                {
                    shortURL = ShortUrlUtil.GenerateShortUrl(shortUrlLength);
                } while (IsDuplicate(shortURL));
            });

            return shortURL;
        }

        public async Task<bool> SaveShortUrlInfoAsync(ShortUrlInfo shortUrl)
        {
            if (IsDuplicate(shortUrl.Token)) return false;

            context.Add(shortUrl);
            await context.SaveChangesAsync();
            return true;
        }
    }
}