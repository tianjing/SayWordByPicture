using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SayWordByPicture.Lib.CusException
{
    /// <summary>
    /// ��Ϣ�쳣
    /// </summary>
    public class MessageException:Exception 
    {
        public MessageException(String p_Message)
            : base(p_Message)
        { }
        public MessageException(String p_Message,Exception e)
            : base(p_Message,e)
        { }
    }
}
