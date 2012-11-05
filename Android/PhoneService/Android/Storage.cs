using System;
using PhoneServices.Interface;
using System.IO;

namespace PhoneServices
{
	public class Storage : IStorage
	{
		private Storage ()
		{
		}

		static IStorage m_Current;

		public static IStorage Current {
			get {
				if (null == m_Current) {
					m_Current = new Storage ();
				}
				return m_Current;
			}
		}
        #region IStorage implementation
		public static String DataPath { get { return Android.App.Application.Context.FilesDir.AbsolutePath; } }

		public String[] GetDirectorys (String p_SearchPattern)
		{
			return Directory.GetDirectories (p_SearchPattern);
		}

		public String ReadTextFile (String p_FileName)
		{
			if (ValidFilePath (p_FileName)) {
				using (StreamReader stream = new StreamReader
                                (
                                Path.Combine(DataPath, p_FileName)
                                 )
                          ) {
					return stream.ReadToEnd ();
				}
			}
			return String.Empty;
		}

		public System.IO.Stream ReadFile (String p_FileName)
		{
			if (ValidFilePath (p_FileName)) {
				return File.OpenRead (p_FileName);
			}
			return null;
		}

		public void DeleteFile (String p_FilePath)
		{
			if (ValidFilePath (p_FilePath)) {
				File.Delete (Path.Combine (DataPath, p_FilePath));
			}
		}

		public bool CreateFile (String p_FilePath, byte[] p_bytes)
		{
			FileStream fs = null;
			try {
				String filePath = Path.Combine (DataPath, p_FilePath);
				String path = Path.GetDirectoryName (filePath);
				if (!Directory.Exists (path)) {
					Directory.CreateDirectory (path);
				}
				fs = File.Create (filePath);

				fs.Flush ();
				fs.Write (p_bytes, 0, p_bytes.Length);
				return true;
			} catch {
				return false;
			} finally {
				if (null != fs) {
					fs.Close ();
				}
			}
		}

		public bool CreateTextFile (String p_DirectoryName, String p_FileName, String p_Text)
		{
			StreamWriter fs = null;
			try {
				String dirPath = Path.Combine (DataPath, p_DirectoryName);
				if (!Directory.Exists (dirPath)) {
					Directory.CreateDirectory (dirPath);
				}
				fs = File.CreateText (Path.Combine (dirPath, p_FileName));

				fs.Flush ();
				fs.WriteLine (p_Text);
				return true;
			} catch {
				return false;
			} finally {
				if (null != fs) {
					fs.Close ();
				}
			}
		}

		public void CreateDirectory (String p_Path)
		{
			String dirPath = Path.Combine (DataPath, p_Path);
			if (!Directory.Exists (dirPath)) {
				Directory.CreateDirectory (dirPath);
			}
		}

		public bool DirectoryExists (String p_DirPath)
		{
			String dirPath = Path.Combine (DataPath, p_DirPath);
			return Directory.Exists (dirPath);
		}

		public bool FileExists (String p_FilePath)
		{
			return  File.Exists (Path.Combine (DataPath, p_FilePath));
		}
		/// <summary>
		/// 验证文件
		/// </summary>
		/// <param name="p_FilePath">文件路径</param>
		/// <returns></returns>
		private bool ValidFilePath (String p_FilePath)
		{
			return File.Exists (Path.Combine (DataPath, p_FilePath));
		}
        #endregion
	}
}

