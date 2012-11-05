using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using PhoneServices.Interface;
using System.IO;
using System.Threading;

namespace PhoneServices
{
    public sealed class TextToSpeech : ITextToSpeech
    {
        private TextToSpeech()
        {
        }
        static ITextToSpeech m_Current;
        public static ITextToSpeech Current
        {
            get
            {
                if (null == m_Current)
                {
                    m_Current = new TextToSpeech();
                }
                return m_Current;
            }
        }
        private static String T2SAppId;
        public const String BingApi = "http://api.microsofttranslator.com/v2/http.svc/Speak?language={0}&format=audio/wav&options=MaxQuality&appid={1}&text={2}";
        private const String AppId = "5B75316E24BE0E1E19DE874CE806DD064AFAC5EA";//form http://www.cnblogs.com/chenkai/archive/2011/11/06/2237865.html
        private const String AppIdUrl = "http://www.bing.com/translator/";

        public void GetSound(string p_Language, string p_Text, Action<Stream> p_CallBack)
        {
            String url = String.Format(BingApi, p_Language, T2SAppId, p_Text);
            if (String.IsNullOrEmpty(T2SAppId))
            {
                GetAppidAndDownLoad(p_Language, p_Text, p_CallBack);
            }
            else
            {
                DownLoad(p_Language, p_Text, p_CallBack);
            }
        }
        private static void GetAppidAndDownLoad(string p_Language, string p_Text, Action<Stream> p_CallBack)
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (sender, args) =>
            {
                String result = args.Result;
                Int32 startindex = result.IndexOf("T2S.Init('");
                if (startindex > 0)
                {
                    Int32 endindex = result.IndexOf("',true,450,'http://api.microsofttranslator.com/v2/http.svc'");
                    T2SAppId = result.Substring(startindex + 10, endindex - startindex-10);
                    if (!String.IsNullOrEmpty(T2SAppId))
                    {
                        DownLoad(p_Language, p_Text, p_CallBack);
                    }
                }
            };
            wc.DownloadStringAsync(new Uri(AppIdUrl));
        }

        private static void DownLoad(string p_Language, string p_Text, Action<Stream> p_CallBack)
        {
            String url = String.Format(BingApi, p_Language, T2SAppId, p_Text);
            WebClient client = new WebClient();
            client.OpenReadCompleted += (sender, args) =>
            {
                if (null == args.Error && args.Result.Length > 0)
                {
                    p_CallBack.Invoke(args.Result);
                }
                else
                {
                    p_CallBack.Invoke(null);
                }
            };
            client.OpenReadAsync(new Uri(url));
        }

    }

}
