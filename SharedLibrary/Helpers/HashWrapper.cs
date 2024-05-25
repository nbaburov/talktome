using System;
using System.Security.Cryptography;

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
