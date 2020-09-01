using System;
namespace MvvmAspire.Services
{
    public interface IEncryptionService
    {
        string Encrypt(string plainValue);
        string Decrypt(string encryptedValue);
    }
}
