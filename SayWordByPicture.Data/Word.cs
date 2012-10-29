using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace SayWordByPicture.Data
{
    public class Word
    {
        public Word()
        {
        }
        public const String ContentPath = "Content/Study/";
        public const String PicturePath = "Shared/Images/";
        public const String AudioPath = "Shared/Audio/";
        /// <summary>
        /// ����
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public String ChineseName { get; set; }
        /// <summary>
        /// Ӣ������
        /// </summary>
        public String EnglishName { get; set; }
        /// <summary>
        /// ͼƬ�ļ�����
        /// </summary>
        public String PictureFile { get; set; }
        /// <summary>
        /// ͼƬ�ļ�·��
        /// </summary>
        public String PictureFilePath
        {
            get
            {
                if (IsContent)
                {
                    return ContentPath + PictureFile;
                }
                return PicturePath + PictureFile;
            }
        }
        /// <summary>
        /// �������� ��1��ˮ����2�߲�
        /// </summary>
        public Int32 WordType { get; set; }
        /// <summary>
        /// �Ƿ�����������
        /// </summary>
        public bool IsContent { get; set; }
        /// <summary>
        /// Ӣ����Ƶ�ļ�
        /// </summary>
        public String EnglishAudioFilePath { get { return AudioPath + EnglishName + ".wav"; } }
        /// <summary>
        /// ������Ƶ�ļ�
        /// </summary>
        public String ChineseAudioFilePath { get { return AudioPath + ChineseName + ".wav"; } }
        /// <summary>
        /// Ӣ����Ƶ �Ƿ����
        /// </summary>
        public bool HasEnglishAudio
        {
            get
            { return PhoneServices.Storage.Current.FileExists(EnglishAudioFilePath); }
        }
        /// <summary>
        /// ������Ƶ �Ƿ����
        /// </summary>
        public bool HasChineseAudio { get { return PhoneServices.Storage.Current.FileExists(ChineseAudioFilePath); } }
        /// <summary>
        /// ��������
        /// </summary>
        public void PlayChinese()
       {
           if (HasChineseAudio) {
#if WINPHONE
               SoundEffect sound = SoundEffect.FromStream(FileLoader.ReadFile(false, ChineseAudioFilePath));
               SoundEffectInstance player = sound.CreateInstance();
               player.Volume = 1;
               player.Play();
#endif
               //TODO android
               }
       }
        /// <summary>
        /// ����Ӣ��
        /// </summary>
        public void PlayEnglish()
        {
            if (HasEnglishAudio)
            {
#if WINPHONE
                SoundEffect sound = SoundEffect.FromStream(FileLoader.ReadFile(false,EnglishAudioFilePath));
                SoundEffectInstance player = sound.CreateInstance();
                player.Volume = 1;
                player.Play();
#endif
                //TODO android
            }

        }
    }
}
