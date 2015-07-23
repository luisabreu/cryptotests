using System.Diagnostics.Contracts;

namespace cryptotests.Encryption {
    [ContractClass(typeof (EncryptionContract))]
    public interface IEncryption {
        byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv);
    }

    [ContractClassFor(typeof (IEncryption))]
    internal abstract class EncryptionContract : IEncryption {
        public byte[] Encrypt(byte[] dataToEncrypt, byte[] key, byte[] iv) {
            Contract.Requires(dataToEncrypt != null);
            Contract.Requires(key != null);
            Contract.Requires(iv != null);
            Contract.Ensures(Contract.Result<byte[]>() != null);
            return default(byte[]);
        }
    }
}