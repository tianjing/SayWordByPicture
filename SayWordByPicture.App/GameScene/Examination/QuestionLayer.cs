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
        }
        /// <summary>
        /// 背景初始化
        /// </summary>
        private void BackGroundInit()
        {

        }

        List<Selection> m_Answers;
        private FloorLayer m_Floor;
        private Int32 m_StillWhile = 50;
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
            CCPoint curr = new CCPoint((m_StillWhile/2) + (oneSize.width / 2), size.height-( (m_StillWhile/4) + (oneSize.height / 2)));

            for (var i = 0; i < list.Count; i++)
            {
                if (i > 0 && (i % lineNum) == 0)
                {
                    curr.x = (m_StillWhile / 2) + (oneSize.width / 2);
                    curr.y -= (oneSize.height + m_StillWhile/4);
                }

                Selection select = null;
                select = new Selection(list[i], i == AnswerNumber - 1, (Int32)oneSize.width, (Int32)oneSize.height);

                select.position = new CCPoint(curr.x, curr.y);
                curr.x += oneSize.width + m_StillWhile;

                if (i == AnswerNumber - 1)
                {
                    m_Floor = new FloorLayer(select.StudyInfo);
                }
                select.visible = true;
                this.addChild(select);
                m_Answers.Add(select);
            }
            this.addChild(m_Floor);
        }




        private void GetAnswerNumber()
        {
            AnswerNumber = Lib.Core.RandomHelper.GetRandomNumber(1, Platform.QuestionNum);
        }
        /// <summary>
        /// 答案项
        /// </summary>
        public Int32 AnswerNumber { get; set; }

        public override void ccTouchesEnded(List<CCTouch> touches, CCEvent event_)
        {
            base.ccTouchesEnded(touches, event_);
            Int32 length = this.children.Count;
            for (int i = 0; i < length; i++)
            {
                if (IsTouchNode(this.children[i], touches))
                {
                    ITouchProcess clicker = this.children[i] as ITouchProcess;
                    if (null != clicker)
                    {
                        clicker.OnClick(this);
                    }
                }
            }
        }
    }
}
