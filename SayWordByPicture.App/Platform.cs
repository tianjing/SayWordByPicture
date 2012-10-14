using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SayWordByPicture.Lib.Core;

namespace SayWordByPicture.App
{
    public static class Platform
    {
        static Platform()
        {
            AppSetting = System.IO.IsolatedStorage.IsolatedStorageSettings.ApplicationSettings;
        }
        static System.IO.IsolatedStorage.IsolatedStorageSettings AppSetting{get;set;}

        /// <summary>
        /// 一次出题数量
        /// </summary>
        public static Int32 QuestionNum
        {
            get
            {
                Int32 num = 0;
                if (!AppSetting.TryGetValue("QuestionNum", out num))
                {
                    num = 4;
                    SetData("QuestionNum", num);
                }
                return num;
            }
            set 
            {
                Int32 setvalue=value<=4?4:value;
                setvalue = setvalue >= 6 ? 6 : setvalue;
                SetData("QuestionNum", setvalue);
            }
        }
        private static void SetData(String p_Key, Object value)
        {
            if (!AppSetting.Contains(p_Key))
            {
                AppSetting.Add(p_Key, value);
            }
            else
            {
                AppSetting[p_Key] = value;
            }
            AppSetting.Save();
        }
        /// <summary>
        /// 出题时的发音
        /// </summary>
        public static Language QuestionLanguage
        {
            get
            {
                Language value;
                if (!AppSetting.TryGetValue("QuestionLanguage", out value))
                {
                    value = Language.Enlish;
                    SetData("QuestionLanguage", value);
                }
                return value;
            }
            set 
            {
                SetData("QuestionLanguage", value);
            }
        }
    }
}
