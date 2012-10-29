using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayWordByPicture.Lib.CusException;
using Microsoft.Xna.Framework.GamerServices;

namespace SayWordByPicture.App
{
    public static class ExceptionHelper
    {
        public static void ExceptionProcess(Exception p_Exception)
        {
            MessageException message = p_Exception as MessageException;
            if (null != message)
            {
                Message(message);
            }
            else
            {
                ExMessage(p_Exception);
            }
        }
        private static void Message(MessageException p_Message)
        {
           IAsyncResult ar=  Guide.BeginShowMessageBox("��ʾ"
                                                        , p_Message.Message
                                                        , new List<String>() {"ȷ��"}
                                                        ,0
                                                        , Microsoft.Xna.Framework.GamerServices.MessageBoxIcon.Alert
                                                        ,null,new Object());
           
            Guide.EndShowMessageBox(ar);
        }
        private static void ExMessage(Exception p_Exception)
        {
            IAsyncResult ar = Guide.BeginShowMessageBox("��ʾ"
                                                         , p_Exception.Message
                                                         , new List<String>() { "ȷ��" }
                                                         , 0
                                                         , Microsoft.Xna.Framework.GamerServices.MessageBoxIcon.Alert
                                                         , null, new Object());

            Guide.EndShowMessageBox(ar);
        }

    }
}
