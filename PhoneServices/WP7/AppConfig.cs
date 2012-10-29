using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;
using PhoneServices.Interface;

namespace PhoneServices
{
    public class AppConfig : IAppConfig
    {
        static AppConfig()
        {
            AppSetting = IsolatedStorageSettings.ApplicationSettings;
        }
        private AppConfig()
        {
        }
        static IAppConfig m_Current;
        public static IAppConfig Current 
        { 
            get 
            {
                if (null == m_Current)
                {
                    m_Current = new AppConfig();
                }
                return m_Current; 
            }
        }
        static System.IO.IsolatedStorage.IsolatedStorageSettings AppSetting { get;  set; }
        /// <summary>
        /// get App save value by key
        /// </summary>
        /// <param name="p_Key">key</param>
        /// <param name="p_Value">value</param>
        /// <returns></returns>
        public bool TryGetValue(string p_Key,out object p_Value)
        {
           return  AppSetting.TryGetValue(p_Key,out p_Value);
        }
        /// <summary>
        /// set app save value by key £¨can save data£©
        /// </summary>
        /// <param name="p_Key">key</param>
        /// <param name="p_Value">value</param>
        public void SetValue(string p_Key, object p_Value)
        {
            if (!AppSetting.Contains(p_Key))
            {
                AppSetting.Add(p_Key, p_Value);
            }
            else
            {
                AppSetting[p_Key] = p_Value;
            }
            AppSetting.Save();
        }

    }
}
