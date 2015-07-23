using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using cryptotests.Hashes;

namespace cryptotests.Passwords {
    public class PasswordHasher : IPasswordHasher {
        private readonly IHashGenerator _hashGenerator;

        public PasswordHasher(IHashGenerator hashGenerator) {
            Contract.Requires(hashGenerator != null);
            Contract.Ensures(_hashGenerator != null);
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

        [ContractInvariantMethod]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "Required for code contracts.")]
        private void ObjectInvariant() {
            Contract.Invariant(_hashGenerator != null);
        }
    }
}