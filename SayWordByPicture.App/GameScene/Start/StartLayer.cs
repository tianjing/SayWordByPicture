using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
namespace SayWordByPicture.App.GameScene.Start
{
    internal sealed class StartLayer : CCLayer
    {
        #region Init

        public override void onEnter()
        {
            base.onEnter();
            this.isTouchEnabled = true;
            // ask director the window size
            CCSize size = CCDirector.sharedDirector().getWinSize();
            BackGroundInit(size);
            MenuInit();
        }

        /// <summary>
        /// �˵���ʼ��
        /// </summary>
        private void MenuInit()
        {
            CCLabelTTF startlabel = CCLabelTTF.labelWithString("��ʼ", "ChineseTitle", 28);
            CCLabelTTF settinglabel = CCLabelTTF.labelWithString("ѡ��", "ChineseTitle", 28);
            CCLabelTTF listwordlabel = CCLabelTTF.labelWithString("�ʿ��б�", "ChineseTitle", 28);
            CCLabelTTF addwordlabel = CCLabelTTF.labelWithString("��Ӵ�", "ChineseTitle", 28);
            CCLabelTTF endlabel = CCLabelTTF.labelWithString("����", "ChineseTitle", 28);

            CCMenuItemLabel startbutton = CCMenuItemLabel.itemWithLabel(startlabel, this, this.StartCallback);
            CCMenuItemLabel settingbutton = CCMenuItemLabel.itemWithLabel(settinglabel, this, this.SettingCallback);
            CCMenuItemLabel managebutton = CCMenuItemLabel.itemWithLabel(listwordlabel, this, this.WordListClick);
            CCMenuItemLabel addwordbutton = CCMenuItemLabel.itemWithLabel(addwordlabel, this, this.WordAddClick);
            CCMenuItemLabel endbutton = CCMenuItemLabel.itemWithLabel(endlabel, this, this.closeCallback);

            startbutton.Color = new ccColor3B(Color.Black);
            settingbutton.Color = new ccColor3B(Color.Black);
            managebutton.Color = new ccColor3B(Color.Black);
            endbutton.Color = new ccColor3B(Color.Black);
            addwordbutton.Color = new ccColor3B(Color.Black);

            CCMenu menu = CCMenu.menuWithItems(startbutton, settingbutton, managebutton, addwordbutton, endbutton);

            menu.alignItemsInColumns(1, 1, 1, 1, 1);
            addChild(menu, 1);
        }
        /// <summary>
        /// ������ʼ��
        /// </summary>
        private void BackGroundInit(CCSize p_Size)
        {
            CCTexture2D backgroud = Media.PictureManager.GetCCTexture2DWithFile("image/BackGround");
            CCSprite pSprite = CCSprite.spriteWithTexture(backgroud);
            // position the sprite on the center of the screen
            pSprite.position = new CCPoint(p_Size.width / 2, p_Size.height / 2);

            // add the sprite as a child to this layer
            this.addChild(pSprite, 0);
        }
        #endregion


        /// <summary>
        /// ��ʼ��Ϸ�¼�
        /// </summary>
        public void SettingCallback(CCObject pSender)
        {
            try
            {
                SceneController.RunScene(EnumScene.Setting);
            }
            catch (Exception e)
            {
                ExceptionHelper.ExceptionProcess(e);
            }
        }
        /// <summary>
        /// ��ʼ��Ϸ�¼�
        /// </summary>
        public void StartCallback(CCObject pSender)
        {
            try
            {
                SceneController.RunScene(EnumScene.Question);
            }
            catch (Exception e)
            {
                ExceptionHelper.ExceptionProcess(e);
            }
        }
        /// <summary>
        /// �˳��¼�
        /// </summary>
        /// <param name="pSender"></param>
        public void closeCallback(CCObject pSender)
        {
            try
            {
                SceneController.ExitGame();
            }
            catch (Exception e)
            {
                ExceptionHelper.ExceptionProcess(e);
            }
        }
        public void WordListClick(CCObject pSender)
        {
            try
            {
                SceneController.RunScene(EnumScene.WordList);
            }
            catch (Exception e)
            {
                ExceptionHelper.ExceptionProcess(e);
            }
        }
        public void WordAddClick(CCObject pSender)
        {
            try
            {
                SceneController.RunScene(EnumScene.AddWord);
            }            
            catch (Exception e)
            {
                ExceptionHelper.ExceptionProcess(e);
            }
        }
    }
}

