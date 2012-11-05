using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayWordByPicture.Lib.Core;
using System.Xml.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using System.Xml;
using Microsoft.Xna.Framework.Audio;
namespace SayWordByPicture.Data
{
    /// <summary>
    /// 学习信息实体
    /// </summary>
    public class StudyInfo : IDisposable
    {
        /// <summary>
        /// 构造
        /// </summary>
        /// <param name="p_XmlFilePath">xml数据文件</param>
        ///  <param name="p_IsContent">是否是项目内容数据</param>
        public StudyInfo(String p_FilePath, bool p_IsContent)
        {
            Sounds = new Dictionary<Language, SoundEffect>();
            m_LangInfo = new Dictionary<Language, LanguageInfo>();
            XmlPath = p_FilePath;
            IsContentRes = p_IsContent;
            LoadResources();
        }
        /// <summary>
        /// 语言信息
        /// </summary>
        Dictionary<Language, LanguageInfo> m_LangInfo;
        /// <summary>
        /// 有效信息
        /// </summary>
        public bool IsValid { get { return m_LangInfo.Count >= 2 && Picture.Count>0; } }
        /// <summary>
        /// Language  SoundEffect for Play
        /// </summary>
        public Dictionary<Language, SoundEffect> Sounds { get; set; }
        /// <summary>
        /// 是否是程序内容数据
        /// </summary>
        public bool IsContentRes { get; private set; }
        /// <summary>
        /// 图片流
        /// </summary>
        public ByteBuffe Picture { get; private set; }
        /// <summary>
        /// xml路径
        /// </summary>
        public String XmlPath { get; private set; }
        /// <summary>
        /// Get LanguageInfo by Language enum
        /// </summary>
        /// <param name="p_Language">Index：Language enum</param>
        /// <returns></returns>
        public LanguageInfo this[Language p_Language] { get { return m_LangInfo[p_Language]; } }
        
        #region load
        /// <summary>
        /// Load info 、picture、sound
        /// </summary>
        private void LoadResources()
        {
            bool result = true;
            if (!IsContentRes)
            {
                result = FileLoader.IsolatedStorageFileExists(XmlPath);
            }
            if (result)
            {
                XDocument xml = LoadXml(XmlPath, IsContentRes);
                m_LangInfo = GetInfoByFile(xml);
                Picture = LoadPicture(xml);
                LoadSoud();
            }
        }
        /// <summary>
        /// 加载音频数据
        /// </summary>
        /// <returns></returns>
        private void LoadSoud()
        {
            foreach (var key in m_LangInfo)
            {
                Sounds.Add(key.Key,
                 key.Value.Voice.ToSoundEffect()
                    );

            }
        }
        #endregion

        #region static
        /// <summary>
        /// 加载xml
        /// </summary>
        /// <param name="p_XmlFilePath">文件路径</param>
        /// <param name="p_IsContent">是否是内容数据</param>
        /// <returns></returns>
        private static XDocument LoadXml(String p_XmlFilePath, bool p_IsContent)
        {
            using (Stream stream = FileLoader.ReadFile(p_IsContent, p_XmlFilePath))
            {
                XDocument xml = XDocument.Load(stream, LoadOptions.None);
                if (null != xml)
                {
                    return xml;
                }
                return null;
            }
        }

        /// <summary>
        /// Load Picture 
        /// </summary>
        /// <param name="p_Xml">xml data</param>
        /// <returns></returns>
        private static ByteBuffe LoadPicture(XDocument p_Xml)
        {
            List<XElement> elements = p_Xml.Root.Elements("Picture").ToList();
            if (null != elements && elements.Count > 0)
            {
                return ByteBuffe.FromString(elements[0].Attribute("Value").Value);
            }
            return new ByteBuffe();
        }
        /// <summary>
        /// 载入xml 数据
        /// </summary>
        /// <param name="p_Xml">xml</param>
        /// <returns></returns>
        private static Dictionary<Language, LanguageInfo> GetInfoByFile(XDocument p_Xml)
        {
            Dictionary<Language, LanguageInfo> list = new Dictionary<Language, LanguageInfo>();
            List<XElement> elements = p_Xml.Root.Elements("Language").ToList();

            for (var i = 0; i < elements.Count; i++)
            {
                LanguageInfo model = new LanguageInfo();

                model.Name = elements[i].Attribute("Name").Value;
                model.Text = elements[i].Attribute("Text").Value;
                model.Voice = ByteBuffe.FromString(elements[i].Attribute("Voice").Value);
                
                if (model.IsVaild)
                {
                    if (String.Equals("Chinese", model.Name))
                    {
                        list.Add(Language.Chinese, model);
                    }
                    else if (String.Equals("English", model.Name))
                    {
                        list.Add(Language.Enlish, model);
                    }
                }
            }
            return list;
        }
        
        #endregion

        #region Dispose
        public void Dispose()
        {
            if (null != Sounds)
            {
                foreach (var sound in Sounds)
                {
                    sound.Value.Dispose();
                }
            }
            Sounds = null;

            if (null != Sounds)
            {
                foreach (var langinfo in m_LangInfo)
                {
                    langinfo.Value.Dispose();
                }
            }
            Sounds = null;
        }
        #endregion
    }
}
