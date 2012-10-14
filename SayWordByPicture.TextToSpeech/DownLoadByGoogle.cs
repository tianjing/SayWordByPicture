using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayWordByPicture.Data;
using SayWordByPicture.Lib.Core;
using System.Net;
using SayWordByPicture.Lib.File;
using Microsoft.Xna.Framework.Media;

namespace SayWordByPicture.TextToSpeech
{
    public sealed class DownLoadByGoogle
    {
        public const String GoogleUrl = "http://translate.google.com.sg/translate_tts?ie=UTF-8&q={0}&tl={1}&total=1&idx=0&textlen=2&prev=input";
        public void GetGoogleSoud(Language p_Language, Word p_Word)
        {
            m_Word = p_Word;
            if (Microsoft.Phone.Net.NetworkInformation.NetworkInterface.NetworkInterfaceType == Microsoft.Phone.Net.NetworkInformation.NetworkInterfaceType.None)
            {
                return;
            }
            var client = new WebClient();
            client.Headers[HttpRequestHeader.UserAgent] = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0)" + " (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            client.Headers[HttpRequestHeader.Referer] = "http://translate.google.com"; 

            String languageCode = GetLanguageCode(p_Language);
            String text = GetText(p_Language);
            String filePath = GetFilePath(p_Language);
            Uri url = new Uri(String.Format(GoogleUrl,text,languageCode));

            client.OpenReadCompleted += ((s, args) =>
            {
                if (null != args.Result && null == args.Error)
                {
                    FileLoader.SaveFile(filePath, ByteBuffe.FromStream(args.Result));
                    Song song = Song.FromUri("music", new Uri("banana.mp3", UriKind.Relative));
                    MediaPlayer.Play(song);
                    if (p_Language == Language.Chinese)
                    {
                        m_Word.PlayChinese();
                    }
                    else { m_Word.PlayEnglish(); }
                }
            });
            client.OpenReadAsync(url);

        }
        Word m_Word;
        public event OpenReadCompletedEventHandler CompletedHandle;
        private String GetFilePath(Language p_Language)
        {
            switch (p_Language)
            {
                case Language.Chinese: return m_Word.ChineseAudioFilePath;
                case Language.Enlish:
                default: return m_Word.EnglishAudioFilePath;
            }

        }
        private String GetText(Language p_Language)
        {
            switch (p_Language)
            {
                case Language.Chinese: return m_Word.ChineseName;
                case Language.Enlish:
                default: return m_Word.EnglishName;
            }
        }
        private String GetLanguageCode(Language p_Language)
        {
            switch (p_Language)
            {
                case Language.Chinese: return "zh-cn";
                case Language.Enlish:
                default: return "en";
            }
        }
    }
}
