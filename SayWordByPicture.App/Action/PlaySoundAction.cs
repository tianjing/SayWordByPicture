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
        public PlaySoundAction(String p_SoundPath)
        {
            m_SoundPath = p_SoundPath;
        }
        String m_SoundPath;
        public override void stop()
        {
            base.stop();
            if (!String.IsNullOrEmpty( m_SoundPath))
            {
                try
                {
                    Media.AudioManager.Play(m_SoundPath);
                }
                catch { }
            }
        }
    }
}
