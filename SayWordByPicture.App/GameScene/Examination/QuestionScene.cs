using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayWordByPicture.App.Core;
using cocos2d;

namespace SayWordByPicture.App.GameScene.Examination
{
    internal sealed class QuestionScene : BaseScene
    {
        public QuestionScene()
        {
            base.init();
            CCDirector.sharedDirector().deviceOrientation = ccDeviceOrientation.CCDeviceOrientationLandscapeLeft;
        }
        public override void Run()
        {
            QuestionLayer start = new QuestionLayer();
            addChild(start);
            CCDirector.sharedDirector().replaceScene(this);
        }
    }
}
