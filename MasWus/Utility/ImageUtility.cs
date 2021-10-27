using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace MasWus.Utility
{
    public class ImageUtility
    {
        private static ImageUtility instance;

        private ImageUtility() { }

        public static ImageUtility getInstance()
        {
            if(instance == null)
            {
                instance = new ImageUtility();
            }
            return instance;
        }

        public string ConvertToImage(byte[] imageBytes)
        {
                string ImageUrl = "data:image/png;base64," + Convert.ToBase64String(imageBytes, 0, imageBytes.Length);
                return ImageUrl;
        }

        public byte[] ObjectToByteArray(Object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using(var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }
    }
}