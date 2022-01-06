using System;
using System.Text;

namespace ShortURL.Utils
{
    public class ShortUrlUtil
    {
        private const string validSymbols = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

        /// <summary>
        /// Convert from long URL to short URL
        /// </summary>
        /// <param name="longURL">URL for converting to short URL</param>
        /// <returns>short URL</returns>        
        public static string GenerateShortUrl(int shortUrlLength)
        {
            StringBuilder sb = new();
            Random rnd = new();

            for (int i = 0; i < shortUrlLength; i++)
            {
                sb.Append(validSymbols[rnd.Next(0, validSymbols.Length)]);
            }

            return sb.ToString();
        }
    }
}
