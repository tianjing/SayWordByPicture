using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneServices.Interface
{
    public interface ITextToSpeech
    {
        /// <summary>
        /// ��ȡ��Ƶ�ļ�
        /// </summary>
        /// <param name="p_Language">����</param>
        /// <param name="p_Text">��������</param>
        /// <param name="p_FilePath">������Ƶ�ļ�·��</param>
        /// <param name="p_CallBack">������ɺ�ִ�к���</param>
        void GetSound(string p_Language, string p_Text, Action<object> p_CallBack);
    }
}
