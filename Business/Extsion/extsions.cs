using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extsion
{
    public static class extsions
    {
        public static void Foreach<T>(this IEnumerable<T> list, Action<T> action)
        {
            foreach (T item in list)
            {
                action(item);
            }
        }
        public static string FormartWith(this string value, params object[] obj)
        {
            return string.Format(value, obj);
        }

        public static bool IsNotNull(this string input )
        {
            return !string.IsNullOrEmpty(input);
        }
        public static List<string> ToStrList(this string str, char split)
        {
            if (str.IsNull()) return new List<string>();
            return new List<string>(str.ToStrArray(split));
        }
        public static bool IsNull(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static string[] ToStrArray(this string str, char split)
        {
            if (str.IsNull()) return new string[] { };

            return str.Split(new char[] { split }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
