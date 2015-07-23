using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

namespace cryptotests.RandomNumbers {
    public class RandomNumberGenerator : IRandomNumberGenerator {
        private readonly int _length;

        public RandomNumberGenerator(int length) {
            Contract.Requires(length > 0);
            Contract.Ensures(_length > 0);
            _length = length;
        }

        public byte[] GetNextRandomNumbers() {
            using (var generator = new RNGCryptoServiceProvider()) {
                var randomNumbers = new byte[_length];
                generator.GetBytes(randomNumbers);
                return randomNumbers;
            }
        }

        [ContractInvariantMethod]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "Required for code contracts.")]
        private void ObjectInvariant() {
            Contract.Invariant(_length > 0);
        }
    }
}