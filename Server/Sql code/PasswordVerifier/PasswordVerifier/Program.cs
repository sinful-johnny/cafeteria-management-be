using System;
using Microsoft.AspNetCore.Identity;

public class Program
{
    public static void Main(string[] args)
    {
        // Example usage of PasswordHelper
        var passwordHelper = new PasswordHelper();
        string password = "MySecurePassword";

        // Hash a password first
        var passwordHasher = new PasswordHasher<object>();
        string hashedPassword = passwordHasher.HashPassword(null, password);

        Console.WriteLine("Password Verification Example");
        Console.WriteLine($"Original Password: {password}");
        Console.WriteLine($"Hashed Password: {hashedPassword}");

        // Verify the password
        bool isValid = passwordHelper.VerifyPassword(password, hashedPassword);
        Console.WriteLine($"Password is valid: {isValid}");
    }
}

public class PasswordHelper
{
    private readonly PasswordHasher<object> _passwordHasher = new PasswordHasher<object>();

    public bool VerifyPassword(string password, string hashedPassword)
    {
        var result = _passwordHasher.VerifyHashedPassword(null, hashedPassword, password);
        return result == PasswordVerificationResult.Success;
    }
}