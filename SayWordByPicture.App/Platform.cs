using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SayWordByPicture.Lib.Core;

namespace SayWordByPicture.App
{
	public static class Platform
	{
		static Platform ()
		{
			AppSetting = PhoneServices.AppConfig.Current;
		}

		static PhoneServices.Interface.IAppConfig AppSetting{ get; set; }

		/// <summary>
		/// 一次出题数量
		/// </summary>
		public static Int32 QuestionNum {
			get {
				Object obj;
				if (!AppSetting.TryGetValue ("QuestionNum", out obj)) {
					Int32 num = 4;
					AppSetting.SetValue ("QuestionNum", num);
					return num;
				} else {
					return System.Convert.ToInt32 (obj);
				}
			}
			set {
				Int32 setvalue = value <= 4 ? 4 : value;
				setvalue = setvalue >= 6 ? 6 : setvalue;
				AppSetting.SetValue ("QuestionNum", setvalue);
			}
		}
		/// <summary>
		/// 出题时的发音
		/// </summary>
		public static Language QuestionLanguage {
			get {
				Object obj;
				if (!AppSetting.TryGetValue ("QuestionLanguage", out obj)) {
					Language value = Language.Enlish;
					AppSetting.SetValue ("QuestionLanguage", (Int32)value);
					return value;
				} else {
					return (Language)System.Convert.ToInt32 (obj);
				}
			}
			set {
				AppSetting.SetValue ("QuestionLanguage", (Int32)value);
			}
		}
	}
}
