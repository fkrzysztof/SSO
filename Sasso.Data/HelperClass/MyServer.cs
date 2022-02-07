using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Sasso.Data.HelperClass
{
    public static class MyServer
    {
        public static string MapPath(string path)
        {
            //return Path.Combine((string)AppDomain.CurrentDomain.GetData("ContentRootPath"), path);
            return Path.Combine((string)AppDomain.CurrentDomain.GetData("WebRootPath"), path);
        }
    }
}



