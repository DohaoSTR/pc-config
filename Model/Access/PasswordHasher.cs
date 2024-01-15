using System.Security.Cryptography;

namespace PCConfig.Model.Access
{
    public class PasswordHasher
    {
        private const int SaltSize = 16; // Размер соли в байтах
        private const int HashSize = 20; // Размер хэша в байтах
        private const int Iterations = 10000; // Количество итераций для PBKDF2

        public static string HashPassword(string password)
        {
            // Генерация случайной соли
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[SaltSize]);

            // Создание хэша пароля с использованием PBKDF2
            Rfc2898DeriveBytes pbkdf2 = new(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Соединение солью и хэшем для хранения в базе данных
            byte[] hashBytes = new byte[SaltSize + HashSize];
            Array.Copy(salt, 0, hashBytes, 0, SaltSize);
            Array.Copy(hash, 0, hashBytes, SaltSize, HashSize);

            // Преобразование в строку для хранения в базе данных
            string hashedPassword = Convert.ToBase64String(hashBytes);
            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Извлечение соли и хэша из хранимой строки
            byte[] hashBytes = Convert.FromBase64String(hashedPassword);
            byte[] salt = new byte[SaltSize];
            Array.Copy(hashBytes, 0, salt, 0, SaltSize);

            // Вычисление хэша введенного пароля с использованием той же соли
            Rfc2898DeriveBytes pbkdf2 = new(password, salt, Iterations);
            byte[] hash = pbkdf2.GetBytes(HashSize);

            // Сравнение вычисленного хэша с хэшем из хранимой строки
            for (int i = 0; i < HashSize; i++)
            {
                if (hashBytes[i + SaltSize] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
