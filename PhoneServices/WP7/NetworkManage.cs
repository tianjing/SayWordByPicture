using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Phone.Net.NetworkInformation;
using PhoneServices.Interface;
namespace PhoneServices
{
    public class NetworkManage:INetworkManage
    {
        private NetworkManage() { }
        static INetworkManage m_Current;
        public static INetworkManage Current
        {
            get
            {
                if (null == m_Current)
                {
                    m_Current = new NetworkManage();
                }
                return m_Current;
            }
        }
        /// <summary>
        ///  is Connection network （Except gprs ）
        /// </summary>
        public bool IsConnection {
            get {
                return NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211
                || NetworkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet;
            } }
    }
}
