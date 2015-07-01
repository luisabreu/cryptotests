using System;
using System.Security.Cryptography;

namespace cryptotests.RandomNumbers {
    public class RandomNumberGenerator : IRandomNumberGenerator  {
        private readonly int _length;

        public RandomNumberGenerator(int length) {
            if (length <= 0) {
                throw new ArgumentException($"{nameof(length)} must be a positive number.");
            }
            _length = length;
        }

        public byte[] GetNextRandomNumbers() {
            using (var generator = new RNGCryptoServiceProvider()) {
                var randomNumbers = new byte[_length];
                generator.GetBytes(randomNumbers);
                return randomNumbers;
            }
        }
    }
}