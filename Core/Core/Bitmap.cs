using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
namespace SayWordByPicture.Lib.Core
{
    /// <summary>
    /// ͼ����
    /// </summary>
    public class Bitmap : IDisposable
    {
        public Texture2D Texture { get; set; }
        /// <summary>
        /// ����ͼ���ʽ��SurfaceFormat�� ����Bitmap
        /// </summary>
        /// <param name="width">���</param>
        /// <param name="height">�߶�</param>
        /// <param name="format">ͼ���ʽ</param>
        /// <returns></returns>
        public static Bitmap CreateBitmap(GraphicsDevice p_GraphicsDevice, int p_Width, int p_Height, SurfaceFormat format)
        {
            return new Bitmap
            {
                Texture = new Texture2D(p_GraphicsDevice, p_Width, p_Height, false, format)
            };
        }
        /// <summary>
        /// �����ֽ����鴴��ͼ��
        /// </summary>
        /// <param name="p_Datas">ͼƬ�ֽ�����</param>
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
        /// �����ڴ�������ͼ��
        /// </summary>
        /// <param name="p_MemoryStream">�ڴ���</param>
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
        /// ͼ����
        /// </summary>
        public int Width
        {
            get { return (this.Texture != null) ? this.Texture.Width : 0; }
        }
        /// <summary>
        /// ͼ��߶�
        /// </summary>
        public int Height
        {
            get { return (this.Texture != null) ? this.Texture.Height : 0; }
        }

        /// <summary>
        /// ���ͼ���ڴ���
        /// </summary>
        /// <returns></returns>
        public MemoryStream ToMemoryStream()
        {
            return new MemoryStream(ToBytes());
        }
        /// <summary>
        /// ���ͼ���ֽ�����
        /// </summary>
        /// <returns></returns>
        public byte[] ToBytes()
        {
            byte[] array = new byte[this.Texture.Width * this.Texture.Height * 4];
            this.Texture.GetData<byte>(array);
            return array;
        }
        /// <summary>
        /// �ͷ�
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
