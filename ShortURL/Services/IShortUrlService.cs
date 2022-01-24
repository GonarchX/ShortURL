using ShortURL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShortURL.Services
{
    public interface IShortUrlService
    {
        /// <summary>
        /// Asynchronously attempts to find specified token in the specified context
        /// </summary>
        /// <param name="token">Value of short URL</param>
        /// <returns>Returns token of short URL, otherwise null</returns>
        Task<ShortUrlInfo> GetShortUrlInfoByTokenAsync(string token);

        /// <summary>
        /// Asynchronously get all values from specified context
        /// </summary>
        /// <returns>All values from specified context</returns>
        Task<IEnumerable<ShortUrlInfo>> GetAllShortUrlsAsync();

        /// <summary>
        /// Asynchronously generates unique token for specified context
        /// </summary>
        /// <param name="tokenLength">Necessary length of token</param>
        /// <returns>Token of short URL</returns>
        Task<string> GenerateNonDuplTokenAsync(int tokenLength);

        /// <summary>
        /// Checks if the specified token is present in the specified context
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        bool IsDuplicate(string token);

        /// <summary>
        /// Asynchronously finds field with specified token and increase counter of clicks by one
        /// </summary>
        /// <param name="token"></param>       
        Task IncrementTokenClicksAsync(string token);

        /// <summary>
        /// Asynchronously saves a token in the specified context
        /// </summary>
        /// <param name="token"></param>
        /// <returns>Returns false if token already exists in the specified context</returns>
        Task<bool> SaveShortUrlInfoAsync(ShortUrlInfo token);
    }
}