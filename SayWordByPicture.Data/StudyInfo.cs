using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SayWordByPicture.Lib.Core;
using System.Xml.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using SayWordByPicture.Lib.File;
using System.Xml;
using Microsoft.Xna.Framework.Audio;
namespace SayWordByPicture.Data
{
    /// <summary>
    /// ѧϰ��Ϣʵ��
    /// </summary>
    public class StudyInfo : IDisposable
    {
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="p_XmlFilePath">xml�����ļ�</param>
        ///  <param name="p_IsContent">�Ƿ�����Ŀ��������</param>
        public StudyInfo(String p_FilePath, bool p_IsContent)
        {
            Sounds = new Dictionary<Language, SoundEffect>();
            m_LangInfo = new Dictionary<Language, LanguageInfo>();
            XmlPath = p_FilePath;
            IsContentRes = p_IsContent;
            LoadResources();
        }
        /// <summary>
        /// ������Ϣ
        /// </summary>
        Dictionary<Language, LanguageInfo> m_LangInfo;
        /// <summary>
        /// ��Ч��Ϣ
        /// </summary>
        public bool IsValid { get { return m_LangInfo.Count >= 2 && Picture.Count>0; } }
        /// <summary>
        /// Language  SoundEffect for Play
        /// </summary>
        public Dictionary<Language, SoundEffect> Sounds { get; set; }
        /// <summary>
        /// �Ƿ��ǳ�����������
        /// </summary>
        public bool IsContentRes { get; private set; }
        /// <summary>
        /// ͼƬ��
        /// </summary>
        public ByteBuffe Picture { get; private set; }
        /// <summary>
        /// xml·��
        /// </summary>
        public String XmlPath { get; private set; }
        /// <summary>
        /// Get LanguageInfo by Language enum
        /// </summary>
        /// <param name="p_Language">Index��Language enum</param>
        /// <returns></returns>
        public LanguageInfo this[Language p_Language] { get { return m_LangInfo[p_Language]; } }
        
        #region load
        /// <summary>
        /// Load info ��picture��sound
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
        /// ������Ƶ����
        /// </summary>
        /// <returns></returns>
        private void LoadSoud()
        {
#if WINPHONE
            foreach (var key in m_LangInfo)
            {
                Sounds.Add(key.Key,
                 key.Value.Voice.ToSoundEffect()
                    );

            }
#endif
            //TODO android
        }
        #endregion

        #region static
        /// <summary>
        /// ����xml
        /// </summary>
        /// <param name="p_XmlFilePath">�ļ�·��</param>
        /// <param name="p_IsContent">�Ƿ�����������</param>
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
        /// ����xml ����
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
