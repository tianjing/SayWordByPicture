using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
namespace SayWordByPicture.Lib.Core
{
    /// <summary>
    /// 图像类
    /// </summary>
    public class Bitmap : IDisposable
    {
        public Texture2D Texture { get; set; }
        /// <summary>
        /// 根据图像格式（SurfaceFormat） 创建Bitmap
        /// </summary>
        /// <param name="width">宽度</param>
        /// <param name="height">高度</param>
        /// <param name="format">图像格式</param>
        /// <returns></returns>
        public static Bitmap CreateBitmap(GraphicsDevice p_GraphicsDevice, int p_Width, int p_Height, SurfaceFormat format)
        {
            return new Bitmap
            {
                Texture = new Texture2D(p_GraphicsDevice, p_Width, p_Height, false, format)
            };
        }
        /// <summary>
        /// 根据字节数组创建图像
        /// </summary>
        /// <param name="p_Datas">图片字节数组</param>
        /// <returns></returns>
        public static Bitmap CreateBitmap(GraphicsDevice p_GraphicsDevice, byte[] p_Datas)
        {
            Bitmap bitmap = new Bitmap();
            try
            {
                MemoryStream stream = new MemoryStream(p_Datas);
                bitmap.Texture = Texture2D.FromStream(p_GraphicsDevice, stream);
            }
            catch (Exception)
            {
            }
            return bitmap;
        }
        /// <summary>
        /// 根据内存流创建图像
        /// </summary>
        /// <param name="p_MemoryStream">内存流</param>
        /// <returns></returns>
        public static Bitmap CreateBitmap(GraphicsDevice p_GraphicsDevice, Stream p_Stream)
        {
            Bitmap bitmap = new Bitmap();
            try
            {
                bitmap.Texture = Texture2D.FromStream(p_GraphicsDevice, p_Stream);
            }
            catch (Exception)
            {
            }
            return bitmap;
        }
        /// <summary>
        /// 图像宽度
        /// </summary>
        public int Width
        {
            get { return (this.Texture != null) ? this.Texture.Width : 0; }
        }
        /// <summary>
        /// 图像高度
        /// </summary>
        public int Height
        {
            get { return (this.Texture != null) ? this.Texture.Height : 0; }
        }

        /// <summary>
        /// 输出图像到内存流
        /// </summary>
        /// <returns></returns>
        public MemoryStream ToMemoryStream()
        {
            return new MemoryStream(ToBytes());
        }
        /// <summary>
        /// 输出图像到字节数组
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            byte[] array = new byte[this.Texture.Width * this.Texture.Height * 4];
            this.Texture.GetData<byte>(array);
            return array;
        }
        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            if (this.Texture != null)
            {
                this.Texture.Dispose();
            }
            this.Texture = null;
        }
    }
}
