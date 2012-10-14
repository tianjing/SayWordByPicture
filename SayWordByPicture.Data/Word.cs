using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayWordByPicture.Lib.File;
using Microsoft.Xna.Framework.Media;
using System.Windows.Controls;
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
        /// 主键
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 中文名称
        /// </summary>
        public String ChineseName { get; set; }
        /// <summary>
        /// 英文名称
        /// </summary>
        public String EnglishName { get; set; }
        /// <summary>
        /// 图片文件名称
        /// </summary>
        public String PictureFile { get; set; }
        /// <summary>
        /// 图片文件路径
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
        /// 单词类型 如1：水果，2蔬菜
        /// </summary>
        public Int32 WordType { get; set; }
        /// <summary>
        /// 是否是内置数据
        /// </summary>
        public bool IsContent { get; set; }
        /// <summary>
        /// 英语音频文件
        /// </summary>
        public String EnglishAudioFilePath { get { return AudioPath + EnglishName + ".wav"; } }
        /// <summary>
        /// 中文音频文件
        /// </summary>
        public String ChineseAudioFilePath { get { return AudioPath + ChineseName + ".wav"; } }
        /// <summary>
        /// 英语音频 是否存在
        /// </summary>
        public bool HasEnglishAudio
        {
            get
            { return FileLoader.IsolatedStorageFileExists(EnglishAudioFilePath); }
        }
        /// <summary>
        /// 中文音频 是否存在
        /// </summary>
        public bool HasChineseAudio { get { return FileLoader.IsolatedStorageFileExists(ChineseAudioFilePath); } }
        /// <summary>
        /// 播放中文
        /// </summary>
        public void PlayChinese()
       {
           if (HasChineseAudio) {
               SoundEffect sound = SoundEffect.FromStream(FileLoader.ReadFile(false, ChineseAudioFilePath));
               SoundEffectInstance player = sound.CreateInstance();
               player.Volume = 1;
               player.Play();
           }
       }
        /// <summary>
        /// 播放英文
        /// </summary>
        public void PlayEnglish()
        {
            if (HasEnglishAudio)
            {
                SoundEffect sound = SoundEffect.FromStream(FileLoader.ReadFile(false,EnglishAudioFilePath));
                SoundEffectInstance player = sound.CreateInstance();
                player.Volume = 1;
                player.Play();
            }
        }
    }
}
