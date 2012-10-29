using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SayWordByPicture.Lib.CusException;
using Microsoft.Xna.Framework.Graphics;
using cocos2d;
namespace SayWordByPicture.Lib.Display
{
    /// <summary>
    /// 屏幕帮助类
    /// </summary>
    public class ScreenHelper
    {
        /// <summary>
        /// 获取均分屏幕的尺寸 默认屏幕宽800 高480
        /// </summary>
        /// <param name="p_Width">800</param>
        /// <param name="p_Height">480</param>
        /// <param name="p_AverageNumber">均分</param>
        /// <returns></returns>
        public static CCSize MathSize(Int32 p_Width, Int32 p_Height, Int32 p_AverageNumber,Int32 p_While)
        {
            CCSize size = new CCSize();
            size.width = p_Width / ((p_AverageNumber / 2)==1?2:(p_AverageNumber / 2));

            if (p_AverageNumber / 2 > 1)
            {
                size.height = p_Height / 2;
            }
            else
            {
                size.height = p_Height;
            }
            size.width -= p_While*2;
            size.height -= p_While * 2;
            return size;
        }
        /// <summary>
        /// 获取均分屏幕的矩形 默认屏幕宽800 高480
        /// </summary>
        /// <param name="p_Width">800</param>
        /// <param name="p_Height">480</param>
        /// <param name="p_AverageNumber">均分</param>
        /// <returns></returns>
        public static List<Rectangle> GetAverageRectangle(Int32 p_Width, Int32 p_Height, Int32 p_AverageNumber)
        {
            List<Rectangle> list = new List<Rectangle>();
            if (p_Width < 1 || p_Height < 1)
            {
                throw new MessageException(String.Format("屏幕参数太小，请检查 宽：{0},高：{1}", p_Width, p_Height));
            }

            if (1 > p_AverageNumber || p_AverageNumber > 9)
            {
                throw new MessageException(String.Format("均分数只支持到2,4,6,8"));
            }

            if ((p_AverageNumber % 2) != 0)
            {
                throw new MessageException(String.Format("均分数不能为单数"));
            }

            Int32 width = p_Width / (p_AverageNumber / 2);

            Int32 height = 0;
            if (p_AverageNumber / 2 > 1)
            {
                height = p_Height / 2;
            }
            else
            {
                height = p_Height;
            }

            Int32 x=0, y=0;
            for (var i = 1; i <= p_AverageNumber; i++)
            {
                x=(i-1)*width;
                if (i == (p_AverageNumber / 2))
                {
                    x = 0;
                    y = height;
                }
                
                list.Add(new Rectangle(x,y,width,height));
            }
            return list;
        }

    }
}
