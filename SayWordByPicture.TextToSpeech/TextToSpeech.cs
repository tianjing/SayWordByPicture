using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using SayWordByPicture.TextToSpeech.SpeechServer;
using System.Collections.ObjectModel;
using System.Windows.Threading;
using System.Linq.Expressions;
using System.Net;
using System.IO;
using SayWordByPicture.Lib.Core;
using SayWordByPicture.Data;
using SayWordByPicture.Lib.File;
using System.Diagnostics;
namespace SayWordByPicture.TextToSpeech
{

    public class TextToSpeech
    {
        public TextToSpeech()
        {
            LanguageCode = "en";
            objTranslator = new LanguageServiceClient();
            objTranslator.SpeakCompleted += translator_SpeakCompleted;
        }


        private const String AppId = "5B75316E24BE0E1E19DE874CE806DD064AFAC5EA";//form http://www.cnblogs.com/chenkai/archive/2011/11/06/2237865.html
        public String LanguageCode { get; set; }

         LanguageServiceClient objTranslator;

        public void GetSoud(Language p_Language, Word p_Word)
        {
            try
            {
                m_Language = p_Language;
                m_Word = p_Word;
                SetLanguage();
                String text = GetText();
                objTranslator.SpeakAsync(AppId, text,
                             LanguageCode, "audio/wav", "MinSize");
            }
            catch { }
        }
        Language m_Language;
        private Word m_Word;
        private void SetLanguage()
        {
            switch (m_Language)
            {
                case Language.Chinese: LanguageCode = "zh-cn"; break;
                case Language.Enlish:
                default: LanguageCode = "en"; break;
            }
        }
        private String GetFilePath()
        {
            switch (m_Language)
            {
                case Language.Chinese: return m_Word.ChineseAudioFilePath;
                case Language.Enlish:
                default: return m_Word.EnglishAudioFilePath;
            }

        }
        private String GetText()
        {
            switch (m_Language)
            {
                case Language.Chinese: return m_Word.ChineseName;
                case Language.Enlish:
                default: return m_Word.EnglishName;
            }
        }
        void translator_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            var client = new WebClient();
            client.OpenReadCompleted += ((s, args) =>
            {
                String filePath = GetFilePath();
                FileLoader.SaveFile(filePath, ByteBuffe.FromStream(args.Result));
                if (m_Language == Language.Chinese)
                {
                    m_Word.PlayChinese();
                }
                else { m_Word.PlayEnglish(); }
            });
            client.OpenReadAsync(new Uri(e.Result));
        }
    }

}

