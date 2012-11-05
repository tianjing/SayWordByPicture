using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SayWordByPicture.App.Photo
{
    public class PhotoEventArgs : EventArgs
    {
        public PhotoEventArgs(String p_FileName, Stream p_PhotoSteam)
        {
            FileName = p_FileName;
            PhotoSteam = p_PhotoSteam;
        }
        public String FileName { get; set; }
        public Stream PhotoSteam { get; set; }
    }
}
