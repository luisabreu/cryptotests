using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

namespace cryptotests.Passwords {
    public class PasswordWithKeyDerivationFunctionHasher : IPasswordHasher {
        private const int _first32bytes = 32;
        private readonly int _numberOfIterations;

        public PasswordWithKeyDerivationFunctionHasher(int numberOfIterations = 5000) {
            Contract.Requires(numberOfIterations > 0);
            Contract.Ensures(_numberOfIterations > 0);
            _numberOfIterations = numberOfIterations;
        }

        public byte[] HashPasswordWithSalt(byte[] password, byte[] salt) {
            using (var hasher = new Rfc2898DeriveBytes(password, salt, _numberOfIterations)) {
                return hasher.GetBytes(_first32bytes);
            }
        }

        [ContractInvariantMethod]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "Required for code contracts.")]
        private void ObjectInvariant() {
            Contract.Invariant(_numberOfIterations > 0);
        }
    }
}