using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneServices.Interface
{
    public interface INetworkManage
    {
        /// <summary>
        /// is Connection network £¨Except gprs £©
        /// </summary>
        bool IsConnection { get; }
    }
}
