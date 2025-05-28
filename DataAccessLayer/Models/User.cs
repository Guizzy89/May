using System;
using System.Security.Cryptography;
using WebApplication1.DataAccessLayer.Models;

namespace WebApplication1.DataAccessLayer.Models
{
    public class User
    {
        private readonly Guid _userId;
        private readonly string _email;
        private readonly string _firstName;
        private readonly string _lastName;
        private byte[] _passwordHash;

        public Guid UserId => _userId;
        public string Email => _email;
        public string FirstName => _firstName;
        public string LastName => _lastName;
        public virtual Cart Cart { get; set; }

        public virtual ICollection<CartItem> CartItems { get; protected set; }

        public User() { }

        public User(Guid userId, string email, string password, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("Email адрес не может быть пустым.", nameof(email));

            if (string.IsNullOrEmpty(password))
                throw new ArgumentException("Пароль не может быть пустым.", nameof(password));

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("Имя пользователя не может быть пустым.", nameof(firstName));

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Фамилия пользователя не может быть пустой.", nameof(lastName));

            _userId = userId;
            _email = email.ToLowerInvariant();
            _firstName = firstName.Trim();
            _lastName = lastName.Trim();

            SetPassword(password);
            CartItems = [];
        }

        private void SetPassword(string plainTextPassword)
        {
            var salt = GenerateSalt();
            _passwordHash = HashPasswordWithSalt(plainTextPassword, salt);
        }

        private static byte[] GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            return saltBytes;
        }

        private static byte[] HashPasswordWithSalt(string password, byte[] salt)
        {
            using var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            return pbkdf2.GetBytes(32);
        }

        public bool VerifyPassword(string enteredPassword)
        {
            var storedSalt = ExtractSaltFromHash(_passwordHash);
            var enteredHash = HashPasswordWithSalt(enteredPassword, storedSalt);
            return CompareHashes(_passwordHash, enteredHash);
        }

        private static byte[] ExtractSaltFromHash(byte[] hash)
        {
            var salt = new byte[16];
            Array.Copy(hash, 0, salt, 0, 16);
            return salt;
        }

        private static bool CompareHashes(byte[] hashA, byte[] hashB)
        {
            if (hashA.Length != hashB.Length)
                return false;

            for (var i = 0; i < hashA.Length; i++)
            {
                if (hashA[i] != hashB[i])
                    return false;
            }
            return true;
        }
    }
}