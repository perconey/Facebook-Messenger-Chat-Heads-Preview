using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;

namespace FacebookChatHeadsPreviewer.Logic
{
    class FacebookProfilePhotoLoader
    {
        //http://graph.facebook.com/id/picture?type=large

        public FacebookProfilePhotoLoader()
        {

        }


        private string _id = "";

        public String Id
        {
            get
            {
                return _id;
            }
            set => _id = value;
        }

        public bool IdGood()
        {
            if (Id != "")
                return true;
            else
                return false;
        }

        public BitmapImage FetchImage()
        {
            var image = new BitmapImage();
            int BytesToRead = 100;

            WebRequest request = WebRequest.Create(new Uri($"http://graph.facebook.com/{Id}/picture?type=large", UriKind.Absolute));
            request.Timeout = -1;
            WebResponse response = request.GetResponse();
            Stream responseStream = response.GetResponseStream();
            BinaryReader reader = new BinaryReader(responseStream);
            MemoryStream memoryStream = new MemoryStream();

            byte[] bytebuffer = new byte[BytesToRead];
            int bytesRead = reader.Read(bytebuffer, 0, BytesToRead);

            while (bytesRead > 0)
            {
                memoryStream.Write(bytebuffer, 0, bytesRead);
                bytesRead = reader.Read(bytebuffer, 0, BytesToRead);
            }

            image.BeginInit();
            memoryStream.Seek(0, SeekOrigin.Begin);

            image.StreamSource = memoryStream;
            image.EndInit();

            return image;
        }

        public void SearchByUrl(string urlAddress)
        {
            string data = "Error";
            if (!String.IsNullOrEmpty(urlAddress))
            {
                var req = (HttpWebRequest)WebRequest.Create(urlAddress);
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.2; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.94 Safari/537.36";
                var resp = (HttpWebResponse)req.GetResponse();

                if (resp.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = resp.GetResponseStream();
                    StreamReader readStream = null;

                    if (resp.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(resp.CharacterSet));
                    }
                    data = readStream.ReadToEnd();

                    resp.Close();
                    readStream.Close();
                }
                var regName = Regex.Match(data, "(?<=<title id=\"pageTitle\">)(\\w+)");
                MessageBox.Show(regName.Value);
                var reg = Regex.Match(data, @"(?<=fb://profile/)(\d{15})");
                if (reg.Success)
                    Id = reg.Value;
                else
                    MessageBox.Show("There was an error while searching for facebook id");
            }
        }
    }
}
