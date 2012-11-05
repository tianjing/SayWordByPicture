using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using SayWordByPicture.Lib.Core;

namespace SayWordByPicture.Data
{
    /// <summary>
    /// 语言信息
    /// </summary>
    public class LanguageInfo:IDisposable
    {
        /// <summary>
        /// 名称
        /// </summary>
        public String Name { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public String Text { get; set; }
        /// <summary>
        /// 声音文件
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
