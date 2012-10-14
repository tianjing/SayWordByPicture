using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.IO.IsolatedStorage;
using System.IO;
using SayWordByPicture.Lib.Core;

namespace SayWordByPicture.Lib.File
{
    public abstract class FileLoader
    {
        /// <summary>
        /// ��ȡָ��txt�ļ�����
        /// </summary>
        /// <param name="p_IsContent">�Ƿ�����Ŀ�����ݹ�������</param>
        /// <param name="p_FileName">�ļ���</param>
        /// <returns></returns>
        public static String ReadTextFile(bool p_IsContent, String p_FileName)
        {
            if (p_IsContent)
            {
                return ContentManager.ReadTextFile(p_FileName);
            }
            else
            {
                return IsolatedStorageManager.ReadTextFile(p_FileName);
            }
        }
        /// <summary>
        /// ��ȡָ���ļ�����
        /// </summary>
        /// <param name="p_IsContent">�Ƿ�����Ŀ�����ݹ�������</param>
        /// <param name="p_FileName">�ļ���</param>
        /// <returns></returns>
        public static Stream ReadFile(bool p_IsContent, String p_FileName)
        {
            if (p_IsContent)
            {
                return ContentManager.ReadFile(p_FileName);
            }
            else
            {
                return IsolatedStorageManager.ReadFile(p_FileName);
            }
        }
        /// <summary>
        /// ��ȡ�洢Ŀ¼���ļ���
        /// </summary>
        /// <param name="p_SearchPattern">ɸѡ����</param>
        /// <returns></returns>
        public static String[] GetIsolatedStorageDirectory(String p_SearchPattern)
        {
            return IsolatedStorageManager.GetDirectorys(p_SearchPattern);
        }
        /// <summary>
        /// �����û��洢��Ŀ¼
        /// </summary>
        /// <param name="p_Path">ȫ·��</param>
        public static void CreateIsolatedStorageDirectory(String p_Path)
        {
            IsolatedStorageManager.CreateDirectory(p_Path);
        }
        /// <summary>
        /// �ļ����Ƿ����
        /// </summary>
        /// <param name="p_DirPath">�ļ���·��</param>
        /// <returns></returns>
        public static bool IsolatedStorageDirectoryExists(String p_DirPath)
        {
            return IsolatedStorageManager.DirectoryExists(p_DirPath);
        }
        /// <summary>
        /// �ļ��Ƿ����
        /// </summary>
        /// <param name="p_FilePath">�ļ�·��</param>
        /// <returns></returns>
        public static bool IsolatedStorageFileExists(String p_FilePath)
        {
            return IsolatedStorageManager.FileExists(p_FilePath);
        }
        public static void SaveFile(String p_FilePath, ByteBuffe p_Buffe)
        {
            if (!String.IsNullOrEmpty(p_FilePath) && p_Buffe.Count > 0)
            {
                IsolatedStorageManager.CreateImageFile(p_FilePath, p_Buffe.ToArrary());
            }
        }
    }
}
