using System.Text;

namespace Utilities.Utilities
{
    public static class RandomGenerator
    {
        private static readonly Random rng = new Random();
        private const string allowedChar = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()";

        public static string GenerateRandomString(int length)
        {
            StringBuilder randomString = new StringBuilder(length);
            for (int i = 0; i < length; i++)
            {
                randomString.Append(allowedChar[rng.Next(allowedChar.Length)]);
            }
            return randomString.ToString();
        }

        public static DateTime GenerateRandomDate(DateTime startDate)
        {
            int range = (DateTime.Today - startDate).Days;
            return startDate.AddDays(rng.Next(range));
        }

        public static int GenerateSarkiNumber(int minValue, int maxValue)
        {
            return rng.Next(minValue, maxValue + 1);
        }
    }
}
