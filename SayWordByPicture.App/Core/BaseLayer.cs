using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
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
    }
}
