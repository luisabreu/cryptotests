using System;
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

namespace cryptotests.Hashes {
    public class HmacGenerator : IHmacGenerator, IDisposable {
        private readonly HMAC _hmacGenerator;

        public HmacGenerator(HMAC hmacGenerator) {
            Contract.Requires(hmacGenerator != null);
            Contract.Ensures(_hmacGenerator != null);
            _hmacGenerator = hmacGenerator;
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public byte[] ComputeHmac(byte[] msgToHash) {
            return _hmacGenerator.ComputeHash(msgToHash);
        }

        protected virtual void Dispose(bool isDisposing) {
            if (isDisposing) {
                _hmacGenerator.Dispose();
            }
        }

        [ContractInvariantMethod]
        [SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic",
            Justification = "Required for code contracts.")]
        private void ObjectInvariant() {
            Contract.Invariant(_hmacGenerator != null);
        }
    }
}