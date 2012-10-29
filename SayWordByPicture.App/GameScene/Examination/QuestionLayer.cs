using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using SayWordByPicture.Data;
using SayWordByPicture.App.People;
using SayWordByPicture.Media;
using SayWordByPicture.Lib.Display;
using SayWordByPicture.App.Core;
using SayWordByPicture.App.Core.Interface;
using Microsoft.Xna.Framework;
namespace SayWordByPicture.App.GameScene.Examination
{
    /// <summary>
    /// 出题场景
    /// </summary>
    internal sealed class QuestionLayer : BaseLayer
    {

        public override void onEnter()
        {
            base.onEnter();
            this.isTouchEnabled = true;
            BackGroundInit();
            QuestionInit();
           // SpeakerLoad();

            FloorLayer floor = new FloorLayer(m_Answers[AnswerNumber-1].StudyInfo);
            addChild(floor);
        }
        Speaker m_Speaker;
        List<Selection> m_Answers;
        //QuestionAction SayAction;
        /// <summary>
        /// 背景初始化
        /// </summary>
        private void BackGroundInit()
        {

        }

   
        private void SpeakerLoad()
        {
            m_Speaker = new Speaker();
            m_Speaker.position = new CCPoint(CCDirector.sharedDirector().getWinSize().width - (m_Speaker.contentSize.width / 2), m_Speaker.contentSize.height / 2);
           // m_Speaker.SayAction = SayAction;
            addChild(m_Speaker);
        }
        private Int32 m_StillWhile = 80;
        private void QuestionInit()
        {
            CCSize size = CCDirector.sharedDirector().getWinSize();
            GetAnswerNumber();
            m_Answers = new List<Selection>();
            List<Word> list = Data.DataManager.GetRandom(Platform.QuestionNum);

            Int32 length = m_Answers.Count;
            Int32 lineNum = Platform.QuestionNum / 2;
            Int32 vertical = Platform.QuestionNum / lineNum;
            CCSize oneSize = new CCSize((size.width - m_StillWhile * lineNum) / lineNum, (size.height - m_StillWhile * vertical) / vertical);
            CCPoint curr = new CCPoint((m_StillWhile/2) + (oneSize.width / 2), size.height-( (m_StillWhile/2) + (oneSize.height / 2)));

            for (var i = 0; i < list.Count; i++)
            {
                if (i > 0 && (i % lineNum) == 0)
                {
                    curr.x = (m_StillWhile/2)+(oneSize.width / 2);
                    curr.y -= (oneSize.height + m_StillWhile/2);
                }

                Selection select = null;
                select = new Selection(list[i], i == AnswerNumber - 1, (Int32)oneSize.width, (Int32)oneSize.height);

                select.position = new CCPoint(curr.x, curr.y);
                curr.x += oneSize.width + m_StillWhile;

              //  if (i == AnswerNumber - 1)
              //  {
              //      SayAction = new QuestionAction(select);
              //  }
                //select.visible = true;
                this.addChild(select);
                m_Answers.Add(select);
            }
            //runAction(SayAction);
        }


        private void GetAnswerNumber()
        {
            AnswerNumber = Lib.Core.RandomHelper.GetRandomNumber(1, Platform.QuestionNum);
        }
        /// <summary>
        /// 答案项
        /// </summary>
        public Int32 AnswerNumber { get; set; }

    }
}
