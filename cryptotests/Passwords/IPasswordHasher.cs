using System.Diagnostics.Contracts;
namespace cryptotests.Passwords {
    [ContractClass(typeof(PasswordHasherContract))]
    public interface IPasswordHasher {
        byte[] HashPasswordWithSalt(byte[] password, byte[] salt);
    }

    [ContractClassFor(typeof(IPasswordHasher))]
    abstract class PasswordHasherContract:IPasswordHasher {
        public byte[] HashPasswordWithSalt(byte[] password, byte[] salt) {
            Contract.Requires(password != null);
            Contract.Requires(salt != null);
            Contract.Ensures(Contract.Result<byte[]>() != null);
            return default(byte[]);
        }
    }
}