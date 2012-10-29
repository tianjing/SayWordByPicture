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
using System.Collections;

namespace SayWordByPicture.Data
{
    public static class DataManager
    {
        static DataManager()
        {
            DataBaseManager.InitDataBase();
        }
        public static List<Word> Words { get; set; }
        public static void RefreshWords()
        {
            Words = DataBaseManager.GetDatas();
        }
        public static void LoadData()
        {
            Words = DataBaseManager.GetDatas();
            if (Words.Count < 1)
            {
                DataBaseManager.BuildData();
                Words = DataBaseManager.GetDatas();
            }
        }
        /// <summary>
        /// 随机获取学习信息
        /// </summary>
        /// <param name="p_Number">获取数量</param>
        /// <returns></returns>
        public static List<Word> GetRandom(Int32 p_Number)
        {
            List<Word> list = new List<Word>();
            Int32 i = 0;
            while (i < p_Number)
            {
                Int32 index = Lib.Core.RandomHelper.GetRandomNumber(1, Words.Count);
                if (!list.Contains(Words[index],new WordComparer()))
                {
                    list.Add(Words[index]);
                    i += 1;
                }
            }
            return list;
        }
    }
    public class WordComparer :IEqualityComparer<Word>
    {

        public bool Equals(Word x, Word y)
        {
            if (String.Equals(x.ChineseName, y.ChineseName) ||
                String.Equals(x.EnglishName, y.EnglishName))
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(Word obj)
        {
            throw new NotImplementedException();
        }
    }
}
