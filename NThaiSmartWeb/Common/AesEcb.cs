using System;
using System.Security.Cryptography;
using System.Text;

public class AesEcb
{

    private static readonly byte[] Key = Encoding.UTF8.GetBytes("Netk@Sy$temKi0sk"); // 16 bytes key

    public static string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform encryptor = aes.CreateEncryptor();

            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            byte[] encryptedBytes = encryptor.TransformFinalBlock(plainBytes, 0, plainBytes.Length);

            return Convert.ToBase64String(encryptedBytes);
        }
    }

    public static string Decrypt(string base64Cipher)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Key;
            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;

            ICryptoTransform decryptor = aes.CreateDecryptor();

            byte[] cipherBytes = Convert.FromBase64String(base64Cipher);
            byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);

            return Encoding.UTF8.GetString(decryptedBytes);
        }
    }

    // ตัวอย่างเรียกใช้งาน
    public static void Main()
    {
        string original = "ทดสอบข้อความ";
        string encrypted = Encrypt(original);
        string decrypted = Decrypt(encrypted);

        Console.WriteLine($"Original: {original}");
        Console.WriteLine($"Encrypted: {encrypted}");
        Console.WriteLine($"Decrypted: {decrypted}");
    }
}