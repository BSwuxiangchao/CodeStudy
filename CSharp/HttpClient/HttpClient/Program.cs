using System;
using System.Net;
using System.IO;

namespace HttpClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            HttpWebRequest httpWebRequest = HttpWebRequest.Create(@"https://www.baidu.com/") as HttpWebRequest;
            httpWebRequest.Method = "GET";
            //httpWebRequest.ContentType = ""
            httpWebRequest.ProtocolVersion = new Version(1, 1);
            HttpWebResponse httpWebResponse = httpWebRequest.GetResponse() as HttpWebResponse;
            Stream stream = httpWebResponse.GetResponseStream();
            StreamReader streamReader = new StreamReader(stream);
            string body = streamReader.ReadToEnd();
            //Console.WriteLine(body);
            foreach(var item in httpWebResponse.Headers)
            {
                Console.WriteLine(item + ": " + httpWebResponse.GetResponseHeader(item.ToString()));
            }

        }
    }
}
