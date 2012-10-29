using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using SayWordByPicture.Lib.Core;
using cocos2d;
using SayWordByPicture.Data;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.IO;
using SayWordByPicture.Media;
using SayWordByPicture.Lib.Display;
using SayWordByPicture.App.Core.Interface;
using SayWordByPicture.App.People;
namespace SayWordByPicture.App.GameScene.Examination
{
    /// <summary>
    /// 选项
    /// </summary>
    internal sealed class Selection : CCSprite, ITouchProcess
    {
        public Selection(Word p_StudyInfo, bool p_IsAnswer, Int32 p_Width, Int32 p_Height)
        {
            base.init();
            this.StudyInfo = p_StudyInfo;

            CCTexture2D texture = new CCTexture2D();
            Texture2D sa = PictureManager.GetTexture2D(p_StudyInfo);

            texture.initWithTexture(sa);
            texture.PixelsWide = p_Width;
            texture.PixelsHigh = p_Height;

            CCRect rect = new CCRect();
            rect.size = new CCSize(p_Width, p_Height);
            this.initWithTexture(texture, rect);

            this.IsAnswer = p_IsAnswer;
            LoadResultPeople();
        }
        private void LoadResultPeople()
        {
            CCSize size = CCDirector.sharedDirector().getWinSize();
            ResultPeople = new ResultPeople(IsAnswer);
            ResultPeople.position = new CCPoint(size.width / 2, size.height / 2);
        }
        ResultPeople ResultPeople { get; set; }
        public override void onEnter()
        {
            base.onEnter();
        }
        /// <summary>
        /// 是否是答案
        /// </summary>
        public bool IsAnswer { get; private set; }
        /// <summary>
        /// 学习信息
        /// </summary>
        public Word StudyInfo { get; set; }

        public void OnClick(CCLayer p_Layer)
        {
            try
            {
                p_Layer.isTouchEnabled = false;
                p_Layer.addChild(ResultPeople);
                ResultPeople.Play((obj) =>
                {
                    p_Layer.removeChild(ResultPeople, true);
                    if (IsAnswer)
                    {
                        SceneController.RunScene(EnumScene.Question);
                    }
                    else
                    {
                        p_Layer.isTouchEnabled = true;
                    }
                });
            }
            catch (Exception e)
            {
                ExceptionHelper.ExceptionProcess(e);
            }
        }

    }
}
