﻿using System;
using System.Text;
using System.Security.Cryptography;

namespace Gabinet_CRUD.Helpers
{
    public static class PasswordHashHelper
    {
        public static string GetHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                // Send a sample text to hash.  
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                // Get the hashed string.  
                var hash = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
                return hash;
            }
        }
    }
}
