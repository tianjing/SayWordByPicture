using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayWordByPicture.Data;
using System.Net;
using SayWordByPicture.Lib.File;
using SayWordByPicture.Lib.Core;
using SayWordByPicture.TextToSpeech;
using Microsoft.Xna.Framework.Media;
using SayWordByPicture.Lib.CusException;

namespace SayWordByPicture.Media
{
    public static class AudioManager
    {
        public static void Play(Language p_Language, Word p_Word)
        {
            switch (p_Language)
            {
                case Language.Chinese:
                    if (p_Word.HasChineseAudio)
                    {
                        p_Word.PlayChinese();
                    }
                    else
                    {
                        if (!Lib.Network.NetworkManage.IsConnection)
                        {
                            throw new MessageException("无网络");
                        }
                        TextToSpeech.TextToSpeech down = new TextToSpeech.TextToSpeech();
                        down.GetSoud(Language.Chinese, p_Word);
                    }
                    break;
                case Language.Enlish:
                default:
                    if (p_Word.HasEnglishAudio)
                    {
                        p_Word.PlayEnglish();
                    }
                    else
                    {
                        if (!Lib.Network.NetworkManage.IsConnection)
                        {
                            throw new MessageException("无网络");
                        }
                        TextToSpeech.TextToSpeech down = new TextToSpeech.TextToSpeech();
                        down.GetSoud(Language.Enlish, p_Word);
                    }
                    break;
            }
        }

    }
}
