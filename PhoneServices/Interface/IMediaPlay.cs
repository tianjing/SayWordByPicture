using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneServices.Interface
{
    public interface IMediaPlay
    {
        /// <summary>
		/// play wav sound
        /// </summary>
        /// <param name="p_FilePath">wav file path</param>
        void Play(String p_FilePath);
    }
}
