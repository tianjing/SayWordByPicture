using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework;

namespace SayWordByPicture.Lib.File
{
    internal static class ContentManager
    {
        /// <summary>
        /// 读取语言文件
        /// </summary>
        /// <param name="p_DirectoryName">文件夹名称</param>
        /// <param name="p_Language">语言类型</param>
        /// <returns></returns>
        public static String ReadTextFile(String p_FileName)
        {
            using (StreamReader stream = new StreamReader
                            (
                             TitleContainer.OpenStream(
                              p_FileName)
                             )
                      )
            {
                return stream.ReadToEnd();
            }
        }
        /// <summary>
        /// 读取图片内容
        /// </summary>
        /// <param name="p_DirectoryName">文件夹名称</param>
        /// <returns></returns>
        public static Stream ReadFile(String p_FileName)
        {
            return TitleContainer.OpenStream( p_FileName);
        }
    }
}
