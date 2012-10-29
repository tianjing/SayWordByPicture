using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using SayWordByPicture.Data;
namespace SayWordByPicture.App.GameScene.Examination
{
    internal sealed class QuestionAction : CCAction
    {
        public QuestionAction(Selection p_Selection)
        {
            m_Selection = p_Selection;
            m_Word = p_Selection.StudyInfo;
        }
        public QuestionAction(Word p_Word)
        {
            m_Word = p_Word;
        }
        Selection m_Selection;
        Word m_Word;
        public override void stop()
        {
            try
            {
                base.stop();
                if (null != m_Word)
                {
                    Media.AudioManager.Play(Platform.QuestionLanguage, m_Word);
                }
            }
            catch (Exception e)
            {
                ExceptionHelper.ExceptionProcess(e);
            }
        }

    }
}
