using System;
using System.Security.Cryptography;

namespace cryptotests.Passwords {
    public class PasswordWithKeyDerivationFunctionHasher : IPasswordHasher {
        private readonly int _numberOfIterations;

        public PasswordWithKeyDerivationFunctionHasher(int numberOfIterations = 5000) {
            if (numberOfIterations <= 0) {
                throw new ArgumentException($"{nameof(numberOfIterations)} must be a positive number.");
            }
            _numberOfIterations = numberOfIterations;
        }

        private const int _first32bytes = 32;
        public byte[] HashPasswordWithSalt(byte[] password, byte[] salt) {
            using (var hasher = new Rfc2898DeriveBytes(password, salt, _numberOfIterations)) {
                return hasher.GetBytes(_first32bytes);
            }
        }
    }
}