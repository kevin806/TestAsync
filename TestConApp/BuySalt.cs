using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConApp
{
    /// <summary>
    /// 买盐
    /// </summary>
    public class BuySalt
    {

        /// <summary>
        /// 做饭
        /// </summary>
        public async void CookDinner()
        {
            Console.WriteLine("老婆开始做饭，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            Console.WriteLine("哎呀，没盐了");
            Task<string> task = CommandBuySalt();
            Console.WriteLine("不管他继续做饭，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            Thread.Sleep(500);
            string result = task.Result;    //必须要用盐了，等我把盐回来（停止炒菜（阻塞线程））
            Console.WriteLine("该炒菜了等买盐回来,【{0}】，线程Id为：{1}", result, Thread.CurrentThread.ManagedThreadId.ToString());
            Console.WriteLine("用了盐炒的菜就是好吃【{0}】，线程Id为：{1}", result, Thread.CurrentThread.ManagedThreadId.ToString());
            Console.WriteLine("老婆把饭做好了，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
        }

        /// <summary>
        /// 通知我去买盐
        /// </summary>
        public async Task<string> CommandBuySalt()
        {
            Console.WriteLine("这时我准备去买盐了，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());

            string result = await Task.Run(() =>
            {
                Console.WriteLine("屁颠屁颠的去买盐，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
                Thread.Sleep(1800);
                return "盐买回来了，顺便我还买棒棒糖";

            });

            Console.WriteLine("{0}，线程Id为：{1}", result, Thread.CurrentThread.ManagedThreadId.ToString());

            return result;
        }

    }
}
