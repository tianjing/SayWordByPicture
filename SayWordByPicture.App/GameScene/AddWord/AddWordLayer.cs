using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using cocos2d;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework;
using SayWordByPicture.Data;
using Microsoft.Phone.Tasks;
using System.IO;
using SayWordByPicture.Lib.Core;
namespace SayWordByPicture.App.GameScene.AddWord
{
    internal sealed class AddWordLayer : CCLayer
    {
        public AddWordLayer()
        {
            base.init();
            m_Word = new Word();
        }
        public override void onEnter()
        {
            base.onEnter();
            m_CurrPostion = new CCPoint(0, 400);

            AddImageButton();
            AddChineseItem();
            AddEnglishItem();
            AddFormButton();
            sheduleUpdate();
        }

        #region update show data
        public override void update(float dt)
        {
            base.update(dt);
            if (null != m_Picture)
            {
                ShowPicture();
            }
            ShowName();
        }
        private void ShowPicture()
        {
            CCSprite sprite = CCSprite.spriteWithTexture(m_Picture);
            sprite.position = new CCPoint(240, 590);
            addChild(sprite, 0);
        }

        private void ShowName()
        {
            if (null != m_newChinese)
            {
                try
                {
                    m_ChineseLabel.setString(m_newChinese);
                    m_Word.ChineseName = m_newChinese;
                }
                catch (Exception e)
                {
                    m_newChinese = m_Word.ChineseName;
                    IAsyncResult ar = 
                    Guide.BeginShowMessageBox("提示", "您输入的文字不能识别！", new List<String> { "确定" }, 0, MessageBoxIcon.Alert, null, new Object());
                    Guide.EndShowMessageBox(ar);
                }
            }
            if (null != m_newEnglish)
            {
                try
                {
                    m_EnglishLabel.setString(m_newEnglish);
                    m_Word.EnglishName = m_newEnglish;
                }
                catch (Exception e)
                {
                     m_newEnglish=m_Word.EnglishName;
                    IAsyncResult ar = 
                    Guide.BeginShowMessageBox("提示", "您输入的文字不能识别！", new List<String> { "确定" }, 0, MessageBoxIcon.Alert, null, new Object());
                    Guide.EndShowMessageBox(ar);
                }
            }
        }
        #endregion

        private Word m_Word;
        private CCTexture2D m_Picture;
        private const Int32 StillWhite = 50;
        private CCPoint m_CurrPostion;
        private CCLabelTTF m_ChineseLabel;
        private CCLabelTTF m_EnglishLabel;
        private String m_newChinese;
        private String m_newEnglish;
        #region add Image
        /// <summary>
        /// add "select image" button
        /// </summary>
        private void AddImageButton()
        {
            CCMenuItemImage image = CCMenuItemImage.itemFromNormalImage("image/ButtonNormal", "image/ButtonClick", this, AddImageClick);
            CCLabelTTF text = CCLabelTTF.labelWithString("选择图片", "ChineseContent", 28);
            text.Color = new ccColor3B(Color.Black);
            CCMenuItemLabel label = CCMenuItemLabel.itemWithLabel(text);

            CCMenu menu = CCMenu.menuWithItems(image, label);
            menu.position = new CCPoint(240, m_CurrPostion.y);
            addChild(menu);

            m_CurrPostion.y -= image.contentSize.height;
            m_CurrPostion.y -= StillWhite;
        }
        private void AddImageClick(CCObject p_Sender)
        {
            PhotoChooserTask photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += SelectPictureComplete;
            photoChooserTask.ShowCamera = true;
            photoChooserTask.Show();

        }
        private void SelectPictureComplete(Object sender, PhotoResult e)
        {
            if (null == e.Error && e.TaskResult == TaskResult.OK)
            {
                m_Picture = Media.PictureManager.GetCCTexture2D(e.ChosenPhoto, 220, 380, false);
                m_Word.PictureFile = Path.GetFileName(e.OriginalFileName);
            }
        }
        #endregion


