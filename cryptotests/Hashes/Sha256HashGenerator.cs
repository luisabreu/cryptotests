using System.Security.Cryptography;

namespace cryptotests.Hashes {
    public class Sha256HashGenerator : IHashGenerator {
        public byte[] ComputeHashForMessage(byte[] msg) {
            using (var generator = SHA256.Create()) {
                return generator.ComputeHash(msg);
            }
        }
    }
}