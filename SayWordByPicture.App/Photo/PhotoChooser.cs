using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Phone.Tasks;

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
            PhotoChooserTask photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += SelectPictureComplete;
            photoChooserTask.ShowCamera = true;
            photoChooserTask.Show();
        }
        public event EventHandler<PhotoEventArgs> Completed;
        /// <summary>
        /// select photo Completed
        /// </summary>
        private void SelectPictureComplete(Object sender, PhotoResult e)
        {
            try
            {
                if (null == e.Error && e.TaskResult == TaskResult.OK)
                {
                    if (null != Completed)
                    {
                        Completed(this, new PhotoEventArgs(e.OriginalFileName, e.ChosenPhoto));
                    }
                }
            }
            catch (Exception ee)
            {
                ExceptionHelper.ExceptionProcess(ee);
            }
        }
    }
}
