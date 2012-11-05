using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SayWordByPicture.Lib.Core
{
    public static class RandomHelper
    {
        static Random m_Random = new Random(DateTime.Now.Millisecond);
        /// <summary>
        /// 获取指定范围的随机数
        /// </summary>
        /// <param name="p_Min">最小数</param>
        /// <param name="p_Max">最大数</param>
        /// <returns></returns>
        public static Int32 GetRandomNumber(Int32 p_Min,Int32 p_Max)
        {
           return  m_Random.Next(p_Min,p_Max);
        }
    }
}
