using System.Diagnostics.Contracts;
namespace cryptotests.Hashes {
    [ContractClass(typeof(HmacGeneratorContract))]
    public interface IHmacGenerator {
        byte[] ComputeHmac(byte[] msgToHash);
    }

    [ContractClassFor(typeof(IHmacGenerator))]
    abstract class HmacGeneratorContract:IHmacGenerator {
        public byte[] ComputeHmac(byte[] msg) {
            Contract.Requires(msg != null);
            Contract.Ensures(Contract.Result<byte[]>() != null);
            return default(byte[]);
        }
        
    }
}