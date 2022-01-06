using ShortURL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortURL.Services
{
    public interface IShortUrlService
    {
        public string GetShortUrlById(int id);

        string GetShortUrlByLongUrl(string LongUrl);

        IEnumerable<ShortUrlInfo> GetAllShortUrls();

        Task<string> GenerateNonDuplShortUrlAsync(int shortUrlLength);

        bool IsDuplicate(string shortUrl);

        Task<bool> SaveShortUrlInfoAsync(ShortUrlInfo shortUrl);
    }
}