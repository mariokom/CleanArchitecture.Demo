namespace CAD.Core.Shared.Interfaces
{
    public interface IHashManager
    {
        public string Hash(string value, string salt);

        public string CreateSalt();

    }
}
