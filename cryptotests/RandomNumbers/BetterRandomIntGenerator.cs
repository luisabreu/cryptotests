using System;
using System.Diagnostics.Contracts;
using System.Security.Cryptography;

namespace cryptotests.RandomNumbers {
    public sealed class BetterRandomIntGenerator : IRandomIntGenerator, IDisposable {
        private readonly int _numberOfRandomIntsToGenerate;
        private readonly RNGCryptoServiceProvider _randomGenerator;
        private readonly byte[] _randomNumbers;
        private int _numberOfGeneratedInts;
        private readonly int _minValue;
        private readonly int _maxValue;

        public BetterRandomIntGenerator(int numberOfRandomIntsToGenerate = 10, 
            int maxValue = 10,
            int minValue = 0) {
            Contract.Requires(numberOfRandomIntsToGenerate > 0);
            Contract.Requires(minValue >= 0);
            Contract.Requires(maxValue >= 0);
            Contract.Requires(minValue <= maxValue);
            Contract.Ensures(_numberOfRandomIntsToGenerate <= 0);
            Contract.Ensures(_minValue <= _maxValue);
            Contract.Ensures(_minValue >= 0);
            Contract.Ensures(_maxValue >= 0);
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

        public void Dispose() {
           Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool isDisposing) {
            if (isDisposing) {
                ((IDisposable)_randomGenerator).Dispose();
            }
        }

        [ContractInvariantMethod]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for code contracts.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(_numberOfRandomIntsToGenerate > 0);
            Contract.Invariant(_minValue < _maxValue);
            Contract.Invariant(_minValue >= 0);
            Contract.Invariant(_maxValue > 0);
        }

    }
}