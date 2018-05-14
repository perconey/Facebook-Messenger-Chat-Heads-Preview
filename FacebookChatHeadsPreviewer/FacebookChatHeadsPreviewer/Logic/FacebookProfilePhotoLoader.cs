using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FacebookChatHeadsPreviewer.Logic
{
    class FacebookProfilePhotoLoader
    {
        
        public FacebookProfilePhotoLoader()
        {

        }

        public string SearchByUrl(string urlAddress)
        {
            string data = "Error";
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
            return Regex.Match(data, @"(?<=fb://profile/)(\d{15})").ToString();
        }
    }
}
