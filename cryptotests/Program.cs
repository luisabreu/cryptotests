using System;
using System.Linq;
using System.Text;
using cryptotests.Hashes;
using cryptotests.RandomNumbers;
using static System.Convert;

namespace cryptotests {
    internal class Program {
        private static void Main(string[] args) {
//            GenerateRandomIntsFromSimpleRandomGenerator();
//            GenerateRandomIntsFromBetterRandomGenerator();
          //  GenerateRandomNumbers();
          GenerateHashMd5("Hi, there!!!");
          GenerateHashSHA1("Hi, there!!!");
          GenerateHashSHA256("Hi, there!!!");
          GenerateHashSHA512("Hi, there!!!");
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
            Console.WriteLine(Convert.ToBase64String(hash));
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