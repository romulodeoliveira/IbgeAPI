using System.Security.Cryptography;

namespace IbgeApi.Authentication;

public class Password
{
    public void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512())
        {
            passwordSalt = hmac.Key;
            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
        }
    }
    
    public bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
    {
        using (var hmac = new HMACSHA512(passwordSalt))
        {
            var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            return computedHash.SequenceEqual(passwordHash);
        }
    }

    public bool CheckerStrongPassword(string password)
    {
        if (password.Length < 6 || password.Length > 12)
        {
            return false;
        }

        if (!password.Any(c => char.IsDigit(c)))
        {
            return false;
        }

        if (!password.Any(c => char.IsUpper(c)))
        {
            return false;
        }

        if (!password.Any(c => char.IsLower(c)))
        {
            return false;
        }

        if (!password.Any(c => char.IsSymbol(c)))
        {
            return false;
        }

        var repeatedCounter = 0;
        var lastCharacter = '\0';

        foreach (var c in password)
        {
            if (c == lastCharacter)
            {
                repeatedCounter++;
            }
            else
            {
                repeatedCounter = 0;
            }

            if (repeatedCounter == 2)
            {
                return false;
            }

            lastCharacter = c;
        }

        return true;
    }
}