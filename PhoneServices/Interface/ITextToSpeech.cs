using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PhoneServices.Interface
{
    public interface ITextToSpeech
    {
        /// <summary>
        /// 获取音频文件
        /// </summary>
        /// <param name="p_Language">语言</param>
        /// <param name="p_Text">文字内容</param>
        /// <param name="p_FilePath">保存音频文件路径</param>
        /// <param name="p_CallBack">下载完成后执行函数</param>
        void GetSound(string p_Language, string p_Text,Action<Stream> p_CallBack);
    }
}
