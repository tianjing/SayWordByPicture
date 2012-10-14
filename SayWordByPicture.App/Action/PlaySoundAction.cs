using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using Microsoft.Xna.Framework.Audio;
namespace SayWordByPicture.App.Action
{
    public class PlaySoundAction:CCAction
    {
        public PlaySoundAction(SoundEffect p_Sound)
        {
            m_Sound = p_Sound;
        }
        SoundEffect m_Sound;
        public override void stop()
        {
            base.stop();
            if (null != m_Sound)
            {
                try
                {
                    m_Sound.Play();
                    String ss = "";
                }
                catch { }
            }
        }
    }
}
