using System;
using PhoneServices.Interface;
using Android.Content;
namespace PhoneServices
{
	public class AppConfig:IAppConfig
	{
		private AppConfig ()
		{
			m_Read=Android.App.Application.Context.GetSharedPreferences("AppSetting", FileCreationMode.Private);
			m_Edit=m_Read.Edit();
		}
        static IAppConfig m_Current;
        public static IAppConfig Current
        {
            get
            {
                if (null == m_Current)
                {
                    m_Current = new AppConfig();
                }
                return m_Current;
            }
        }
		#region IAppConfig implementation
		ISharedPreferences  m_Read;
		ISharedPreferencesEditor m_Edit;
		public bool TryGetValue (string p_Key, out object p_Value)
		{
			return m_Read.All.TryGetValue(p_Key,out p_Value);
		}

		public void SetValue (string p_Key, object p_Value)
		{
			String res = p_Value as String;
			if (null != res) {
				m_Edit.PutString (p_Key, res);
                m_Edit.Commit();
			}
		}

		#endregion
	}
}

