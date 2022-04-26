using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Text;

namespace HttpServer
{
    class Program
    {
        static void loop(HttpListener httpListener)
        {

            HttpListenerContext context = httpListener.GetContext();
            HttpListenerRequest hRequest = context.Request;
            HttpListenerResponse hResponse = context.Response;
            //if(hRequest.HttpMethod =="GET")
            using (StreamWriter writer = new StreamWriter(hResponse.OutputStream, Encoding.UTF8))
            {
                //HttpWebResponse httpWebResponse = new HttpWebResponse()：
                writer.Write(@"Hello World");
                writer.Close();
                hResponse.Close();
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            if (!HttpListener.IsSupported)
            {
                throw new ArgumentException("环境不支持");
            }
            HttpListener httpListener = new HttpListener();
            if (httpListener == null)
            {
                httpListener = new HttpListener();
            }
            string url = @"http://127.0.0.1:1321/";
            httpListener.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
            httpListener.Prefixes.Add(url);
            try
            {
                httpListener.Start();
                Console.WriteLine("httpListener.Start ");
                while (true)
                {
                    loop(httpListener);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured at HttpServer create " + url + ex.Message);
                httpListener.Stop();
            }
        }
    }
}
