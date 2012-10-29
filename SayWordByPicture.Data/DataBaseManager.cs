using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Community.CsharpSqlite;
using SQLiteClient;
namespace SayWordByPicture.Data
{
    public class DataBaseManager
    {
        public const String TableName = "Words";
        public const String DataBaseName = "MyWord";
        static SQLiteConnection myDB = null;
        public static bool InitDataBase()
        {
            try
            {
                if (null == myDB)
                {
                    myDB = new SQLiteConnection(DataBaseName);
                    myDB.Open();
                    return CreateDataBase();
                }
                return true;
            }
            catch (Exception e)
            {
                String es = e.Message;
                return false;
            }

        }
        public const String SqlHasTable = "select count(*) from sqlite_master where type='table' and name='{0}'";
        public const String SqlCreateTable = @"CREATE TABLE {0}([Id] INTEGER PRIMARY KEY AUTOINCREMENT,[WordType] INTEGER, [ChineseName] nvarchar,[EnglishName] nvarchar ,[PictureFile] nvarchar  NOT NULL,[IsContent] Boolean  NOT NULL) ;";
        public const String SqlSelect = "select * from {0}";
        public const String SqlInsert = "Insert into {0}  (ChineseName,EnglishName,PictureFile,IsContent)values('{1}','{2}','{3}',{4})";
        public const String SqlDelete = "Delete From {0} where Id={1}";
        public const String SqlCount = "Select count(*) from {0} ";
        

        public static bool CreateDataBase()
        {
            try
            {
                Int32 result = 0;
                SQLiteCommand comm = myDB.CreateCommand(String.Format(SqlHasTable, TableName));
                Object obj = comm.ExecuteScalar();
                result = Convert.ToInt32(obj);
                if (result == 0)
                {
                    comm.CommandText = String.Format(SqlCreateTable, TableName);
                    result = comm.ExecuteNonQuery();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                String ss = e.Message;
                return false;
            }
        }

        public static List<Word> GetDatas()
        {
            List<Word> list = new List<Word>();
            SQLiteCommand comm = myDB.CreateCommand(String.Format(SqlSelect, TableName));
            return comm.ExecuteQuery<Word>().ToList();
        }
        public static Int32 GetDataCount()
        {
            List<Word> list = new List<Word>();
            SQLiteCommand comm = myDB.CreateCommand(String.Format(SqlSelect, TableName));
            Object obj = comm.ExecuteScalar();
            return Convert.ToInt32(obj);

        }
        /// <summary>
        /// Ìí¼Ó
        /// </summary>
        /// <param name="p_Word"></param>
        /// <returns></returns>
        public static bool Insert(Word p_Word)
        {
            SQLiteCommand comm = myDB.CreateCommand(String.Format(SqlInsert, TableName,
                p_Word.ChineseName, p_Word.EnglishName,
                p_Word.PictureFile,Convert.ToInt32(p_Word.IsContent)));
            return comm.ExecuteNonQuery() > 0;
        }
        /// <summary>
        /// É¾³ý
        /// </summary>
        /// <param name="p_Id"></param>
        /// <returns></returns>
        public static bool Delete(Int32 p_Id)
        {
            SQLiteCommand comm = myDB.CreateCommand(String.Format(SqlDelete, TableName, p_Id));
            return comm.ExecuteNonQuery() > 0;
        }
        public static void BuildData()
        {
            if (GetDataCount() > 0)
            {
                return;
            }

            List<Word> list = new List<Word>();
            #region add words
            #region Apple
            list.Add(new Word
            {
                ChineseName = "Æ»¹û",
                EnglishName = "Apple",
                PictureFile = "Apple.jpg",
                IsContent = true,
            });
            #endregion
            #region Banana
            list.Add(new Word
            {
                ChineseName = "Ïã½¶",
                EnglishName = "Banana",
                PictureFile = "Banana.jpg",
                IsContent = true,
            });
            #endregion
            #region Cherry
            list.Add(new Word
            {
                ChineseName = "Ó£ÌÒ",
                EnglishName = "Cherry",
                PictureFile = "Cherry.jpg",
                IsContent = true,
            });
            #endregion
            #region Orange
            list.Add(new Word
            {
                ChineseName = "éÙ×Ó",
                EnglishName = "Orange",
                PictureFile = "Orange.jpg",
                IsContent = true,
            });
            #endregion
            #region Coconut
            list.Add(new Word
            {
                ChineseName = "Ò¬×Ó",
                EnglishName = "Coconut",
                PictureFile = "Coconut.jpg",
                IsContent = true,
            });
            #endregion
            #region Blackberry
            list.Add(new Word
            {
                ChineseName = "ºÚÝ®",
                EnglishName = "Blackberry",
                PictureFile = "Blackberry.jpg",
                IsContent = true,
            });
            #endregion
            #region Grape
            list.Add(new Word
            {
                ChineseName = "ÆÏÌÑ",
                EnglishName = "Grape",
                PictureFile = "Grape.jpg",
                IsContent = true,
            });
            #endregion
            #region Loguat
            list.Add(new Word
            {
                ChineseName = "èÁèË",
                EnglishName = "Loguat",
                PictureFile = "Loguat.jpg",
                IsContent = true,
            });
            #endregion
            #region Pear
            list.Add(new Word
            {
                ChineseName = "Àæ",
                EnglishName = "Pear",
                PictureFile = "Pear.jpg",
                IsContent = true,
            });
            #endregion
            #region Papaya
            list.Add(new Word
            {
                ChineseName = "Ä¾¹Ï",
                EnglishName = "Papaya",
                PictureFile = "Papaya.jpg",
                IsContent = true,
            });
            #endregion
            #region Pomegranate
            list.Add(new Word
            {
                ChineseName = "Ê¯Áñ",
                EnglishName = "Pomegranate",
                PictureFile = "Pomegranate.jpg",
                IsContent = true,
            });
            #endregion
            #region Watermelon
            list.Add(new Word
            {
                ChineseName = "Î÷¹Ï",
                EnglishName = "Watermelon",
                PictureFile = "Watermelon.jpg",
                IsContent = true,
            });
            #endregion
            #region Pineapple
            list.Add(new Word
            {
                ChineseName = "²¤ÂÜ",
                EnglishName = "Pineapple",
                PictureFile = "Pineapple.jpg",
                IsContent = true,
            });
            #endregion
            #region Litchi
            list.Add(new Word
            {
                ChineseName = "ÀóÖ¦",
                EnglishName = "Litchi",
                PictureFile = "Litchi.jpg",
                IsContent = true,
            });
            #endregion
            #region Potato
            list.Add(new Word
            {
                ChineseName = "ÍÁ¶¹",
                EnglishName = "Potato",
                PictureFile = "Potato.jpg",
                IsContent = true,
            });
            #endregion
            #region Mango
            list.Add(new Word
            {
                ChineseName = "Ã¢¹û",
                EnglishName = "Mango",
                PictureFile = "Mango.jpg",
                IsContent = true,
            });
            #endregion

            #endregion

            for (var i = 0; i < list.Count; i++)
            {
                Insert(list[i]);
            }

        }
    }
}
