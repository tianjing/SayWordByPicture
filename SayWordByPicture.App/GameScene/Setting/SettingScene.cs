using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayWordByPicture.App.Core;
using cocos2d;
namespace SayWordByPicture.App.GameScene.Setting
{
    internal sealed class SettingScene : BaseScene
    {
       public SettingScene()
       {
           base.init();
       }
        public override void Run()
        {
            SettingLayer layer = new SettingLayer();
            addChild(layer);
            CCDirector.sharedDirector().replaceScene(this);
        }
    }
}
