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
        /// ��ȡ����Ŀ¼
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
        /// ����
        /// </summary>
        static IsolatedStorageManager()
        {
            StorageFileManage = IsolatedStorageFile.GetUserStoreForApplication();
        }
        private static IsolatedStorageFile StorageFileManage;

        #region read
        /// <summary>
        /// ��ȡ�����ļ�
        /// </summary>
        /// <param name="p_FileName">�ļ�����</param>
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
        /// ��ȡͼƬ����
        /// </summary>
        /// <param name="p_FileName">�ļ�����</param>
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
        /// ��֤�ļ�
        /// </summary>
        /// <param name="p_FilePath">�ļ�·��</param>
        /// <returns></returns>
        private static bool ValidFilePath(String p_FilePath)
        {
            return StorageFileManage.FileExists(p_FilePath);
        }
        #endregion

        #region write
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="p_DirectoryName">�ļ�������</param>
        /// <param name="p_FileName">�ļ�����</param>
        /// <param name="p_bytes">�ļ�����</param>
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
        /// ���ı����� �����ı�����
        /// </summary>
        /// <param name="p_DirectoryName">�ļ�������</param>
        /// <param name="p_FileName">�ļ�����</param>
        /// <param name="p_Text">�ı�����</param>
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
        /// ����Ŀ¼
        /// </summary>
        /// <param name="p_Path">Ŀ¼ȫ·��</param>
        public static void CreateDirectory(String p_Path)
        {
            StorageFileManage.CreateDirectory(p_Path);
        }
        #endregion
        #region valid
        /// <summary>
        /// �ļ����Ƿ����
        /// </summary>
        /// <param name="p_DirPath">�ļ���·��</param>
        /// <returns></returns>
        public static bool DirectoryExists(String p_DirPath)
        {
            return StorageFileManage.DirectoryExists(p_DirPath);
        }
        /// <summary>
        /// �ļ��Ƿ����
        /// </summary>
        /// <param name="p_FilePath">�ļ�·��</param>
        /// <returns></returns>
        public static bool FileExists(String p_FilePath)
        {
            return StorageFileManage.FileExists(p_FilePath);
        }
        #endregion
    }
}
