using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using SayWordByPicture.App.Core;
using Microsoft.Xna.Framework;
namespace SayWordByPicture.App.GameScene.WordManage
{
    internal sealed class WordListScene:BaseScene
    {
        public WordListScene()
        {
            base.init();
           CCDirector.sharedDirector().deviceOrientation= ccDeviceOrientation.CCDeviceOrientationPortrait;
        }

        public override void draw()
        {
            base.draw();
            CCApplication.sharedApplication().GraphicsDevice.Clear(Color.White);
        }
        public override void Run()
        {
            WordListLayer start = new WordListLayer();
            addChild(start);
            CCDirector.sharedDirector().replaceScene(this);
        }
        public void Run(CCPoint p_Point)
        {
            WordListLayer start = new WordListLayer();
            start.position = p_Point;
            addChild(start);
            CCDirector.sharedDirector().replaceScene(this);
        }
    }
}
