using System  ;
using System.Collections.Generic ;
using System.IO;
using System.Linq ;
using System.Security.Cryptography ;
using System.Text ;
using System.Threading.Tasks ;

namespace cryptotests.Encryption.Symmetric {
    public class Encryption<T> : IEncryption where T : DES, new() {
        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv) {
            return EncryptDecrypt(dataToEncrypt, key, iv);
        }

        private byte[] EncryptDecrypt(byte[] data, byte[] key, byte[] iv, bool isEncrypting = true) {
            using (var des = CreateEncryption(key, iv)) {
                using (var memoryStream = new MemoryStream()) {
                    var stream = new CryptoStream(memoryStream, 
                        isEncrypting ? des.CreateEncryptor() : des.CreateDecryptor(), 
                        CryptoStreamMode.Write);
                    stream.Write(data, 0, data.Length);
                    stream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] dataToDecrypt, byte[] key, byte[] iv) {
            return EncryptDecrypt(dataToDecrypt, key, iv, false);
        }

        private T CreateEncryption(byte[] key, byte[] iv) {
            return new T {
                             Mode = CipherMode.CBC,
                             Padding = PaddingMode.PKCS7,
                             Key = key,
                             IV = iv,
                         };
        }
    }
}