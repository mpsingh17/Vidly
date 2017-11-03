using System;
using System.IO;
using System.Web;


namespace Vidly.Services
{
    public class Image : IImageService
    {
        public string AddImage(HttpServerUtilityBase Server, HttpPostedFileBase image)
        {
            // Prepare image name.
            string imageNameWithoutExt = Path.GetFileNameWithoutExtension(image.FileName);
            string extension = Path.GetExtension(image.FileName);
            string imageNameWithExt = imageNameWithoutExt + DateTime.Now.ToString("yyyymmssfff") + extension;

            // Saving image to server.
            string imagePath = Path.Combine(Server.MapPath("~/Images"), imageNameWithExt);
            image.SaveAs(imagePath);

            // Image URL to store in Database.
            string imageUrl = Path.Combine("/Images/", imageNameWithExt);
            return imageUrl;
        }
    }
}