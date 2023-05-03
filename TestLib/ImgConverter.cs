using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace TestLib
{
    public class ImgConverter
    {
        // Bitmap <-> byte[]
        public static byte[] BitmapToByteArr(Bitmap bitmap)
        {
            ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(bitmap, typeof(byte[]));
        }
        public static byte[] BitmapToByteArr(string path)
        {
            return File.ReadAllBytes(path);
        }

        public static Bitmap ByteArrToBitmap(byte[] blob)
        {
            using (MemoryStream memoryStream = new MemoryStream(blob))
            {
                return new Bitmap(memoryStream);
            }
        }

        // Bitmap <-> Base64String?
        public static string BitmapToBase64String(Bitmap bitmap)
        {
            ImageConverter converter = new ImageConverter();
            return Convert.ToBase64String((byte[])converter.ConvertTo(bitmap, typeof(byte[])));
        }

        public static string BitmapToBase64String(string path)
        {
            return Convert.ToBase64String(File.ReadAllBytes(path));
        }

        public static Bitmap Base64StringToBitmap(string str64)
        {
            byte[] blob = Convert.FromBase64String(str64);
            using (MemoryStream memoryStream = new MemoryStream(blob))
            {
                return new Bitmap(memoryStream);
            }
        }
    }
}
