using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
namespace SayWordByPicture.App.Core
{
    public class ActionHelper
    {
        public static void AsyncActionCallBack(CCAction p_Action,EventHandler CallBack)
        {
            System.Threading.ThreadPool.QueueUserWorkItem
                ((obj) =>
                {
                    while (true)
                    {
                        System.Threading.Thread.Sleep(100);
                        if (p_Action.isDone())
                        {
                            CallBack.Invoke(null,new EventArgs());
                            break;
                        }
                    }
                });
        }
    }
}
