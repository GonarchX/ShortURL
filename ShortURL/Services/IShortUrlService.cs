using ShortURL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortURL.Services
{
    public interface IShortUrlService
    {
        ShortUrlInfo GetShortUrlInfoByToken(string token);

        Task<IEnumerable<ShortUrlInfo>> GetAllShortUrlsAsync();

        Task<string> GenerateNonDuplTokenAsync(int tokenLength);

        bool IsDuplicate(string token);

        Task IncrementTokenClicksAsync(string token);

        Task<bool> SaveShortUrlInfoAsync(ShortUrlInfo token);
    }
}