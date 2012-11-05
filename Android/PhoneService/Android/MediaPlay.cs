using System;
using PhoneServices.Interface;
using Android.Media;
using System.IO;

namespace PhoneServices
{
	public class MediaPlay:IMediaPlay
	{
		private MediaPlay ()
		{
		}

		static IMediaPlay m_Current;

		public static IMediaPlay Current {
			get {
				if (null == m_Current) {
					m_Current = new MediaPlay ();
				}
				return m_Current;
			}
		}

		#region IMediaPlay implementation
		public static String DataPath { get { return Android.App.Application.Context.FilesDir.AbsolutePath; } }

		public void Play (string p_FilePath)
		{
			using (MediaPlayer player = new MediaPlayer()) {
				if (p_FilePath.IndexOf ("Content") > -1) {
					Android.Content.Res.AssetFileDescriptor af = Android.App.Application.Context.Assets.OpenFd (p_FilePath);
					player.SetDataSource (af.FileDescriptor, af.StartOffset, af.Length);
				} else {
					player.SetDataSource (Path.Combine(DataPath,p_FilePath));
				}
				player.Prepare ();
				player.Start ();
			}
		}

		#endregion
	}
}

