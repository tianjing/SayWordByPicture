using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayWordByPicture.App.Core;
using cocos2d;

namespace SayWordByPicture.App.GameScene.AddWord
{
	sealed class AddWordScene:BaseScene
	{
		public AddWordScene ()
		{
			base.init ();
			CCDirector.sharedDirector ().deviceOrientation = ccDeviceOrientation.CCDeviceOrientationPortrait;
        
		}

		public override void Run ()
		{
			AddWordLayer start = new AddWordLayer ();
			addChild (start);
			CCDirector.sharedDirector ().replaceScene (this);
		}
	}
}
