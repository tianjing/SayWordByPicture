using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SayWordByPicture.Lib.Core;
using PhoneServices;

namespace SayWordByPicture.App
{
    public static class Platform
    {

        /// <summary>
        /// 一次出题数量
        /// </summary>
        public static Int32 QuestionNum
        {
            get
            {
                Int32 num = 0;
                Object obj;
                if (! AppConfig.Current.TryGetValue("QuestionNum", out obj))
                {
                    num = 4;
                    AppConfig.Current.SetValue("QuestionNum", num);
                }
                else
                {
                    num = (Int32)obj;
                }
                return num;
            }
            set 
            {
                Int32 setvalue=value<=4?4:value;
                setvalue = setvalue >= 6 ? 6 : setvalue;
                AppConfig.Current.SetValue("QuestionNum", setvalue);
            }
        }
        /// <summary>
        /// 出题时的发音
        /// </summary>
        public static Language QuestionLanguage
        {
            get
            {
                Language value;
                Object obj;
                if (!AppConfig.Current.TryGetValue("QuestionLanguage", out obj))
                {
                    value = Language.Enlish;
                    AppConfig.Current.SetValue("QuestionLanguage", value);
                }
                else
                {
                    value = (Language)obj;
                }
                return value;
            }
            set 
            {
                AppConfig.Current.SetValue("QuestionLanguage", value);
            }
        }
    }
}
