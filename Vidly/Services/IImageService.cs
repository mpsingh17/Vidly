using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Vidly.Services
{
    interface IImageService
    {
        string AddImage(HttpServerUtilityBase Server, HttpPostedFileBase image);
    }
}
