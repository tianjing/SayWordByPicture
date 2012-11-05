using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhoneServices.Interface;
using System.IO.IsolatedStorage;
using System.IO;
using System.Threading;
namespace PhoneServices
{
    public sealed class Storage : IStorage
    {
        private Storage()
        { }
        static IStorage m_Current;
        public static IStorage Current
        {
            get
            {
                if (null == m_Current)
                {
                    m_Current = new Storage();
                }
                return m_Current;
            }
        }
        IsolatedStorageFile StorageFileManage = IsolatedStorageFile.GetUserStoreForApplication();
        public string[] GetDirectorys(string p_SearchPattern)
        {
            if (string.IsNullOrEmpty(p_SearchPattern))
            {
                return StorageFileManage.GetDirectoryNames();
            }
            else
            {
                return StorageFileManage.GetDirectoryNames(p_SearchPattern);
            }
        }

        #region read
        /// <summary>
        /// 读取语言文件
        /// </summary>
        /// <param name="p_FilePath">文件名称</param>
        /// <returns></returns>
        public String ReadTextFile(String p_FilePath)
        {
            if (ValidFilePath(p_FilePath))
            {
                using (StreamReader stream = new StreamReader
                                (
                                 StorageFileManage.OpenFile(p_FilePath,
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
        public  Stream ReadFile(String p_FileName)
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
        private  bool ValidFilePath(String p_FilePath)
        {
            return StorageFileManage.FileExists(p_FilePath);
        }
        #endregion

        #region write
        /// <summary>
        /// delete file (if file exists)
        /// </summary>
        /// <param name="p_FilePath">file path</param>
        public void DeleteFile(String p_FilePath)
        {
            if (FileExists(p_FilePath))
            {
                DeleteFile(p_FilePath);
            }
        }

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="p_DirectoryName">文件夹名称</param>
        /// <param name="p_FileName">文件名称</param>
        /// <param name="p_bytes">文件内容</param>
        /// <returns></returns>
        public bool CreateFile(String p_FilePath, byte[] p_bytes)
        {
            String path = Path.GetDirectoryName(p_FilePath);
            if (!DirectoryExists(path))
            {
                CreateDirectory(path);
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
        public  bool CreateTextFile(String p_DirectoryName, String p_FileName, String p_Text)
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
        public void CreateDirectory(String p_Path)
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
        public bool DirectoryExists(String p_DirPath)
        {
            return StorageFileManage.DirectoryExists(p_DirPath);
        }
        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="p_FilePath">文件路径</param>
        /// <returns></returns>
        public bool FileExists(String p_FilePath)
        {
            return StorageFileManage.FileExists(p_FilePath);
        }
        #endregion
    }
}
