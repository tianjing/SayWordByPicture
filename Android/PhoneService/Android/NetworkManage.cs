using System;
using PhoneServices.Interface;
using System.Net.NetworkInformation;

namespace PhoneServices
{
	public class NetworkManage:INetworkManage
	{
		private NetworkManage ()
		{
		}

		static INetworkManage m_Current;

		public static INetworkManage Current {
			get {
				if (null == m_Current) {
					m_Current = new NetworkManage ();
				}
				return m_Current;
			}
		}

		#region INetworkManage implementation

		public bool IsConnection {
			get {
				if (NetworkInterface.GetIsNetworkAvailable ()) {
					if (Android.Net.ConnectivityManager.IsNetworkTypeValid( Android.Net.ConnectivityType.Ethernet)
					    ||Android.Net.ConnectivityManager.IsNetworkTypeValid( Android.Net.ConnectivityType.Wifi)

					   ) {
						return true;
					}
				}
			
				return false;
			}
		}

		#endregion
	}
}

