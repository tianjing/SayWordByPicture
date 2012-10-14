using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.IO.IsolatedStorage;
using System.Windows.Resources;
using System.Windows;
using cocos2d;
using SayWordByPicture.App;
namespace SayWordByPicture
{
    /// <summary>
    /// 这是游戏的主类型
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.graphics.IsFullScreen = true;
            // Windows Phone 的默认帧速率为 30 fps。
            TargetElapsedTime = TimeSpan.FromTicks(333333);
            // 延长锁定时的电池寿命。
            InactiveSleepTime = TimeSpan.FromSeconds(1);
            
            CCApplication application = new AppDelegate(this, graphics);
            this.Components.Add(application);
        }
    }

}
