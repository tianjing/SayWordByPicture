using System;
using System.IO;
using System.Net;

namespace SayWordByPicture.Lib.Http
{
    public class HttpCliet
    {
        public static String OpenUrl(String p_Url)
        {
            WebRequest client = WebRequest.Create(p_Url);
            IAsyncResult ar= client.BeginGetResponse(null, null);
            WebResponse result= client.EndGetResponse(ar);
            using (StreamReader sr =new StreamReader( result.GetResponseStream()))
            {
               return sr.ReadToEnd();
            }
        }
        public static Stream DownLoad(String p_Url)
        {
            WebRequest client = WebRequest.Create(p_Url);
            IAsyncResult ar = client.BeginGetResponse(null, null);
            WebResponse result = client.EndGetResponse(ar);
            return result.GetResponseStream();
        }
    }
}
