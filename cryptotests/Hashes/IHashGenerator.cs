namespace cryptotests.Hashes {
    public interface IHashGenerator {
        byte[] ComputeHashForMessage(byte[] msg);
    }
}