using System.Collections.Generic;
using System.IO;
using PhoneServices.Interface;
namespace PhoneServices
{
	public sealed class Content : IContent
	{
		private Content()
		{ }
		static IContent m_Current;
		public static IContent Current
		{
			get
			{
				if (null == m_Current)
				{
					m_Current = new Content();
				}
				return m_Current;
			}
		}
		/// <summary>
		/// get stream by content file
		/// </summary>
		/// <param name="p_FilePath">file full path</param>
		/// <returns></returns>
		public System.IO.Stream ReadFile(string p_FilePath)
		{
			//return Android.App.Application.Context.Assets.Open(p_FilePath);
			return Microsoft.Xna.Framework.TitleContainer.OpenStream(p_FilePath);
		}
	}
}
