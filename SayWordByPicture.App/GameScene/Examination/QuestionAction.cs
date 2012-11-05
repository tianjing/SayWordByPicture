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
        public QuestionAction(Word p_Word)
       {
           m_Word = p_Word;
       }
        Word m_Word;
       public override void step(float dt)
       {
           base.step(dt);
       }
       public override bool isDone()
       {
           return base.isDone();
       }
       public override void startWithTarget(CCNode target)
       {
           base.startWithTarget(target);
       }
       public override void stop()
       {
           base.stop();
           if (null != m_Word)
           {
               Media.AudioManager.Play(Platform.QuestionLanguage, m_Word);
           }
       }
       
       public override void update(float dt)
       {
           base.update(dt);
       }
    }
}
