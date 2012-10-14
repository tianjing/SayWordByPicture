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
        /// 读取指定txt文件内容
        /// </summary>
        /// <param name="p_IsContent">是否在项目的内容管理器里</param>
        /// <param name="p_FileName">文件名</param>
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
        /// 读取指定文件内容
        /// </summary>
        /// <param name="p_IsContent">是否在项目的内容管理器里</param>
        /// <param name="p_FileName">文件名</param>
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
        /// 获取存储目录的文件夹
        /// </summary>
        /// <param name="p_SearchPattern">筛选条件</param>
        /// <returns></returns>
        public static String[] GetIsolatedStorageDirectory(String p_SearchPattern)
        {
            return IsolatedStorageManager.GetDirectorys(p_SearchPattern);
        }
        /// <summary>
        /// 创建用户存储区目录
        /// </summary>
        /// <param name="p_Path">全路径</param>
        public static void CreateIsolatedStorageDirectory(String p_Path)
        {
            IsolatedStorageManager.CreateDirectory(p_Path);
        }
        /// <summary>
        /// 文件夹是否存在
        /// </summary>
        /// <param name="p_DirPath">文件夹路径</param>
        /// <returns></returns>
        public static bool IsolatedStorageDirectoryExists(String p_DirPath)
        {
            return IsolatedStorageManager.DirectoryExists(p_DirPath);
        }
        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="p_FilePath">文件路径</param>
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
