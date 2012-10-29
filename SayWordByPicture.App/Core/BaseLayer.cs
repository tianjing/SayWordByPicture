using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using SayWordByPicture.App.Core.Interface;
namespace SayWordByPicture.App.Core
{
   public class BaseLayer:CCLayer
    {
       public BaseLayer()
       {
           base.init();
       }

       protected bool IsTouchNode(CCNode p_Node, List<CCTouch> touches)
       {
           CCRect rect = p_Node.boundingBox();
           CCSize size = CCDirector.sharedDirector().getWinSize();

          // rect.size = p_Node.contentSize;
           CCPoint touch =new CCPoint( touches[0].locationInView(touches[0].view()).x, touches[0].locationInView(touches[0].view()).y);
           touch.y = size.height - touch.y;
            return CCRect.CCRectContainsPoint(rect, touch);
       }
       public override void ccTouchesBegan(List<CCTouch> touches, CCEvent event_)
       {
           base.ccTouchesBegan(touches, event_);
           TouchProcess(touches, event_);
       }
       private void TouchProcess(List<CCTouch> touches, CCEvent event_)
       {
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
