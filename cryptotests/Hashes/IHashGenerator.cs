using System.Diagnostics.Contracts;
namespace cryptotests.Hashes {
    [ContractClass(typeof(HashGeneratorContract))]
    public interface IHashGenerator {
        byte[] ComputeHashForMessage(byte[] msg);
    }

    [ContractClassFor(typeof(IHashGenerator))]
    abstract class HashGeneratorContract:IHashGenerator {
        public byte[] ComputeHashForMessage(byte[] msg) {
            Contract.Requires(msg != null);
            Contract.Ensures(Contract.Result<byte[]>() != null);
            return default(byte[]);
        }
    }
}