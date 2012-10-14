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
        /// ��ȡ�����ļ�
        /// </summary>
        /// <param name="p_DirectoryName">�ļ�������</param>
        /// <param name="p_Language">��������</param>
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
        /// ��ȡͼƬ����
        /// </summary>
        /// <param name="p_DirectoryName">�ļ�������</param>
        /// <returns></returns>
        public static Stream ReadFile(String p_FileName)
        {
            return TitleContainer.OpenStream( p_FileName);
        }
    }
}
