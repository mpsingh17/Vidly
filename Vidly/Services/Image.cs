using System;
using System.IO;
using System.Web;


namespace Vidly.Services
{
    public class Image : IImageService
    {
        public void AddImage(HttpPostedFileBase image)
        {
            string imageName = Path.GetFileNameWithoutExtension(image.FileName);
            string extension = Path.GetExtension(image.FileName);
            string imagePathToStoreInDb = imageName + DateTime.Now.ToString("yyyymmssfff") + extension;
            
            

        }
    }
}