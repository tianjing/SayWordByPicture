using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PhoneServices.Interface
{
    public interface IContent
    {
         /// <summary>
        /// ȡͼ�ļ�����
        /// </summary>
        /// <param name="p_FilePath">�ļ�ȫ·��</param>
        /// <returns></returns>
        Stream ReadFile(String p_FilePath);
    }
}
