using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SayWordByPicture.App.Photo
{
   public class PhotoChooser
    {
        public PhotoChooser()
        {

        }
        public String FileName;
        public Stream PhotoSteam;
        /// <summary>
        /// select photo
        /// </summary>
        public void SelectPhoto()
        {

        }
        public event EventHandler<PhotoEventArgs> Completed;

    }
}
