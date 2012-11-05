using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using SayWordByPicture.Data;
using SayWordByPicture.App.Core;
using SayWordByPicture.App.Core.Interface;
using SayWordByPicture.App.GameScene.Examination;

namespace SayWordByPicture.App.People
{
    public class Speaker : CCSprite,ITouchProcess
    {
        public Speaker()
        {
            base.init();
            LoadPicture();
        }
        public const String PictuerName = "image/Speak";
        public const Int32 PictuerWidth = 66;
        public const Int32 PictuerHeight = 49;
        public const Int32 FrameNumber = 19;
        internal QuestionAction SayAction { get; set; }
        CCAnimate action;


        private void LoadPicture()
        {
            CCTexture2D speakerpic = Media.PictureManager.GetCCTexture2DWithFile(PictuerName);
            List<CCSpriteFrame> frames = new List<CCSpriteFrame>();
            
            for (int i = 0; i < FrameNumber; i++)
            {
                CCSpriteFrame frame = CCSpriteFrame.frameWithTexture(speakerpic, new CCRect(i * PictuerWidth, 0, PictuerWidth, PictuerHeight));
                frames.Add(frame);
            }
            CCAnimation ani = CCAnimation.animationWithFrames(frames);
            this.initWithSpriteFrame(frames[0]);
            action = CCAnimate.actionWithDuration(1f, ani, true);
        }

        public void OnClick(CCLayer p_Layer)
        {
            p_Layer.isTouchEnabled = false;
            runAction(SayAction);
            runAction(action);

           ActionHelper.AsyncActionCallBack(
               action, ((sender, e) => 
               {
                   p_Layer.isTouchEnabled = true;
                   
               }));
        }

    }
}
