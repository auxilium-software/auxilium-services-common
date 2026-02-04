using System.Security.Cryptography;
using System.Text;

namespace AuxiliumSoftware.AuxiliumServices.Common.Utilities
{
    /// <summary>
    /// Utilities related to hashing operations.
    /// </summary>
    public class HashingUtilities
    {
        /// <summary>
        /// Hashes a given string into SHA256 and returns the hex representation.
        /// </summary>
        /// <param name="input">The string to hash.</param>
        /// <returns>The hashed string.</returns>
        public static string SHA256Hash(string input)
        {
            var bytes = SHA256.HashData(Encoding.UTF8.GetBytes(input));
            return Convert.ToHexString(bytes).ToLowerInvariant();
        }

        /// <summary>
        /// Hashes a given byte array into SHA256 and returns the hex representation.
        /// </summary>
        /// <param name="data">The byte array to hash.</param>
        /// <returns>The hashed string.</returns>
        public static string SHA256Hash(byte[] data)
        {
            var hash = SHA256.HashData(data);
            return Convert.ToHexString(hash).ToLowerInvariant();
        }
    }
}
