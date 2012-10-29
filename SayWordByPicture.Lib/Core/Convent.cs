using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SayWordByPicture.Lib.Core
{
    public static class Convent
    {
        public static String Base64ToString(byte[] p_Vaule)
        {
            if (null == p_Vaule)
            {
                return String.Empty;
            }
           return  Convert.ToBase64String(p_Vaule);
        }
        public static byte[] StringToBase64(String p_Value)
        {
            if (String.IsNullOrEmpty(p_Value))
            { 
                return new byte[1];
            }
            return Convert.FromBase64String(p_Value);
        }
        public static byte[] StreamToByte(Stream p_Value)
        {
            if (null == p_Value)
            {
                return null ;
            }
            byte[] bytes = new byte[p_Value.Length];
            if (p_Value.CanSeek)
            {
                p_Value.Seek(0,SeekOrigin.Begin);
            }
            p_Value.Read(bytes, 0, bytes.Length);
            return bytes;
        }

        public static Stream StreamToString(String p_Value)
        {
            byte[] bytes = StringToBase64(p_Value);
            MemoryStream ms = new MemoryStream(bytes);
            return ms;
        }

    }
}
