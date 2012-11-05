using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using SayWordByPicture.App.People;
using SayWordByPicture.Data;
using SayWordByPicture.App.Core;
using SayWordByPicture.App.Core.Interface;
using Microsoft.Xna.Framework;
namespace SayWordByPicture.App.GameScene.Examination
{
    public class FloorLayer : BaseLayer, ITouchProcess
    {
        private const Int32 m_Heigth = 46;
        private const Int32 m_StillWhile = 80;
        public FloorLayer(Word p_Word)
        {
            base.init();
            m_Size = CCDirector.sharedDirector().getWinSize();
            this.isTouchEnabled = true;
            m_Word = p_Word;
            SayAction = new QuestionAction(m_Word);
        }
        public override void onEnter()
        {
            base.onEnter();
            LoadWordText();
            LoadSpeaker();
            runAction(SayAction);
        }
        CCSize m_Size;
        Speaker m_Speaker;
        QuestionAction SayAction;
        Word m_Word;
        private void LoadSpeaker()
        {
            m_Speaker = new Speaker();
            m_Speaker.position = new CCPoint(CCDirector.sharedDirector().getWinSize().width - (m_Speaker.contentSize.width / 2), m_Speaker.contentSize.height / 2);
            m_Speaker.SayAction = SayAction;

            m_Speaker.position = new CCPoint((m_Size.width / 2) + (m_Speaker.contentSize.width / 2) + m_StillWhile, (m_Speaker.contentSize.height / 2));
            addChild(m_Speaker);
            
        }
        private void LoadWordText()
        {
            CCSprite sprite = new CCSprite();
            CCTexture2D texture = new CCTexture2D();
           
            switch (Platform.QuestionLanguage)
            { 
                case Lib.Core.Language.Chinese:
                    texture.initWithString(m_Word.ChineseName, "ChineseContent", 20,Color.White,Color.Transparent);
                    break;
                case Lib.Core.Language.Enlish:
                default:
                    texture.initWithString(m_Word.EnglishName, "EnglishContent", 20, Color.White, Color.Transparent);
                    break;
            }
            sprite.initWithTexture(texture);
            sprite.Color = new ccColor3B(Color.White);
            sprite.position = new CCPoint((m_Size.width / 2) - (sprite.contentSize.width / 2) - m_StillWhile, (sprite.contentSize.height / 2));
            addChild(sprite);
        }

        public void OnClick(CCLayer p_Layer)
        {
            m_Speaker.OnClick(p_Layer);
        }
    }
}
