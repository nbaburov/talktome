using System;
using System.Security.Cryptography;

// Problem: Directly using Hash for dependency injection doesn’t allow me to mock its methods.
// Solution: HashWrapper extends Hash and is used in the service registration. This allows the tests to mock HashWrapper while the application can still use its actual implementation.


namespace SharedLibrary.Helpers
{
    public class HashWrapper : Hash
    {
        public override byte[] GenerateSalt()
        {
            return base.GenerateSalt();
        }

        public override string HashPassword(string password, byte[] salt)
        {
            return base.HashPassword(password, salt);
        }
    }
}
