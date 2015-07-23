using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using cryptotests.Hashes;
using cryptotests.Passwords;
using cryptotests.RandomNumbers;
using static System.Convert;
using RandomNumberGenerator = cryptotests.RandomNumbers.RandomNumberGenerator;

using static System.Text.Encoding;

namespace cryptotests {
    internal class Program {
        private static void Main(string[] args) {
            //            GenerateRandomIntsFromSimpleRandomGenerator();
            //            GenerateRandomIntsFromBetterRandomGenerator();
            //  GenerateRandomNumbers();
            //          GenerateHashMd5("Hi, there!!!");
            //          GenerateHashSHA1("Hi, there!!!");
            //          GenerateHashSHA256("Hi, there!!!");
            //          GenerateHashSHA512("Hi, there!!!");
            //            byte[] key = new RandomNumberGenerator(256).GetNextRandomNumbers();
            //            GenerateHmacMd5(key, "Hi there");
            //            GenerateHmacSha1(key, "Hi there");
            //            GenerateHmacSha256(key, "Hi there");
            //            GenerateHmacSha512(key, "Hi there");

            //            GenerateHashForPass();
            //            GeneratePassWithKeyDerivedFunction();

            EncryptDecrypt();
        }


        private static void EncryptDecrypt() {
            var txtToEncrypt = "Howdy there!";
            var encryption = new Encryption.Symmetric.Encryption<DESCryptoServiceProvider>();
            var randomNumberGenerator = new RandomNumberGenerator(8);
            var key = randomNumberGenerator.GetNextRandomNumbers();
            var iv= randomNumberGenerator.GetNextRandomNumbers();

            var encrypted = encryption.Encrypt(UTF8.GetBytes(txtToEncrypt), key, iv);
            Console.WriteLine(Encoding.UTF8.GetString(encrypted));
            var decrypted = encryption.Decrypt(encrypted, key, iv);
            Console.WriteLine(UTF8.GetString(decrypted));
        }
        private static void GeneratePassWithKeyDerivedFunction() {
            var pass = "Hello, world";
            var salt = new RandomNumberGenerator(32).GetNextRandomNumbers();
            var hasher = new PasswordWithKeyDerivationFunctionHasher();

            var passHashed = hasher.HashPasswordWithSalt(Encoding.UTF8.GetBytes(pass), salt);

            Console.WriteLine($"Pass hashed: {ToBase64String(passHashed)}");
        }

        private static void GenerateHashForPass() {
            var pass = "Howdy, there!!!";
            var salt = new RandomNumberGenerator(32).GetNextRandomNumbers();
            var passHasher = new PasswordHasher(new Sha512HashGenerator());

            var passHashed = passHasher.HashPasswordWithSalt(Encoding.UTF8.GetBytes(pass), salt);

            Console.WriteLine($"Pass hashed: {ToBase64String(passHashed)}");
        }

        private static void GenerateHmacSha1(byte[] key, string msg) {
            using (var hmacGenerator = new HmacGenerator(new HMACSHA1(key))) {
                var hmac = hmacGenerator.ComputeHmac(Encoding.UTF8.GetBytes(msg));
                Console.WriteLine(ToBase64String(hmac));
            }
            
        }

        private static void GenerateHmacSha256(byte[] key, string msg) {
            using (var hmacGenerator = new HmacGenerator(new HMACSHA256(key))) {
                var hmac = hmacGenerator.ComputeHmac(Encoding.UTF8.GetBytes(msg));
                Console.WriteLine(ToBase64String(hmac));
            }
            
        }

        private static void GenerateHmacSha512(byte[] key, string msg) {
            using (var hmacGenerator = new HmacGenerator(new HMACSHA512(key))) {
                var hmac = hmacGenerator.ComputeHmac(Encoding.UTF8.GetBytes(msg));
                Console.WriteLine(ToBase64String(hmac));
            }
            
        }
        private static void GenerateHmacMd5(byte[] key, string msg) {
            using (var hmacGenerator = new HmacGenerator(new HMACMD5(key))) {
                var hmac = hmacGenerator.ComputeHmac(Encoding.UTF8.GetBytes(msg));
                Console.WriteLine(ToBase64String(hmac));
            }
            
        }

        private static void GenerateHashMd5(string msg) {
            HashMessage<Md5HashGenerator>(msg);
        }

        private static void GenerateHashSHA1(string msg) {
            HashMessage<Sha1HashGenerator>(msg);
        }

        private static void GenerateHashSHA256(string msg) {
            HashMessage<Sha256HashGenerator>(msg);
        }

        private static void GenerateHashSHA512(string msg) {
            HashMessage<Sha512HashGenerator>(msg);
        }

        private static void HashMessage<T>(string msg) where T: IHashGenerator, new() {
            var bytes = Encoding.UTF8.GetBytes(msg);
            var hash = new T().ComputeHashForMessage(bytes);
            Console.WriteLine(ToBase64String(hash));
        }

        private static void GenerateRandomNumbers() {
            for (var i = 0; i < 10; i++) {
                Console.WriteLine($"iteration {i}: {ToBase64String(new RandomNumberGenerator(32).GetNextRandomNumbers())}");
            }
            

        }
        private static void GenerateRandomIntsFromBetterRandomGenerator() {
            //using 10, but asking for 20 in order to test buffer regeneration
            var generator = new BetterRandomIntGenerator(10);
            var pos = 0;
            Enumerable.Range(0, 20)
                .Select( i => generator.GetNextRandomNumber())
                .ToList()
                .ForEach(i => Console.WriteLine($"iteration {pos++}: {i} "));
        }

        private static void GenerateRandomIntsFromSimpleRandomGenerator() {
            var generator = new SimpleRandomIntGenerator(250);
            for (var i = 0; i < 10; i++) {
                Console.WriteLine($"iteration {i}: {generator.GetNextRandomNumber()} ");
            }
        }
    }
}