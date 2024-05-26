using System;
using System.Security.Cryptography;

// Problem: The original Hash class cannot be mocked because its methods are not virtual. Mocking is essential for unit tests to simulate the behavior of dependencies without relying on their actual implementations.
// Solution: By making the methods virtual, I can use Moq to override these methods during testing.

namespace SharedLibrary.Helpers
{
    public class Hash
    {
        // Method to generate random salt
        public virtual byte[] GenerateSalt()
        {
            // Create a byte array to hold the salt
            byte[] salt = new byte[16];

            // Use RNGCryptoServiceProvider to fill the array with cryptographically strong random bytes
            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(salt);
            }

            // Return the generated salt
            return salt;
        }

        // Method to hash password with salt
        public virtual string HashPassword(string password, byte[] salt)
        {
            // Use PBKDF2 algorithm to hash the password with the provided salt
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
            {
                // Generate a 20-byte hash of the password
                byte[] hash = pbkdf2.GetBytes(20);

                // Create a byte array to hold the combined salt and hash
                byte[] hashBytes = new byte[36];

                // Copy the salt into the first 16 bytes of the hashBytes array
                Array.Copy(salt, 0, hashBytes, 0, 16);

                // Copy the hash into the remaining 20 bytes of the hashBytes array
                Array.Copy(hash, 0, hashBytes, 16, 20);

                // Convert the combined salt and hash to a base64 string and return it
                return Convert.ToBase64String(hashBytes);
            }
        }

    }
}
