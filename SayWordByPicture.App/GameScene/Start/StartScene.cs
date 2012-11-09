using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayWordByPicture.App.Core;
using cocos2d;

namespace SayWordByPicture.App.GameScene.Start
{
    internal sealed class StartScene : BaseScene
    {
        public StartScene()
        {
            base.init();

            CCDirector.sharedDirector().deviceOrientation = ccDeviceOrientation.CCDeviceOrientationLandscapeLeft;
        }
        public override void Run()
        {
            StartLayer start = new StartLayer();
            addChild(start);
            CCDirector.sharedDirector().replaceScene(this);
        }
    }
}
