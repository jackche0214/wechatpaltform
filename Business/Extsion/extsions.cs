using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public static string Md5Encrypt(string PassWord,int CodeLength )
        {
            if (!string.IsNullOrEmpty(PassWord))
            {
                if (CodeLength == 16)//16位加密
                {
                    var md5 =new MD5CryptoServiceProvider();//创建MD5对象（MD5类为抽象类不能被实例化）
                    string t2 = BitConverter.ToString(md5.ComputeHash(Encoding.Default.GetBytes(PassWord)),4,8);
                    t2 = t2.Replace("-", "").ToLower();
                    return t2;
                }
                if (CodeLength == 32)
                {
                    string cl = PassWord;
                    string pwd = "";
                    MD5 md5 = MD5.Create(); //实例化一个md5对像
                                            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择
                    byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
                    // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
                    for (int i = 0; i < s.Length; i++)
                    {
                        // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，如果使用大写（X）则格式后的字符是大写字符 
                        pwd = pwd + s[i].ToString("X");
                    }
                    pwd = pwd.ToLower();
                    return pwd;
                }
                if (CodeLength == 64)
                {
                    string cl = PassWord;
                    //string pwd = "";
                    MD5 md5 = MD5.Create(); //实例化一个md5对像
                                            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
                    byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(cl));
                    return Convert.ToBase64String(s);
                }
            }
            return string.Empty;
        }
      

    }
}