        #region TextBox
        /// <summary>
        /// create textbox item
        /// </summary>
        /// <returns></returns>
        private CCMenuItemImage LoadTextBoxSprite()
        {
            return CCMenuItemImage.itemFromNormalImage("image/TextBox", "image/TextBox", this, NameInput);
        }
        /// <summary>
        /// add chinese input item
        /// </summary>
        private void AddChineseItem()
        {
            CCMenuItemImage image = LoadTextBoxSprite();
            CCLabelTTF text = CCLabelTTF.labelWithString("中文", "ChineseTitle", 28);
            text.Color = new ccColor3B(Color.Black);
            CCMenuItemLabel label = CCMenuItemLabel.itemWithLabel(text);

            m_ChineseLabel = CreateTextLabel(Language.Chinese, String.Empty);
            m_ChineseLabel.Color = new ccColor3B(Color.Black);
            CCMenuItemLabel content = CCMenuItemLabel.itemWithLabel(m_ChineseLabel);
            content.position = new CCPoint(10, 0);
            image.addChild(content);

            CCMenu menu = CCMenu.menuWithItems(label, image);
            menu.alignItemsHorizontallyWithPadding(50);
            menu.position = new CCPoint(240, m_CurrPostion.y);
            addChild(menu);

            m_CurrPostion.y -= image.contentSize.height;
            m_CurrPostion.y -= StillWhite;
        }
        /// <summary>
        /// add chinese input item
        /// </summary>
        private void AddEnglishItem()
        {
            CCMenuItemImage image = LoadTextBoxSprite();

            CCLabelTTF text = CCLabelTTF.labelWithString("英文", "ChineseTitle", 28);
            text.Color = new ccColor3B(Color.Black);
            CCMenuItemLabel label = CCMenuItemLabel.itemWithLabel(text);

            m_EnglishLabel = CreateTextLabel(Language.Enlish, String.Empty);
            m_EnglishLabel.Color = new ccColor3B(Color.Black);
            CCMenuItemLabel content = CCMenuItemLabel.itemWithLabel(m_EnglishLabel);
            content.position = new CCPoint(10, 0);
            image.addChild(content);

            CCMenu menu = CCMenu.menuWithItems(label, image);
            menu.alignItemsHorizontallyWithPadding(50);
            menu.position = new CCPoint(240, m_CurrPostion.y);
            addChild(menu);

            m_CurrPostion.y -= image.contentSize.height;
            m_CurrPostion.y -= StillWhite;
        }
        private CCLabelTTF CreateTextLabel(Language p_Language, String p_Text)
        {
            switch (p_Language)
            {
                case Language.Chinese: return CCLabelTTF.labelWithString(p_Text, "ChineseContent", 28);
                case Language.Enlish:
                default:
                    return CCLabelTTF.labelWithString(p_Text, "EnglishContent", 28);
            }
        }
        private void NameInput(CCObject p_Sender)
        {
            String res = UserInput();
            CCMenuItemImage image = p_Sender as CCMenuItemImage;
            if (null != image)
            {
                CCLabelTTF text = image.parent.children[0].children[0] as CCLabelTTF;
                String languagename = text.getString();
                if (String.Equals("中文", languagename))
                {
                    m_newChinese = res;
                }
                else
                {
                    m_newEnglish = res;
                }
            }
        }
        string sipResult = String.Empty;
        string sipTitle = String.Empty;
        string sipDescription = String.Empty;
        private String UserInput()
        {
            IAsyncResult result = Guide.BeginShowKeyboardInput(PlayerIndex.One, sipTitle, sipDescription,
                sipResult, null, new object());
            return Guide.EndShowKeyboardInput(result);

        }

        #endregion
        /// <summary>
        /// add submit and cancel button
        /// </summary>
        private void AddFormButton()
        {
            CCMenuItemImage imagesubmit = CCMenuItemImage.itemFromNormalImage("image/ButtonNormal", "image/ButtonClick", this, AddImageClick);
            CCLabelTTF textsubmit = CCLabelTTF.labelWithString("确定", "ChineseContent", 28);
            textsubmit.Color = new ccColor3B(Color.Black);
            CCMenuItemLabel labelsubmit = CCMenuItemLabel.itemWithLabel(textsubmit);
            labelsubmit.position = new CCPoint(imagesubmit.contentSize.width / 2, imagesubmit.contentSize.height / 2);
            imagesubmit.addChild(labelsubmit);

            CCMenuItemImage imagecancel = CCMenuItemImage.itemFromNormalImage("image/ButtonNormal", "image/ButtonClick", this, AddImageClick);
            CCLabelTTF textcancel = CCLabelTTF.labelWithString("取消", "ChineseContent", 28);
            textcancel.Color = new ccColor3B(Color.Black);
            CCMenuItemLabel labelcancel = CCMenuItemLabel.itemWithLabel(textcancel);
            labelcancel.position = new CCPoint(imagecancel.contentSize.width / 2, imagecancel.contentSize.height / 2);

            imagecancel.addChild(labelcancel);


            CCMenu menu = CCMenu.menuWithItems(imagesubmit, imagecancel);
            menu.alignItemsHorizontally();
            menu.position = new CCPoint(240, m_CurrPostion.y);
            addChild(menu);

            m_CurrPostion.y -= imagesubmit.contentSize.height;
            m_CurrPostion.y -= StillWhite;

        }


    }
}
