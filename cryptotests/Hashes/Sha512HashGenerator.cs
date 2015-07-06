using System.Security.Cryptography;

namespace cryptotests.Hashes {
    public class Sha512HashGenerator : IHashGenerator {
        public byte[] ComputeHashForMessage(byte[] msg) {
            using (var generator = SHA512.Create()) {
                return generator.ComputeHash(msg);
            }
        }
    }
}