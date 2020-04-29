using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestConApp.Core;

namespace TestConApp
{
    public class FetchWeb
    {
        /// <summary>
        /// 获取网页
        /// </summary>
        /// <returns></returns>
        public async Task GetWeb()
        {
            var helper = new HttpHelper();
            Log.Debug("打开浏览器，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            Log.Debug("打开完成");
            Task<string> task = helper.HttpGetAsync("https://www.maxburst.com/");
            Log.Debug("不管他继续操作，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            Thread.Sleep(500);
            string result = task.Result;    //必须要用盐了，等我把盐回来（停止炒菜（阻塞线程））
            Log.Debug("该看新闻了,【{0}】，线程Id为：{1}", result, Thread.CurrentThread.ManagedThreadId.ToString());
            Log.Debug("看好了，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
        }

        /// <summary>
        /// 获取网页2
        /// </summary>
        /// <returns></returns>
        public async Task GetWeb2()
        {
            var helper = new HttpHelper();
            Log.Debug("打开浏览器，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            Log.Debug("打开完成");
            await helper.HttpGetAsync("https://www.maxburst.com/");
            Log.Debug("不管他继续操作，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            Thread.Sleep(500);
            Log.Debug("该看新闻了,【{0}】，线程Id为：{1}", "-", Thread.CurrentThread.ManagedThreadId.ToString());
            Log.Debug("看好了，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
        }


    }
}
