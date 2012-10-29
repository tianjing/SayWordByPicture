using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SayWordByPicture.Lib.Core;

namespace SayWordByPicture.App.GameScene.Setting
{
    internal sealed class SettingLayer : CCLayer
    {
        public SettingLayer()
        {
            base.init();
            isTouchEnabled = true;
        }
        public override void onEnter()
        {
            base.onEnter();

            LoadMenu();
        }

        private void LoadMenu()
        {
            CreateQuestionNumItem();
        }

        private void CreateQuestionNumItem()
        {
            float y = 400;

            SettingMenuHelper.AddTitleMenu(this, "发音", ref y);
            SettingMenuHelper.AddSetMenu(this, GetLanguageString(), "image/Left", "image/Right", SettingLanguageCallback, SettingLanguageCallback, ref y);

            SettingMenuHelper.AddTitleMenu(this, "答案选项数", ref y);
            SettingMenuHelper.AddSetMenu(this, Platform.QuestionNum.ToString(), "image/Left", "image/Right", ReduceQuestionNumCallback, AddQuestionNumCallback, ref y);

        }
        private String GetLanguageString()
        {
            String result = String.Empty;
            switch (Platform.QuestionLanguage)
            {
                case Lib.Core.Language.Chinese: result = "中文"; break;
                case Lib.Core.Language.Enlish:
                default: result = "英文"; break;
            }
            return result;
        }
        private void CreateQuestionLanguage(CCMenu p_Menu)
        {
            CCLabelTTF label = CCLabelTTF.labelWithString("发音", "ChineseTitle", 28);
            label.Color = new ccColor3B(Color.White);
            CCMenuItemLabel tab = CCMenuItemLabel.itemWithLabel(label);
        }
        private CCMenuItem CreateItem()
        {

            return null;
        }
        public void SettingLanguageCallback(CCObject pSender)
        {
            try
            {
                switch (Platform.QuestionLanguage)
                {
                    case Language.Enlish: Platform.QuestionLanguage = Language.Chinese; break;
                    case Language.Chinese:
                    default: Platform.QuestionLanguage = Language.Enlish; break;
                }
                SceneController.RunScene(EnumScene.Setting);
            }
            catch (Exception e)
            {
                ExceptionHelper.ExceptionProcess(e);
            }
        }

        public void AddQuestionNumCallback(CCObject pSender)
        {
            try
            {
                Platform.QuestionNum += 2;
                SceneController.RunScene(EnumScene.Setting);
            }
            catch (Exception e)
            {
                ExceptionHelper.ExceptionProcess(e);
            }
        }
        public void ReduceQuestionNumCallback(CCObject pSender)
        {
            try
            {
                Platform.QuestionNum -= 2;
                SceneController.RunScene(EnumScene.Setting);
            }
            catch (Exception e)
            {
                ExceptionHelper.ExceptionProcess(e);
            }
        }

    }
}
