using System;
using System.Linq;
using cryptotests.RandomNumbers;

namespace cryptotests {
    internal class Program {
        private static void Main(string[] args) {
            //GenerateRandomNumbersFromSimpleRandomGenerator();
            GenerateRandomNumbersFromBetterRandomGenerator();
        }

        private static void GenerateRandomNumbersFromBetterRandomGenerator() {
            //using 10, but asking for 20 in order to test buffer regeneration
            var generator = new BetterRandomIntGenerator(10);
            var pos = 0;
            Enumerable.Range(0, 20)
                .Select( i => generator.GetNextRandomNumber())
                .ToList()
                .ForEach(i => Console.WriteLine($"iteration {pos++}: {i} "));
        }

        private static void GenerateRandomNumbersFromSimpleRandomGenerator() {
            var generator = new SimpleRandomIntGenerator(250);
            for (var i = 0; i < 10; i++) {
                Console.WriteLine($"iteration {i}: {generator.GetNextRandomNumber()} ");
            }
        }
    }
}