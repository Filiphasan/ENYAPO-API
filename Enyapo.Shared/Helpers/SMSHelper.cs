using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Enyapo.Shared.Helpers
{
    public class SMSHelper
    {
        private string XMLPost(string PostAddress, string xmlData)
        {
            try
            {
                var res = "";
                byte[] bytes = Encoding.UTF8.GetBytes(xmlData);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(PostAddress);

                request.Method = "POST";
                request.ContentLength = bytes.Length;
                request.ContentType = "text/xml";
                request.Timeout = 300000000;
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(bytes, 0, bytes.Length);
                }

                // This sample only checks whether we get an "OK" HTTP status code back.
                // If you must process the XML-based response, you need to read that from
                // the response stream.
                using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                {
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        string message = String.Format(
                        "POST failed. Received HTTP {0}",
                        response.StatusCode);
                        throw new ApplicationException(message);
                    }

                    Stream responseStream = response.GetResponseStream();
                    using (StreamReader rdr = new StreamReader(responseStream))
                    {
                        res = rdr.ReadToEnd();
                    }
                    return res;
                }
            }
            catch
            {

                return "-1";
            }
        }
        public void SendSMSForNewUser(string number)
        {
            String testXml = "<request>";
            testXml += "<authentication>";
            testXml += "<username>5370352059</username>";
            testXml += "<password>filip483706</password>";
            testXml += "</authentication>";
            testXml += "<order>";
            testXml += "<sender>HASANERDAL</sender>";
            testXml += "<sendDateTime></sendDateTime>";
            testXml += "<message>";
            testXml += "<text>ENYAPO ailesine hoşgeldiniz. Sizi aramızda görmekten mutluluk duyuyoruz.</text>";
            testXml += "<receipents>";
            testXml += "<number>" + number + "</number>";
            testXml += "</receipents>";
            testXml += "</message>";
            testXml += "</order>";
            testXml += "</request>";
            XMLPost("https://api.iletimerkezi.com/v1/send-sms", testXml);
        }
    }
}
