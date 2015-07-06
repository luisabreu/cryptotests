using System.Security.Cryptography;

namespace cryptotests.Hashes {
    public class Md5HashGenerator : IHashGenerator {
        public byte[] ComputeHashForMessage(byte[] msg) {
            using (var generator = MD5.Create()) {
                return generator.ComputeHash(msg);
            }
        }
    }
}