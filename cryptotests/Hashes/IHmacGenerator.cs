namespace cryptotests.Hashes {
    public interface IHmacGenerator {
        byte[] ComputeHmac(byte[] msgToHash);
    }
}