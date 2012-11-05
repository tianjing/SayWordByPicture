using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using Microsoft.Xna.Framework;
using SayWordByPicture.App.GameScene;
using SayWordByPicture.Lib.Core;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using SayWordByPicture.App.GameScene.Start;

namespace SayWordByPicture.App
{
    public class AppDelegate : CCApplication
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="game">游戏对象</param>
        /// <param name="graphics">画图对象</param>
        public AppDelegate(Game game, GraphicsDeviceManager graphics)
            : base(game, graphics)
        {
            CCApplication.sm_pSharedApplication = this;
        }
        protected override void LoadContent()
        {
            base.LoadContent();
            CCDirector.sharedDirector().DisplayFPS = false;
            Data.DataManager.LoadData();
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public override bool initInstance()
        {
            return base.initInstance();
        }

        /// <summary>
        ///  加载游戏
        /// </summary>
        /// <returns>
        ///  true  加载成功
        ///  false 加载失败
        /// </returns>
        public override bool applicationDidFinishLaunching()
        {
            //initialize director
            CCDirector pDirector = CCDirector.sharedDirector();
            pDirector.setOpenGLView();
            pDirector.DisplayFPS = true;
            pDirector.animationInterval = 1.0 / 30;

            SceneController.RunMain();

            return true;
        }

        /// <summary>
        /// 游戏进入后台的出路（暂停游戏）
        /// </summary>
        public override void applicationDidEnterBackground()
        {
            CCDirector.sharedDirector().pause();
        }
        public override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
            {
                if (CCDirector.sharedDirector().runningScene is StartScene)
                {
                    this.Game.Exit();
                    return;
                }
                SceneController.RunScene(EnumScene.Start);
            }

            base.Update(gameTime);
        }
        /// <summary>
        ///游戏从后台变为前台的处理（恢复游戏）
        /// </summary>
        public override void applicationWillEnterForeground()
        {
            CCDirector.sharedDirector().resume();
        }
    }
}
