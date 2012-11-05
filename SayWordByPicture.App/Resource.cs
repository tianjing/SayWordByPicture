using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayWordByPicture.Lib.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace SayWordByPicture.App
{
    public static class Resource
    {
        /// <summary>
        /// 背景图片
        /// </summary>
        public static Bitmap BackGround { get; set; }
        /// <summary>
        /// 字体
        /// </summary>
        public static SpriteFont Font { get; set; }
    }
}
