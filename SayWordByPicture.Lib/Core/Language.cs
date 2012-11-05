using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace SayWordByPicture.Lib.Core
{
    public enum Language
    {
        /// <summary>
        /// 中文
        /// </summary>
        [Description("zh-chs")]
        Chinese,
        /// <summary>
        /// 英文
        /// </summary>
        [Description("en")]
        Enlish,
    }
    public static class LanguageExt
    {
        public static String GetDescription(this Language p_Language)
        {
            Type type = p_Language.GetType();
            MemberInfo[] memInfo = type.GetMember(p_Language.ToString());
            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(System.ComponentModel.DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return String.Empty;
        }
    }

}
