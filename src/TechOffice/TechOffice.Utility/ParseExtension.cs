using System;

namespace AnThinhPhat.Utilities
{
    public static class ParseExtension
    {
        public static int ParseInt32(this string value)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
            {
                throw new Exception("Value can't is null or empty");
            }
            else
            {
                return ParseInt32(value, 0);
            }
        }

        public static int ParseInt32(this string value, int valueDefaultIfNull)
        {
            return (string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value)) ? valueDefaultIfNull
                 : Convert.ToInt32(value);
        }
    }
}
