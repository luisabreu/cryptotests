using System;
using System.Diagnostics.Contracts;

namespace cryptotests.RandomNumbers {
    public class SimpleRandomIntGenerator : IRandomIntGenerator {
        private readonly int _maxValue;
        private readonly int _minValue;
        private readonly Random _randomGenerator;

        public SimpleRandomIntGenerator(int seed, int maxValue = 10, int minValue = 0) {
            Contract.Requires(seed > 0);
            Contract.Requires(maxValue >= 0);
            Contract.Requires(minValue >= 0);
            Contract.Requires(minValue <= maxValue);
            
            Contract.Ensures(_maxValue >= 0);
            Contract.Ensures(_minValue >= 0);
            Contract.Ensures(_minValue <= _maxValue);
            _maxValue = maxValue;
            _minValue = minValue;
            _randomGenerator = new Random(seed);
        }

        public int GetNextRandomNumber() {
            return _randomGenerator.Next(_minValue, _maxValue);
        } 

        [ContractInvariantMethod]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1822:MarkMembersAsStatic", Justification = "Required for code contracts.")]
        private void ObjectInvariant()
        {
            Contract.Invariant(_maxValue >= 0);
            Contract.Invariant(_minValue >= 0);
            Contract.Invariant(_minValue <= _maxValue);
        }

    }
}