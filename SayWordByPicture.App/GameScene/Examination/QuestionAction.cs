using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
namespace SayWordByPicture.App.GameScene.Examination
{
    internal sealed class QuestionAction : CCAction
    {
       public QuestionAction(Selection p_Selection)
       {
           m_Selection = p_Selection;
       }
       Selection m_Selection;
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
           if (null != m_Selection)
           {
              Media.AudioManager.Play(Platform.QuestionLanguage,m_Selection.StudyInfo);
           }
       }
       
       public override void update(float dt)
       {
           base.update(dt);
       }
    }
}
