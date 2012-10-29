using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
namespace SayWordByPicture.Lib.Core
{
    public enum Language
    {
        /// <summary>
        /// ÖÐÎÄ
        /// </summary>
        [Description("zh-cn")]
        Chinese,
        /// <summary>
        /// Ó¢ÎÄ
        /// </summary>
        
        Enlish,
    }
    public static class LanguageExt
    {
        public static String GetDescription(this Language p_Language)
        {
            Type type = typeof(Language);
            FieldInfo info = type.GetField(p_Language.ToString());  
            DescriptionAttribute descriptionAttribute= info.GetCustomAttributes(typeof (DescriptionAttribute), true)[0] as DescriptionAttribute;  
            if (descriptionAttribute != null)  
                return descriptionAttribute.Description;  
            else  
                return type.ToString(); 

        }
    }
}
