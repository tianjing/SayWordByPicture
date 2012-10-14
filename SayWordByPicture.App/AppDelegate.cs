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
        /// ����
        /// </summary>
        /// <param name="game">��Ϸ����</param>
        /// <param name="graphics">��ͼ����</param>
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
        /// ��ʼ��
        /// </summary>
        public override bool initInstance()
        {
            return base.initInstance();
        }

        /// <summary>
        ///  ������Ϸ
        /// </summary>
        /// <returns>
        ///  true  ���سɹ�
        ///  false ����ʧ��
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
        /// ��Ϸ�����̨�ĳ�·����ͣ��Ϸ��
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
        ///��Ϸ�Ӻ�̨��Ϊǰ̨�Ĵ����ָ���Ϸ��
        /// </summary>
        public override void applicationWillEnterForeground()
        {
            CCDirector.sharedDirector().resume();
        }
    }
}
