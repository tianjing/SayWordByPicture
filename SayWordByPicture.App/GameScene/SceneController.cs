using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using SayWordByPicture.Lib.Core;
using Microsoft.Xna.Framework;
using cocos2d;
using System.Windows;
using SayWordByPicture.App.GameScene.Examination;
using SayWordByPicture.App.GameScene.Start;
using SayWordByPicture.App.Core;
using SayWordByPicture.App.GameScene.Setting;
using SayWordByPicture.App.GameScene.WordManage;
using SayWordByPicture.App.GameScene.AddWord;
namespace SayWordByPicture.App.GameScene
{
    internal sealed class SceneController : CCScene
    {
        /// <summary>
        ///  ππ‘Ï
        /// </summary>
        public SceneController()
        {
            CCDirector.sharedDirector().deviceOrientation = ccDeviceOrientation.CCDeviceOrientationLandscapeLeft;
            base.init();
        }
        public static void RunMain()
        {
            StartScene scene = new StartScene();
            StartLayer layer = new StartLayer();
            scene.addChild(layer);
            CCDirector.sharedDirector().runWithScene(scene);
        }
        public static void RunScene(EnumScene p_Scene)
        {
            BaseScene scene = CreateScene(p_Scene);
            if (null != scene)
            {
                scene.Run();
            }
        }
        private static BaseScene CreateScene(EnumScene p_Scene)
        {
            switch (p_Scene)
            {
                case EnumScene.Start: return new StartScene();
                case EnumScene.Question: return new QuestionScene();
                case EnumScene.Setting: return new SettingScene();
                case EnumScene.WordList: return new WordListScene();
                case EnumScene.AddWord: return new AddWordScene();
                default: return null;
            }
        }
        public static void ExitGame()
        {
            CCDirector.sharedDirector().end();
            CCApplication.sharedApplication().Game.Exit();
        }
    }
}