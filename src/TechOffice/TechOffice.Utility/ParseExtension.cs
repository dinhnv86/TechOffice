using System;
using System.Globalization;
using System.Text.RegularExpressions;

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

        public static string StringUrl(this string str)
        {
            return str.Trim().TrimEnd().TrimStart().Replace('/', '-').Replace('*', '-').Replace('?', '-').Replace(' ', '-');
        }

        public static string RejectMarks(this string text)
        {
            string[] pattern = new string[15];

            pattern[0] = "a|(á|ả|à|ạ|ã|ă|ắ|ẳ|ằ|ặ|ẵ|â|ấ|ẩ|ầ|ậ|ẫ)";
            pattern[1] = "A|(Á|Ả|À|Ạ|Ã|Ă|Ắ|Ẳ|Ằ|Ặ|Ẵ|Â|Ấ|Ẩ|Ầ|Ậ|Ẫ)";
            pattern[2] = "o|(ó|ỏ|ò|ọ|õ|ô|ố|ổ|ồ|ộ|ỗ|ơ|ớ|ở|ờ|ợ|ỡ)";
            pattern[3] = "O|(Ó|Ỏ|Ò|Ọ|Õ|Ô|Ố|Ổ|Ồ|Ộ|Ỗ|Ơ|Ớ|Ở|Ờ|Ợ|Ỡ)";
            pattern[4] = "e|(é|è|ẻ|ẹ|ẽ|ê|ế|ề|ể|ệ|ễ)";
            pattern[5] = "E|(É|È|Ẻ|Ẹ|Ẽ|Ê|Ế|Ề|Ể|Ệ|Ễ)";
            pattern[6] = "u|(ú|ù|ủ|ụ|ũ|ư|ứ|ừ|ử|ự|ữ)";
            pattern[7] = "U|(Ú|Ù|Ủ|Ụ|Ũ|Ư|Ứ|Ừ|Ử|Ự|Ữ)";
            pattern[8] = "i|(í|ì|ỉ|ị|ĩ)";
            pattern[9] = "I|(Í|Ì|Ỉ|Ị|Ĩ)";
            pattern[10] = "y|(ý|ỳ|ỷ|ỵ|ỹ)";
            pattern[11] = "Y|(Ý|Ỳ|Ỷ|Ỵ|Ỹ)";
            pattern[12] = "d|đ";
            pattern[13] = "D|Đ";
            pattern[14] = "-|(/|\\| )";

            for (int i = 0; i < pattern.Length; i++)
            {
                // kí tự sẽ thay thế

                char replaceChar = pattern[i][0];

                MatchCollection matchs = Regex.Matches(text, pattern[i]);

                foreach (Match m in matchs)
                {
                    text = text.Replace(m.Value[0], replaceChar);
                }
            }
            return text.StringUrl();
        }

        /// <summary>
        /// Compare Date (yyyy,MM,dd)
        /// If first is greater or equal then return true, otherwise then false
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool CompareDate(this DateTime? first, DateTime? second)
        {
            if (first == null || second == null)
                return false;

            return CompareDate(first.Value, second.Value);
        }

        public static bool CompareDate(this DateTime first, DateTime second)
        {
            var result = DateTime.Compare(
                  new DateTime(first.Year, first.Month, first.Day, 0, 0, 0),
                  new DateTime(second.Year, second.Month, second.Day));

            return result >= 0 ? true : false;
        }

        public static DateTime? ParseDate(this string date)
        {
            if (!string.IsNullOrEmpty(date))
                return DateTime.Parse(date, new CultureInfo("vi-VN"));

            return null;
        }
    }
}
