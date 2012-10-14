using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SayWordByPicture.Lib.Core;

namespace SayWordByPicture.Data
{
    /// <summary>
    /// ������Ϣ
    /// </summary>
    public class LanguageInfo:IDisposable
    {
        /// <summary>
        /// ����
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// ����
        /// </summary>
        public String Text { get; set; }
        /// <summary>
        /// �����ļ�
        /// </summary>
        public ByteBuffe Voice { get; set; }
        /// <summary>
        ///  this is Vaild
        /// </summary>
        public bool IsVaild { get { return !String.IsNullOrEmpty(Name) && !String.IsNullOrEmpty(Text) && Voice.Count > 0; } }
        public void Dispose()
        {
            if (null != Voice)
            {
                Voice.Dispose();
            }
            Voice = null;
        }
    }
}
