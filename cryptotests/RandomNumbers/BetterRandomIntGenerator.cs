using System;
using System.Security.Cryptography;

namespace cryptotests.RandomNumbers {
    public class BetterRandomIntGenerator : IRandomIntGenerator {
        private readonly int _numberOfRandomIntsToGenerate;
        private readonly RNGCryptoServiceProvider _randomGenerator;
        private readonly byte[] _randomNumbers;
        private int _numberOfGeneratedInts;
        private readonly int _minValue;
        private readonly int _maxValue;

        public BetterRandomIntGenerator(int numberOfRandomIntsToGenerate = 10, 
            int maxValue = 10,
            int minValue = 0) {
            if (numberOfRandomIntsToGenerate <= 0) {
                throw new ArgumentException($"{nameof(numberOfRandomIntsToGenerate)} must be a positive number.");
            }
            if (minValue > maxValue) {
                throw new ArgumentException($"{nameof(minValue)} must be smaller than {nameof(maxValue)}");
            }
            _minValue = minValue;
            _maxValue = maxValue;
            _numberOfRandomIntsToGenerate = numberOfRandomIntsToGenerate;
            _randomNumbers = new byte[numberOfRandomIntsToGenerate*sizeof (int)];
            _randomGenerator = new RNGCryptoServiceProvider();
            ResetBuffer();
        }

        public int GetNextRandomNumber() {
            if (_numberOfGeneratedInts >= _numberOfRandomIntsToGenerate) {
                //used all numbers, so we need to reset everything
                ResetBuffer();
            }
            //get next integer (using sizeof(int) so that it's explicit - could have used 4 also, but...)
            var nextRandom = BitConverter.ToInt32(_randomNumbers, _numberOfGeneratedInts*sizeof (int));
            nextRandom &= 0x7fffffff;
            _numberOfGeneratedInts++;

            return AdaptToMinMaxValues(nextRandom);
        }

        private int AdaptToMinMaxValues(int nextRandom) {
            var range = _maxValue - _minValue;
            return _minValue + (nextRandom%_maxValue);
        }

        private void ResetBuffer() {
            _numberOfGeneratedInts = 0;
            _randomGenerator.GetBytes(_randomNumbers);
        }
    }
}