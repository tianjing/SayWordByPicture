using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayWordByPicture.Data;
using System.Net;
using SayWordByPicture.Lib.Core;
using Microsoft.Xna.Framework.Media;
using SayWordByPicture.Lib.CusException;
using PhoneServices;
using System.IO;
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
                        if (!NetworkManage.Current.IsConnection)
                        {
                            throw new MessageException("ÎÞÍøÂç");
                        }
                        TextToSpeech.Current.GetSound(
                            Language.Chinese.GetDescription(),
                            p_Word.ChineseName,
                            (obj) =>
                            {
                                Storage.Current.CreateFile(p_Word.ChineseAudioFilePath, Lib.Core.ByteBuffe.FromStream((Stream)obj).ToArrary());
                            });
                        // TextToSpeech.TextToSpeech down = new TextToSpeech.TextToSpeech();
                        // down.GetSoud(Language.Chinese, p_Word);
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
                        if (!NetworkManage.Current.IsConnection)
                        {
                            throw new MessageException("ÎÞÍøÂç");
                        }
                        TextToSpeech.Current.GetSound(
                            Language.Enlish.GetDescription(),
                            p_Word.EnglishName,
                            (obj) =>
                            {
                                Storage.Current.CreateFile(p_Word.EnglishAudioFilePath, Lib.Core.ByteBuffe.FromStream((Stream)obj).ToArrary());
                            });
                    }
                    break;
            }
        }

    }
}
