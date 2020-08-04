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
                var newLong = BitConverter.ToInt64(bytes);
                return MakeLongMoreFriendly(newLong);
            }
        }

        /// <summary>
        /// To make the generated number more friendly for Database identities + JavaScript
        /// </summary>
        private long MakeLongMoreFriendly(long n)
        {
            //Confusing to have a negative ID
            n = Math.Abs(n);
            //Stay below Javascript's maximum supported integer
            const long MAX_SAFE_INTEGER = 9007199254740991;
            return n % MAX_SAFE_INTEGER;
        }
    }
}
