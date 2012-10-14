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
using SayWordByPicture.Lib.File;
using System.IO;
using SayWordByPicture.Lib.Core;
using SayWordByPicture.Data;
using cocos2d;

namespace SayWordByPicture.Media
{
    public class PictureManager
    {
        static PictureManager()
        {
            ml = new MediaLibrary();
        }
        static MediaLibrary ml;
        public static bool HasPicture(String p_PictureName)
        {
           return  GetPicture(p_PictureName).Count>0;
        }
        /// <summary>
        /// 复制文件到
        /// </summary>
        /// <returns></returns>
        public static void CopyPicture(String p_SouceFile)
        {
            String filename= System.IO.Path.GetFileName(p_SouceFile);
            if (HasPicture(filename))
            {
                using (Stream stream = FileLoader.ReadFile(true, p_SouceFile))
                {
                    ml.SavePicture(filename, stream);
                }
            }
        }
        public static ByteBuffe GetPicture(String p_PictureName)
        {
            Picture pic= ml.Pictures.FirstOrDefault<Picture>(
                (obj) => {
                    return String.Equals(obj.Name, p_PictureName);
                });
            if (null != pic)
            {
                return ByteBuffe.FromStream(pic.GetImage());
            }
            return new ByteBuffe();
        }
        public static Texture2D GetTexture2D(String p_FilePath)
        {
            return Texture2D.FromStream(CCApplication.sharedApplication().GraphicsDevice, FileLoader.ReadFile(true, p_FilePath));
        }
        public static Texture2D GetTexture2D(Word p_Word)
        {
            return Texture2D.FromStream(CCApplication.sharedApplication().GraphicsDevice,FileLoader.ReadFile(p_Word.IsContent,p_Word.PictureFilePath));
        }
        public static Texture2D GetTexture2D(Word p_Word,Int32 p_Width,Int32 p_Height,bool p_Zoom)
        {
            return Texture2D.FromStream(CCApplication.sharedApplication().GraphicsDevice, FileLoader.ReadFile(p_Word.IsContent, p_Word.PictureFilePath), p_Width, p_Height, p_Zoom);
        }
        public static CCTexture2D GetCCTexture2D(Word p_Word, Int32 p_Width, Int32 p_Height, bool p_Zoom)
        {
            Texture2D text2D = GetTexture2D(p_Word,p_Width,p_Height,p_Zoom);
            CCTexture2D cctext2D = new CCTexture2D();
            cctext2D.initWithTexture(text2D);
            return cctext2D;
        }
        public static CCTexture2D GetCCTexture2D(String p_FilePath)
        {
            Texture2D text2D = Media.PictureManager.GetTexture2D(p_FilePath);
            CCTexture2D cctext2D = new CCTexture2D();
            cctext2D.initWithTexture(text2D);
            return cctext2D;
        }
        public static CCTexture2D GetCCTexture2D(Stream p_PicStrean, Int32 p_Width, Int32 p_Height, bool p_Zoom)
        {
            Texture2D text2D = Texture2D.FromStream(CCApplication.sharedApplication().GraphicsDevice, p_PicStrean,p_Width,p_Height,p_Zoom);
            CCTexture2D cctext2D = new CCTexture2D();
            cctext2D.initWithTexture(text2D);
            return cctext2D;
        }
        public static CCTexture2D GetCCTexture2D(Stream p_PicStrean)
        {
            Texture2D text2D = Texture2D.FromStream(CCApplication.sharedApplication().GraphicsDevice, p_PicStrean);
            CCTexture2D cctext2D = new CCTexture2D();
            cctext2D.initWithTexture(text2D);
            return cctext2D;
        }
        public static CCTexture2D GetCCTexture2DWithFile(String p_ContentFileName)
        {
            CCTexture2D cctext2D = new CCTexture2D();
            cctext2D.initWithTexture(CCApplication.sharedApplication().content.Load<Texture2D>(p_ContentFileName));
            return cctext2D;
        }
    }
}
