namespace Week_1Assignment.Assignment1
{
    public class CountryNameLookup
    {
        // Dictionary to map country codes to full names
        private static readonly Dictionary<string, string> CountryDictionary =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            {
                { "IN", "India" },
                { "US", "United States of America" },
                { "NZ", "New Zealand" },
                { "CN", "China" },
                { "RU", "Russia" },
                { "PK", "Pakistan" },
                { "CA", "Canada" },
            };

        /// <summary>
        /// Fetches the full country name for a given country code.
        /// </summary>
        /// <param name="countryCode">The country code (e.g., IN, US, NZ).</param>
        /// <returns>The full country name if found, otherwise a custom message.</returns>
        private static string GetCountryName(string countryCode)
        {
            return CountryDictionary.TryGetValue(countryCode, out var countryName)
                   ? countryName
                   : $"Record does not exist for the Country code: {countryCode}";
        }

        private static void DisplayCountryName(string countryCode)
        {
            var countryName = GetCountryName(countryCode);

            if (countryName != null)
            {
                Console.WriteLine($"\nCountry Code: {countryCode}");
                Console.WriteLine($"\nCountry Name: {countryName}");
            }
            else
            {
                Console.WriteLine("\nError: Country code was not found in the database.");
            }
        }

        public static void RunCountryLookupLoop()
        {
            while (true)
            {
                Console.Write("\nEnter a Country Code (e.g., IN/US/NZ) or type QUIT to exit: ");
                var input = Console.ReadLine()?.Trim().ToUpper();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty. Try again.");
                    continue;
                }

                if (input == "QUIT")
                {
                    Console.WriteLine("Exiting the program.");
                    break;
                }
                DisplayCountryName(input);
            }
        }
    }
}
