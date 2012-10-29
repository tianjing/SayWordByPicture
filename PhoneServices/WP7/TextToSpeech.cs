using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using PhoneServices.Interface;

namespace PhoneServices
{
    public sealed class TextToSpeech : ITextToSpeech
    {
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
        public const String BingApi = "http://api.microsofttranslator.com/v2/http.svc/Speak?language={0}&format=audio/wav&options=MaxQuality&appid=TSyTKY8vU68RXWFdk52yLMEtpwYnlod_50mgJB9OlYbA*&text={1}";
        private const String AppId = "5B75316E24BE0E1E19DE874CE806DD064AFAC5EA";//form http://www.cnblogs.com/chenkai/archive/2011/11/06/2237865.html
        private TextToSpeech()
        {
        }

        public void GetSound(string p_Language, string p_Text, Action<object> p_CallBack)
        {
            String url = String.Format(BingApi, p_Language, p_Text);
            DownLoad(url, p_CallBack);
        }

        private void DownLoad(String p_Url, Action<object> p_CallBack)
        {
            WebClient client = new WebClient();
            client.OpenReadCompleted += ((s, args) =>
            {
                if (null != args.Error || null == args.Result)
                {
                    throw new Exception("ÍøÂç´íÎó£¬Çë¼ì²éÊÇ·ñÁªÍø");
                }
                p_CallBack.Invoke(args.Result);

            });
            client.OpenReadAsync(new Uri(p_Url));
        }
    }
}
