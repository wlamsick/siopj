using System;
using System.Security.Cryptography;
using System.Text;

namespace Common.Domain.Security;

public static class DataEncryption
{
    public const int SALT_BYTE_SIZE = 24;
    public const int HASH_BYTE_SIZE = 24;
    public const int PBKDF2_ITERATIONS = 1000;

    public const int ITERATION_INDEX = 0;
    public const int SALT_INDEX = 1;
    public const int PBKDF2_INDEX = 2;
    private const string delimiter = ":";

    public static string CreateHash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SALT_BYTE_SIZE);

        byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
        return PBKDF2_ITERATIONS + delimiter +
            Convert.ToBase64String(salt) + delimiter +
            Convert.ToBase64String(hash);
    }

    public static byte[] CreateHashAsByte(string password)
    {
        var passwordHash = CreateHash(password);
        return Encoding.UTF8.GetBytes(passwordHash);
    }

    public static string ConvertRandomNumberToString(byte[] number)
    {
        return Encoding.UTF8.GetString(number);
    }

    public static int CreateRandomNumber(int length = 6)
    {
        return Random.Shared.Next(999999);
    }

    public static bool ValidateHash(string password, string correctHash)
    {
        string[] split = correctHash.Split(delimiter);
        int iterations = Int32.Parse(split[ITERATION_INDEX]);
        byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
        byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

        byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
        return SlowEquals(hash, testHash);
    }

    public static bool ValidateHashByte(string password, byte[] correctHash)
    {
        string hash = Encoding.UTF8.GetString(correctHash);
        return ValidateHash(password, hash);
    }

    private static bool SlowEquals(byte[] a, byte[] b)
    {
        uint diff = (uint)a.Length ^ (uint)b.Length;
        for (int i = 0; i < a.Length && i < b.Length; i++)
            diff |= (uint)(a[i] ^ b[i]);
        return diff == 0;
    }

    private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
    {
        Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations, new HashAlgorithmName("SHA256"));
        return pbkdf2.GetBytes(outputBytes);
    }
}
