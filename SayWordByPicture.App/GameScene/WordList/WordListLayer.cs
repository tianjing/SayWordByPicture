using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using SayWordByPicture.Data;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SayWordByPicture.App.GameScene.WordManage
{
    /// <summary>
    /// list word database 
    /// </summary>
    internal sealed class WordListLayer : CCLayer
    {
        public const Int32 PictureWidth = 100;
        public const Int32 PictureHeight = 100;
        /// <summary>
        /// init
        /// </summary>
        public WordListLayer()
        {
            base.init();
            isTouchEnabled = true;
            DisplaySize = CCDirector.sharedDirector().getWinSize();
        }
        /// <summary>
        /// load data
        /// </summary>
        public override void onEnter()
        {
            base.onEnter();
            GetTotalHeight();
            LoadWords();
        }
        /// <summary>
        /// load words form database
        /// </summary>
        private void LoadWords()
        {
            Int32 count = DataManager.Words.Count;
            for (var i = 0; i < count; i++)
            {
                LoadWord(DataManager.Words[i]);
                AddLine();
            }
        }
        public CCSize DisplaySize;
        public Int32 m_y = 800;
        /// <summary>
        /// show word
        /// </summary>
        /// <param name="p_Word">word object</param>
        private void LoadWord(Word p_Word)
        {
            m_y -= 10;
            //Picture
            CCSprite spritepic = CCSprite.spriteWithTexture(Media.PictureManager.GetCCTexture2D(p_Word, PictureWidth, PictureHeight, false));
            //word name
            CCLabelTTF chineseText = CCLabelTTF.labelWithString(p_Word.ChineseName, "ChineseContent", 28);
            CCMenuItemLabel chineseLabel = CCMenuItemLabel.itemWithLabel(chineseText);
            CCLabelTTF englishText = CCLabelTTF.labelWithString(p_Word.EnglishName, "EnglishContent", 28);
            CCMenuItemLabel englishLabel = CCMenuItemLabel.itemWithLabel(englishText);
            //del button
            CCLabelTTF delText = CCLabelTTF.labelWithString("É¾³ý", "ChineseContent", 28);
            CCMenuItemLabel delbutton = CCMenuItemLabel.itemWithLabel(delText, this, this.DeleteClick);
            delbutton.userData = p_Word;
            CCMenu menu = CCMenu.menuWithItems(delbutton);

            spritepic.position = new CCPoint(80, m_y - spritepic.contentSize.height / 2);
            chineseLabel.position = new CCPoint(250, m_y - 40);
            chineseLabel.Color = new ccColor3B(Color.Black);
            englishLabel.position = new CCPoint(250, m_y - 80);
            englishLabel.Color = new ccColor3B(Color.Black);
            menu.position = new CCPoint(430, m_y - 60);
            delbutton.Color = new ccColor3B(Color.Black);
            addChild(spritepic);
            addChild(chineseLabel);
            addChild(englishLabel);
            addChild(menu);

            m_y -= PictureHeight;
            m_y -= 10;
        }
        private void AddLine()
        {
            CCSprite spriteline = CCSprite.spriteWithTexture(Media.PictureManager.GetCCTexture2DWithFile("image/Line"));
            
            spriteline.position = new CCPoint(DisplaySize.width / 2, m_y);
            addChild(spriteline);
        }
        /// <summary>
        /// delete one word with user click
        /// </summary>
        public void DeleteClick(CCObject pSender)
        {
            CCMenuItemLabel label = pSender as CCMenuItemLabel;
            if (null != label && null != label.userData)
            {
                Word word = label.userData as Word;
                if (DataBaseManager.Delete(word.Id))
                {
                    DataManager.RefreshWords();
                    WordListScene wms = new WordListScene();
                    wms.Run(this.position);
                }
            }
        }
        private void GetTotalHeight()
        {
            m_TotalHeight = DataManager.Words.Count * 120 - 800;
        }
        private CCPoint m_tBeginPos;
        Int32 m_TotalHeight;
        static CCPoint s_tCurPos = new CCPoint(0.0f, 0.0f);
        public override void ccTouchesBegan(List<CCTouch> pTouches, CCEvent pEvent)
        {
            CCTouch touch = pTouches.FirstOrDefault();

            m_tBeginPos = touch.locationInView(touch.view());
            m_tBeginPos = CCDirector.sharedDirector().convertToGL(m_tBeginPos);
        }
        public override void ccTouchesMoved(List<CCTouch> pTouches, CCEvent pEvent)
        {
            CCTouch touch = pTouches.FirstOrDefault();

            CCPoint touchLocation = touch.locationInView(touch.view());
            touchLocation = CCDirector.sharedDirector().convertToGL(touchLocation);
            float nMoveY = touchLocation.y - m_tBeginPos.y;
            CCPoint curPos = this.position;
            CCPoint nextPos = new CCPoint(curPos.x, curPos.y + nMoveY);
            CCSize winSize = CCDirector.sharedDirector().getWinSize();
            if (nextPos.y < 0.0f)
            {
                this.position = new CCPoint(0, 0);
                return;
            }

            if (nextPos.y >= m_TotalHeight)
            {
                this.position = new CCPoint(0, m_TotalHeight);
                return;
            }

            this.position = nextPos;
            m_tBeginPos = touchLocation;
            s_tCurPos = nextPos;
        }
    }
}
