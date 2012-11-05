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
        /// 获取所有目录
        /// </summary>
        /// <returns></returns>
        String[] GetDirectorys(string p_SearchPattern);

        #region read
        /// <summary>
        /// 读取语言文件
        /// </summary>
        /// <param name="p_FileName">文件名称</param>
        /// <returns></returns>
        String ReadTextFile(String p_FileName);
        /// <summary>
        /// 读取图片内容
        /// </summary>
        /// <param name="p_FileName">文件名称</param>
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
        /// 保存文件
        /// </summary>
        /// <param name="p_DirectoryName">文件夹名称</param>
        /// <param name="p_FileName">文件名称</param>
        /// <param name="p_bytes">文件内容</param>
        /// <returns></returns>
        bool CreateFile(String p_FilePath, byte[] p_bytes);
        /// <summary>
        /// 将文本内容 创建文本保存
        /// </summary>
        /// <param name="p_DirectoryName">文件夹名称</param>
        /// <param name="p_FileName">文件名称</param>
        /// <param name="p_Text">文本内容</param>
        /// <returns></returns>
        bool CreateTextFile(String p_DirectoryName, String p_FileName, String p_Text);
        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="p_Path">目录全路径</param>
        void CreateDirectory(String p_Path);
        #endregion
        #region valid
        /// <summary>
        /// 文件夹是否存在
        /// </summary>
        /// <param name="p_DirPath">文件夹路径</param>
        /// <returns></returns>
        bool DirectoryExists(String p_DirPath);
        /// <summary>
        /// 文件是否存在
        /// </summary>
        /// <param name="p_FilePath">文件路径</param>
        /// <returns></returns>
        bool FileExists(String p_FilePath);
        #endregion
    }
}
