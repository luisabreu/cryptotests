using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cryptotests.RandomNumbers;

namespace cryptotests
{
    class Program
    {
        static void Main(string[] args)
        {
            GenerateRandomNumbersFromSimpleRandomGenerator();
        }

        static void GenerateRandomNumbersFromSimpleRandomGenerator() {
            var generator = new SimpleRandomGenerator(250);
            for (var i = 0; i < 10; i++) {
                Console.WriteLine($"iteration {i}: {generator.GetNextRandomNumber()} ");
            }
        }
    }
}
