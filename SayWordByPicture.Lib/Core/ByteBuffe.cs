using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace SayWordByPicture.Lib.Core
{
    public class ByteBuffe : IDisposable
    {
        public ByteBuffe()
        { }

        byte[] m_ByteBuffe;

        #region SetData
        /// <summary>
        /// Stream to ByteBuffe
        /// </summary>
        /// <param name="p_Stream">Stream</param>
        public void SetData(Stream p_Stream)
        {
            m_ByteBuffe = Convent.StreamToByte(p_Stream);
        }
        /// <summary>
        /// Base64String to ByteBuffe
        /// </summary>
        /// <param name="p_Base64String">Base64String</param>
        public void SetData(String p_Base64String)
        {
            m_ByteBuffe = Convent.StringToBase64(p_Base64String);
        }
        #endregion

        /// <summary>
        /// 数组长度
        /// </summary>
        public Int32 Count { get { if (null == m_ByteBuffe)return 0; return m_ByteBuffe.Length; } }

        #region To AnyThing
        /// <summary>
        /// To String
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            return Convent.Base64ToString(m_ByteBuffe);
        }
        /// <summary>
        /// To MemoryStream
        /// </summary>
        /// <returns></returns>
        public Stream ToStream()
        {
            return new MemoryStream(m_ByteBuffe);
        }
        public Texture2D ToTexture2D(GraphicsDevice p_Device)
        {
            return Texture2D.FromStream(p_Device, ToStream());
        }
#if WINPHONE
        public SoundEffect ToSoundEffect()
        {
            return SoundEffect.FromStream(ToStream());
        }
#endif
        public byte[] ToArrary()
        {
            return m_ByteBuffe;
        }
        #endregion
        
        #region  static
        /// <summary>
        /// Create ByteBuffe From Stream
        /// </summary>
        /// <param name="p_Stream">Stream Content</param>
        /// <returns></returns>
        public static ByteBuffe FromStream(Stream p_Stream)
        {
            ByteBuffe bb = new ByteBuffe();
            bb.SetData(p_Stream);
            return bb;
        }
        /// <summary>
        /// Create ByteBuffe From Stream
        /// </summary>
        /// <param name="p_Base64String">Base64String</param>
        /// <returns></returns>
        public static ByteBuffe FromString(String p_Base64String)
        {
            ByteBuffe bb = new ByteBuffe();
            bb.SetData(p_Base64String);
            return bb;
        }
        #endregion
        public void Dispose()
        {
            m_ByteBuffe = null;
        }
    }
}
