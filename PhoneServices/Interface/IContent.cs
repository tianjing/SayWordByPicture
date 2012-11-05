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
        /// 取图文件内容
        /// </summary>
        /// <param name="p_FilePath">文件全路径</param>
        /// <returns></returns>
        Stream ReadFile(String p_FilePath);
    }
}
