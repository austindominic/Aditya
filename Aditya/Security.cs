using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

namespace Aditya
{
    public class Security
    {
        public static string HashSHA1(string value)
        {
            var sha1 = System.Security.Cryptography.SHA1.Create();
            var inputBytes = Encoding.ASCII.GetBytes(value);
            var hash = sha1.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        public static string CreateRandomPassword(int passwordLength)
        {
            string allowedChars = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
            char[] chars = new char[passwordLength];
            Random rd = new Random();

            for (int i = 0; i < passwordLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        public static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }


        public static string UploadFile(HttpPostedFileBase file, string folderName, string dbFileName)
        {

            if (file == null) return null;
            var desiredFileName = dbFileName;
            var pic = Path.GetFileName(file.FileName);
            var path = Path.Combine(HttpContext.Current.Server.MapPath("~/assets/img/" + folderName + "/"), pic);

            var filename = desiredFileName;
            try
            {
                file.SaveAs(path);

                var imageDelete = new FileInfo(HttpContext.Current.Server.MapPath("~/assets/img/" + folderName + "/" + filename));
                if (imageDelete.Exists)
                    imageDelete.Delete();
                // Get a bitmap.
                var imageComp = new Bitmap(path);
                var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                var myEncoder = System.Drawing.Imaging.Encoder.Quality;
                var myEncoderParameters = new EncoderParameters(1);
                var myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                imageComp.Save(HttpContext.Current.Server.MapPath("~/assets/img/" + folderName + "/" + filename), jpgEncoder,
                    myEncoderParameters);
                imageComp.Dispose();
                var info1 = new FileInfo(path);
                if (info1.Exists)
                    info1.Delete();

                return desiredFileName;
            }
            catch (Exception ex)
            {
                return null;
            }

            // return View();

            //return View();
        }
    }
}