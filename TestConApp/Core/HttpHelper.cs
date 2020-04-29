using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConApp.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class HttpHelper
    {
        #region 通用
        public string Get(string url)
        {
            return Send("GET", url, "");
        }

        public string Post(string url, string postData)
        {
            return Send("POST", url, postData);
        }
        public string PostJson(string url, string postData)
        {
            return Send("POST", url, postData, "application/json; charset=utf-8");
        }

        public string Send(string verb, string url, string postData, string contentType = "application/text; charset=utf-8")
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(url);

            //System.Net.WebProxy proxy = new WebProxy("10.10.101.9", 8080);
            //proxy.Credentials = new NetworkCredential("lx09140019", "118200");
            //req.Proxy = proxy;


            req.Timeout = 60 * 1000;
            //req.Headers.Add("Accept-Encoding", "gzip,deflate");
            req.UserAgent = "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_8_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/27.0.1453.110 Safari/537.36";

            req.Method = verb;

            try
            {
                if (verb == "POST")
                {
                    byte[] data = Encoding.UTF8.GetBytes(postData);

                    req.ContentType = contentType;
                    req.ContentLength = data.Length;

                    Stream requestStream = req.GetRequestStream();
                    requestStream.Write(data, 0, data.Length);
                    requestStream.Close();
                }


                using (var res = req.GetResponse())
                {
                    using (var stream = res.GetResponseStream())
                    {
                        StreamReader sr = new StreamReader(stream, Encoding.UTF8);
                        string response = sr.ReadToEnd();

                        sr.Close();

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Debug("HTTP Exception: " + ex.Message + " " + url + "  data:" + postData);
            }
            return null;

        }
        /// <summary>
        /// 发起GET异步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public async Task<string> HttpGetAsync(string url)
        {
            Log.Debug("这时我翻墙买盐了，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                await Task.Delay(2000);
                response.Content.ReadAsStringAsync();
                Log.Debug("我又翻回来了{0}，线程Id为：{1}", "ok", Thread.CurrentThread.ManagedThreadId.ToString());
                return "OK";
            }
        }
        #endregion

    }
}
