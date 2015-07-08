namespace cryptotests.Passwords {
    public interface IPasswordHasher {
        byte[] HashPasswordWithSalt(byte[] password, byte[] salt);
    }
}