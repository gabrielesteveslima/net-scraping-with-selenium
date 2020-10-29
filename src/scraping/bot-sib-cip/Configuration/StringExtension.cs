namespace CipScrapingBot.Configuration
{
    public static class StringExtension
    {
        public static string Cleaned(this string value)
        {
            return value.Replace("\n", "").Replace("\r", "").Trim();
        }
    }
}