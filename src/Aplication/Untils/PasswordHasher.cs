using Isopoh.Cryptography.Argon2;

namespace Application.Untils;

public class PasswordHasher
{
    public static string Hash(string password)
    {
        return Argon2.Hash(password);
    }

    public static bool Verify(string hashed, string password)
    {
        return Argon2.Verify(hashed, password);
    }
}