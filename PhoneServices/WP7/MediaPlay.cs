using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PhoneServices.Interface;
using Microsoft.Xna.Framework.Audio;
using System.IO;
namespace PhoneServices
{
    public sealed class MediaPlay:IMediaPlay
    {
        private MediaPlay()
        { }
        static IMediaPlay m_Current;
        public static IMediaPlay Current
        {
            get
            {
                if (null == m_Current)
                {
                    m_Current = new MediaPlay();
                }
                return m_Current;
            }
        }

        public void Play(String p_FilePath)
        {
            PlayWav(GetFile(p_FilePath));
        }
        /// <summary>
        /// get stream by filepath
        /// </summary>
        /// <param name="p_FilePath">file full path</param>
        /// <returns></returns>
        private Stream GetFile(String p_FilePath)
        {
            if (p_FilePath.StartsWith("Content/"))
            {
                return Microsoft.Xna.Framework.TitleContainer.OpenStream(p_FilePath);
            }
            else
            {
               return System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication().OpenFile(p_FilePath,FileMode.Open);
            }
        }
        /// <summary>
        /// play wav Stream
        /// </summary>
        /// <param name="p_Wav">wav stream</param>
        private void PlayWav(Stream p_Wav)
        {
            SoundEffect sound = SoundEffect.FromStream(p_Wav);
            sound.Play();
        }
    }
}
