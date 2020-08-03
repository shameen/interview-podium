using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace PodiumInterview.MortgageApi.Logic
{
    public interface IRandomNumberGenerator
    {
        long GetRandomLong();
    }

    /// <summary>
    /// Uses <see cref="RNGCryptoServiceProvider"/> which is cryptographically secure, but not very fast.
    /// </summary>
    public class SecureIdGenerator : IRandomNumberGenerator
    {
        public long GetRandomLong()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                byte[] bytes = new byte[64];
                rng.GetBytes(bytes);
                return Convert.ToInt64(bytes);
            }
        }
    }
}
