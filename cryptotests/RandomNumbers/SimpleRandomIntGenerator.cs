using System;

namespace cryptotests.RandomNumbers {
    public class SimpleRandomIntGenerator : IRandomIntGenerator {
        private readonly int _maxValue;
        private readonly int _minValue;
        private readonly Random _randomGenerator;

        public SimpleRandomIntGenerator(int seed, int maxValue = 10, int minValue = 0) {
            if (seed <= 0) {
                throw new ArgumentException($"{nameof(seed)} must be a positive number");
            }
            _maxValue = maxValue;
            _minValue = minValue;
            _randomGenerator = new Random(seed);
        }

        public int GetNextRandomNumber() {
            return _randomGenerator.Next(_minValue, _maxValue);
        }
    }
}