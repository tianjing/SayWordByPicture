using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.IO;
using System.IO.IsolatedStorage;
namespace SayWordByPicture.Lib.File
{
    internal static class IsolatedStorageManager
    {
        /// <summary>
        /// 获取所有目录
        /// </summary>
        /// <returns></returns>
        public static String[] GetDirectorys(string p_SearchPattern)
        {
            if (String.IsNullOrEmpty(p_SearchPattern))
            {
                return StorageFileManage.GetDirectoryNames();
            }
            else
            {
                return StorageFileManage.GetDirectoryNames(p_SearchPattern);
            }
        }
        /// <summary>
        /// 构造
        /// </summary>
        static IsolatedStorageManager()
        {
            StorageFileManage = IsolatedStorageFile.GetUserStoreForApplication();
        }
        private static IsolatedStorageFile StorageFileManage;

        #region read
        /// <summary>
        /// 读取语言文件
        /// </summary>
        /// <param name="p_FileName">文件名称</param>
        /// <returns></returns>
        public static String ReadTextFile(String p_FileName)
        {
            String path = String.Empty;
            if (ValidFilePath(p_FileName))
            {
                using (StreamReader stream = new StreamReader
                                (
                                 StorageFileManage.OpenFile(path,
                                 FileMode.Open)
                                 )
                          )
                {
                    return stream.ReadToEnd();
                }
            }
            return String.Empty;
        }
        /// <summary>
        /// 读取图片内容
        /// </summary>
        /// <param name="p_FileName">文件名称</param>
        /// <returns></returns>
        public static Stream ReadFile(String p_FileName)
        {
            if (ValidFilePath(p_FileName))
            {
                return StorageFileManage.OpenFile(p_FileName,
                      FileMode.Open);
            }
            return null;
        }
        /// <summary>
        /// 验证文件
        /// </summary>
        /// <param name="p_FilePath">文件路径</param>
        /// <returns></returns>
        private static bool ValidFilePath(String p_FilePath)
        {
            return StorageFileManage.FileExists(p_FilePath);
        }
        #endregion

        #region write
        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="p_DirectoryName">文件夹名称</param>
        /// <param name="p_FileName">文件名称</param>
        /// <param name="p_bytes">文件内容</param>
        /// <returns></returns>
        public static bool CreateImageFile(String p_FilePath, byte[] p_bytes)
        {
            String path = Path.GetDirectoryName(p_FilePath);
            if (!IsolatedStorageManager.DirectoryExists(path))
            {
                IsolatedStorageManager.CreateDirectory(path);
            }

            if (!ValidFilePath(p_FilePath))
            {
                using (IsolatedStorageFileStream stream = StorageFileManage.OpenFile(p_FilePath, FileMode.Create))
                {
                    stream.Write(p_bytes, 0, p_bytes.Length);
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 将文本内容 创建文本保存
        /// </summary>
        /// <param name="p_DirectoryName">文件夹名称</param>
        /// <param name="p_FileName">文件名称</param>
        /// <param name="p_Text">文本内容</param>
        /// <returns></returns>
        public static bool CreateTextFile(String p_DirectoryName, String p_FileName, String p_Text)
        {
            String path = String.Empty;
            if (!ValidFilePath(p_FileName))
            {
                using (StreamWriter stream = new StreamWriter(StorageFileManage.OpenFile(path, FileMode.Create)))
                {
                    stream.WriteLine(p_Text);
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="p_Path">目录全路径</param>
        public static void CreateDirectory(String p_Path)
        {
            StorageFileManage.CreateDirectory(p_Path);
        }
        #endregion
        #region valid
        /// <summary>
        /// 文件夹是否存在
        /// </summary>
        /// <param name="p_DirPath">文件夹路径</param>
        /// <returns></returns>
        public static bool DirectoryExists(String p_DirPath)
        {
            return StorageFileManage.DirectoryExists(p_DirPath);
        }
        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="p_FilePath">文件路径</param>
        /// <returns></returns>
        public static bool FileExists(String p_FilePath)
        {
            return StorageFileManage.FileExists(p_FilePath);
        }
        #endregion
    }
}
