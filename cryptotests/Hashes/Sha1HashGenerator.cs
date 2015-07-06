using System.Security.Cryptography;

namespace cryptotests.Hashes {
    public class Sha1HashGenerator : IHashGenerator {
        public byte[] ComputeHashForMessage(byte[] msg) {
            using (var generator = SHA1.Create()) {
                return generator.ComputeHash(msg);
            }
        }
    }
}