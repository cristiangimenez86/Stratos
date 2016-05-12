namespace Stratos.Service.Contract
{
    public interface ICryptoService
    {
        string Encrypt(string unencrypted);
        string Decrypt(string encrypted);
    }
}
