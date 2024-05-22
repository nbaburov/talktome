using System;
using System.Security.Cryptography;

namespace SharedLibrary.Helpers;

public class Hash
{
    // Method to generate random salt
    public byte[] GenerateSalt()
    {
        // Create an array of bytes to store the salt
        byte[] salt = new byte[16];

        // Use RNGCryptoServiceProvider to generate random bytes for the salt
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(salt); // Fill the salt array with random bytes
        }

        return salt; // Return the generated salt
    }

    // Method to hash password with salt
    public string HashPassword(string password, byte[] salt)
    {
        // Create an instance of Rfc2898DeriveBytes to hash the password using PBKDF2 algorithm
        using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000))
        {
            byte[] hash = pbkdf2.GetBytes(20); // secret message that's 20 characters long
            byte[] hashBytes = new byte[36]; // Create an array to store the combined salt and hash bytes

            // Copy the salt bytes to the beginning of the hashBytes array
            Array.Copy(salt, 0, hashBytes, 0, 16);

            // Copy the hash bytes to the end of the hashBytes array
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // Convert the combined salt and hash bytes to a base64-encoded string
            return Convert.ToBase64String(hashBytes);
        }
    }
}
