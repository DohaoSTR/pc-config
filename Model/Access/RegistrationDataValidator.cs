using System.Text.RegularExpressions;

namespace PCConfig.Model.Access
{
    public static class RegistrationDataValidator
    {
        public static bool IsValidEmailFormat(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        public static bool IsStrongPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()-_=+[\]{}|;:'"",.<>/?]).{8,}$";
            return Regex.IsMatch(password, pattern);
        }

        public static string GetPasswordErrorDescription(string password)
        {
            if (!password.Any(char.IsLower))
            {
                return "Отсутствует строчная буква.";
            }

            if (!password.Any(char.IsUpper))
            {
                return "Отсутствует заглавная буква.";
            }

            if (!password.Any(char.IsDigit))
            {
                return "Отсутствует цифра.";
            }

            string specialCharacters = @"!@#$%^&*()-_=+[]{}|;:'\"",.<>?/ ";
            return !password.Any(specialCharacters.Contains) ? "Отсутствует специальный символ." : "";
        }
    }
}
