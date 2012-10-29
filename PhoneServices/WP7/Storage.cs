using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhoneServices.Interface;
using System.IO.IsolatedStorage;
using System.IO;
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
        /// ��ȡ�����ļ�
        /// </summary>
        /// <param name="p_FileName">�ļ�����</param>
        /// <returns></returns>
        public  String ReadTextFile(String p_FileName)
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
        /// ��֤�ļ�
        /// </summary>
        /// <param name="p_FilePath">�ļ�·��</param>
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
        /// �����ļ�
        /// </summary>
        /// <param name="p_DirectoryName">�ļ�������</param>
        /// <param name="p_FileName">�ļ�����</param>
        /// <param name="p_bytes">�ļ�����</param>
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
        /// ���ı����� �����ı�����
        /// </summary>
        /// <param name="p_DirectoryName">�ļ�������</param>
        /// <param name="p_FileName">�ļ�����</param>
        /// <param name="p_Text">�ı�����</param>
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
        /// ����Ŀ¼
        /// </summary>
        /// <param name="p_Path">Ŀ¼ȫ·��</param>
        public void CreateDirectory(String p_Path)
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
        public bool DirectoryExists(String p_DirPath)
        {
            return StorageFileManage.DirectoryExists(p_DirPath);
        }
        /// <summary>
        /// �ļ��Ƿ����
        /// </summary>
        /// <param name="p_FilePath">�ļ�·��</param>
        /// <returns></returns>
        public bool FileExists(String p_FilePath)
        {
            return StorageFileManage.FileExists(p_FilePath);
        }
        #endregion
    }
}
