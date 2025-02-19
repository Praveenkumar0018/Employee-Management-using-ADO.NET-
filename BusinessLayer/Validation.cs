using System.Text.RegularExpressions;

namespace BusinessLayer
{
    public static class Validation
    {
        public static bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        public static bool IsValidPhoneNumber(string phone)
        {
            return Regex.IsMatch(phone, @"^\d{10}$");
        }

        public static bool IsValidAge(int age)
        {
            return age > 18;
        }
    }
}
