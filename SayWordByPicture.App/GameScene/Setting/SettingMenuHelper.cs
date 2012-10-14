using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using Microsoft.Xna.Framework;

namespace SayWordByPicture.App.GameScene.Setting
{
    internal  static class SettingMenuHelper
    {
        public const Int32 Blank = 20;
        /// <summary>
        /// AddTitleMenu only text
        /// </summary>
        /// <param name="p_Layer">current CCLayer</param>
        /// <param name="p_TitleText">show text</param>
        /// <param name="y">current y</param>
        public static void AddTitleMenu(CCLayer p_Layer, String p_TitleText, ref float y)
        {
            CCLabelTTF label = CCLabelTTF.labelWithString(p_TitleText, "ChineseTitle", 28);
            label.Color = new ccColor3B(Color.White);

            CCMenuItemLabel tab = CCMenuItemLabel.itemWithLabel(label);
            CCMenu menu = CCMenu.menuWithItems(tab);

            menu.position = new CCPoint(CCDirector.sharedDirector().displaySizeInPixels.width / 2, y);
            //menu.position.y = p_CurrPoint.y;

            y -= tab.contentSize.height + Blank;
            p_Layer.addChild(menu);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p_Layer"></param>
        /// <param name="p_Text"></param>
        /// <param name="p_LeftButtonPic"></param>
        /// <param name="p_RightButtonPic"></param>
        /// <param name="y"></param>
        public static void AddSetMenu(CCLayer p_Layer, String p_Text,
                                                        String p_LeftButtonPic, String p_RightButtonPic,
                                                        SEL_MenuHandler p_LeftHandle,SEL_MenuHandler p_RightHandle,
                                                         ref float y)
        {
            CCLabelTTF language = CCLabelTTF.labelWithString(p_Text, "ChineseTitle", 28);
            language.Color = new ccColor3B(Color.White);
            CCMenuItemLabel tab1 = CCMenuItemLabel.itemWithLabel(language);

            //CCTexture2D cctext2D1 = Media.PictureManager.GetCCTexture2D(p_LeftButtonPic);
            //CCSprite sprite1 = CCSprite.spriteWithTexture(cctext2D1);
            CCMenuItemSprite tab2 = CCMenuItemImage.itemFromNormalImage(p_LeftButtonPic,null, p_Layer, p_LeftHandle);

            //CCTexture2D cctext2D2 = Media.PictureManager.GetCCTexture2D(p_RightButtonPic);
          //  CCSprite sprite2 = CCSprite.spriteWithTexture(cctext2D2);
            CCMenuItemSprite tab3 = CCMenuItemImage.itemFromNormalImage(p_RightButtonPic, null, p_Layer, p_RightHandle);

            CCMenu p_Menu1 = CCMenu.menuWithItems(tab1);
            CCMenu p_Menu2 = CCMenu.menuWithItems(tab2);
            CCMenu p_Menu3 = CCMenu.menuWithItems(tab3);

            //position p_Menu2 
            float textwidth = tab1.contentSize.width < 40 ? 40 : tab1.contentSize.width;

            float displayCenter = CCDirector.sharedDirector().displaySizeInPixels.width / 2;
            float x2 = displayCenter - textwidth;
            float x1 = displayCenter;
            float x3 = displayCenter + textwidth;
            float y2=y+(tab1.contentSize.height-tab2.contentSize.height)/2;

            p_Menu2.position = new CCPoint(x2, y2);
            p_Menu1.position = new CCPoint(x1, y);
            p_Menu3.position = new CCPoint(x3, y2);


            p_Layer.addChild(p_Menu2);
            p_Layer.addChild(p_Menu1);
            p_Layer.addChild(p_Menu3);

            y -= tab2.contentSize.height + Blank;
        }

    }
}
