using Microsoft.EntityFrameworkCore;
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

        #region IShortUrlService implementation
        public async Task<ShortUrlInfo> GetShortUrlInfoByTokenAsync(string token) =>
            await context.ShortUrlInfos.FirstOrDefaultAsync(x => x.Token == token);

        public async Task<IEnumerable<ShortUrlInfo>> GetAllShortUrlsAsync()
            => await Task.Run(() => context.ShortUrlInfos.ToList());

        /// <summary>
        /// Generate non duplicated short URL
        /// </summary>
        public async Task<string> GenerateNonDuplTokenAsync(int tokenLength)
        {
            string token = "";

            //Generate token by creating sequence of random symbols
            //so different short links will be created for the same links.
            await Task.Run(() =>
            {
                do
                {
                    token = ShortUrlUtil.GenerateShortUrl(tokenLength);
                } while (IsDuplicate(token));
            });

            return token;
        }

        public bool IsDuplicate(string token)
                => GetShortUrlInfoByTokenAsync(token) != null;

        public async Task IncrementTokenClicksAsync(string token)
        {
            GetShortUrlInfoByTokenAsync(token).Result.ClickNum++;
            await context.SaveChangesAsync();
        }

        public async Task<bool> SaveShortUrlInfoAsync(ShortUrlInfo shortUrl)
        {
            if (IsDuplicate(shortUrl.Token)) return false;

            context.Add(shortUrl);
            await context.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}