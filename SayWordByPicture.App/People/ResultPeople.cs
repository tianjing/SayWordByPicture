using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using SayWordByPicture.App.Action;
using SayWordByPicture.App.Core;
using SayWordByPicture.App.Core.Interface;
namespace SayWordByPicture.App.People
{
    public class ResultPeople : CCSprite
    {
        public const String TruePicturePath = "Effect/True";
        public const String FailPicturePath = "Effect/Fail";
        public const String TrueSoundPath = "Content/Effect/True.wav";
        public const String FailSoundPath = "Content/Effect/Fail.wav";
        public const Int32 PicWidth = 80;
        public const Int32 PicHeight = 80;
        public const Int32 FrameNumber = 19;

        public bool IsTruePeople { get; set; }


        private CCRepeat action;
        String m_SoundPath { get; set; }
        CCTexture2D Picture { get; set; }
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="p_IsTure"></param>
        public ResultPeople(bool p_IsTure)
        {
            base.init();
            IsTruePeople = p_IsTure;
            LoadPicture();
            LoadSound();
        }


        /// <summary>
        /// 加载图片
        /// </summary>
        private void LoadPicture()
        {
            String picpath = String.Empty;
            if (IsTruePeople)
            {
                picpath = TruePicturePath;
            }
            else
            {
                picpath = FailPicturePath;
            }
            Picture = Media.PictureManager.GetCCTexture2DWithFile(picpath);
            List<CCSpriteFrame> frames = new List<CCSpriteFrame>();

            for (int i = 0; i < FrameNumber; i++)
            {
                CCSpriteFrame frame = CCSpriteFrame.frameWithTexture(Picture, new CCRect(i * PicWidth, 0, PicWidth, PicHeight));
                frames.Add(frame);
            }
            CCAnimation ani = CCAnimation.animationWithFrames(frames);
            this.initWithSpriteFrame(frames[0]);
            CCAnimate anima = CCAnimate.actionWithDuration(1f, ani, true);
            action = CCRepeat.actionWithAction(anima.reverse(), 3);
        }
        /// <summary>
        /// 加载音频
        /// </summary>
        private void LoadSound()
        {
            String soundpath = String.Empty;
            if (IsTruePeople)
            {
                soundpath = TrueSoundPath;
            }
            else
            {
                soundpath = FailSoundPath;
            }
            m_SoundPath = soundpath;
        }

        public void Play(Action<Object> p_action)
        {

            runAction(new PlaySoundAction(m_SoundPath));
            runAction(action);
            
            ActionHelper.AsyncActionCallBack(action, (sender, e) => 
            {
                if (null != p_action)
                {
                    p_action.Invoke(this);
                }
            });
        }

    }
}
