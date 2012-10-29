using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneServices.Interface
{
    public interface IAppConfig
    {
        /// <summary>
        /// get App save value by key
        /// </summary>
        /// <param name="p_Key">key</param>
        /// <param name="p_Value">value</param>
        /// <returns></returns>
        bool TryGetValue(String p_Key,out Object p_Value);
        /// <summary>
        /// set app save value by key £¨can save data£©
        /// </summary>
        /// <param name="p_Key">key</param>
        /// <param name="p_Value">value</param>
        void SetValue(String p_Key, Object p_Value);
    }
}
