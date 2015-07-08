using System;
using cryptotests.Hashes;

namespace cryptotests.Passwords {
    public class PasswordHasher : IPasswordHasher {
        private readonly IHashGenerator _hashGenerator;

        public PasswordHasher(IHashGenerator hashGenerator) {
            if (hashGenerator == null) {
                throw new ArgumentNullException($"{nameof(hashGenerator)} cannot be null.");
            }
            _hashGenerator = hashGenerator;
        }

        public byte[] HashPasswordWithSalt(byte[] password, byte[] salt) {
            var mixed = MixPassWithSalt(password, salt);
            return _hashGenerator.ComputeHashForMessage(mixed);
        }

        private static byte[] MixPassWithSalt(byte[] password, byte[] salt) {
            var mixed = new byte[password.Length + salt.Length];
            Buffer.BlockCopy(password, 0, mixed, 0, password.Length);
            Buffer.BlockCopy(salt, 0, mixed, password.Length, salt.Length);
            return mixed;
        }
    }
}