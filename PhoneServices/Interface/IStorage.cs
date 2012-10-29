using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PhoneServices.Interface
{
    public interface IStorage
    {
                /// <summary>
        /// ��ȡ����Ŀ¼
        /// </summary>
        /// <returns></returns>
        String[] GetDirectorys(string p_SearchPattern);

        #region read
        /// <summary>
        /// ��ȡ�����ļ�
        /// </summary>
        /// <param name="p_FileName">�ļ�����</param>
        /// <returns></returns>
        String ReadTextFile(String p_FileName);
        /// <summary>
        /// ��ȡͼƬ����
        /// </summary>
        /// <param name="p_FileName">�ļ�����</param>
        /// <returns></returns>
        Stream ReadFile(String p_FileName);

        #endregion

        #region write
        /// <summary>
        /// delete file (if file exists)
        /// </summary>
        /// <param name="p_FilePath">file path</param>
        void DeleteFile(String p_FilePath);
        /// <summary>
        /// �����ļ�
        /// </summary>
        /// <param name="p_DirectoryName">�ļ�������</param>
        /// <param name="p_FileName">�ļ�����</param>
        /// <param name="p_bytes">�ļ�����</param>
        /// <returns></returns>
        bool CreateFile(String p_FilePath, byte[] p_bytes);
        /// <summary>
        /// ���ı����� �����ı�����
        /// </summary>
        /// <param name="p_DirectoryName">�ļ�������</param>
        /// <param name="p_FileName">�ļ�����</param>
        /// <param name="p_Text">�ı�����</param>
        /// <returns></returns>
        bool CreateTextFile(String p_DirectoryName, String p_FileName, String p_Text);
        /// <summary>
        /// ����Ŀ¼
        /// </summary>
        /// <param name="p_Path">Ŀ¼ȫ·��</param>
        void CreateDirectory(String p_Path);
        #endregion
        #region valid
        /// <summary>
        /// �ļ����Ƿ����
        /// </summary>
        /// <param name="p_DirPath">�ļ���·��</param>
        /// <returns></returns>
        bool DirectoryExists(String p_DirPath);
        /// <summary>
        /// �ļ��Ƿ����
        /// </summary>
        /// <param name="p_FilePath">�ļ�·��</param>
        /// <returns></returns>
        bool FileExists(String p_FilePath);
        #endregion
    }
}
