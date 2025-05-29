using System.Security.Cryptography;
using CAStudy.Domain.Accounts.Errors;
using CAStudy.Domain.Accounts.Errors.Exceptions;
using CAStudy.Domain.Shared;
using CAStudy.Domain.Shared.ValueObjects;

namespace CAStudy.Domain.Accounts.ValueObjects;

public sealed record Password : ValueObject
{
    public string HashText { get; } = string.Empty;
    private const int MinimumLength = 12;
    private const int MaximumLength = 48;

    private Password()
    {
    }

    private Password(string plainTextPassword) => HashText = Hash(plainTextPassword);

    public static Password Create(string plainTextPassword)
        => new(plainTextPassword);

    private static string Hash(string password)
    {
        if (string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
            throw new PasswordNullException(ErrorMessages.Password.Invalid);

        if (password.Length < MinimumLength || password.Length > MaximumLength)
            throw new PasswordLengthException(ErrorMessages.Password.InvalidLength);

        password += Configuration.Security.PasswordSaltKey;

        using var algorithm = new Rfc2898DeriveBytes(
            password,
            Configuration.Security.SaltSize,
            Configuration.Security.Iterations,
            HashAlgorithmName.SHA256);
        var key = Convert.ToBase64String(algorithm.GetBytes(Configuration.Security.KeySize));
        var salt = Convert.ToBase64String(algorithm.Salt);

        return
            $"{Configuration.Security.Iterations}{Configuration.Security.SplitChar}{salt}{Configuration.Security.SplitChar}{key}";
    }

    public bool Verify(string hashedString, string plainTextPassword)
    {
        plainTextPassword += Configuration.Security.PasswordSaltKey;

        var parts = hashedString.Split(Configuration.Security.SplitChar, 3);
        if (parts.Length != 3)
            return false;

        var hashIterations = Convert.ToInt32(parts[0]);
        var salt = Convert.FromBase64String(parts[1]);
        var key = Convert.FromBase64String(parts[2]);

        if (hashIterations != Configuration.Security.Iterations)
            return false;

        using var algorithm = new Rfc2898DeriveBytes(
            plainTextPassword,
            salt,
            Configuration.Security.Iterations,
            HashAlgorithmName.SHA256);
        var keyToCheck = algorithm.GetBytes(Configuration.Security.KeySize);

        return keyToCheck.SequenceEqual(key);
    }
}