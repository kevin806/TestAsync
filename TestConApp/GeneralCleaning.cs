using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConApp
{
    /// <summary>
    /// 大扫除
    /// </summary>
    public class GeneralCleaning
    {
        /// <summary>
        /// 扔垃圾
        /// </summary>
        public async void DropLitter()
        {
            Process processes = Process.GetCurrentProcess();
            Console.WriteLine("老婆开始打扫房间，当前进程Id为{0}, 线程Id为：{1}", processes.Id.ToString(), Thread.CurrentThread.ManagedThreadId.ToString());

            Console.WriteLine("垃圾满了，快去扔垃圾，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            //await CommandDropLitter();
            CommandDropLitter();
            Console.WriteLine("不管他继续打扫，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            Thread.Sleep(100);
            Console.WriteLine("老婆把房间打扫好了，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
        }

        /// <summary>
        /// 通知我去扔垃圾
        /// </summary>
        public async Task CommandDropLitter()
        {
            Console.WriteLine("这时我准备去扔垃圾，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            await Task.Run(() =>
            {
                Console.WriteLine("屁颠屁颠的去扔垃圾，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
                Thread.Sleep(1500);
                Console.WriteLine("垃圾扔了正在回家，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());

            });
            Console.WriteLine("垃圾扔了还有啥吩咐，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
        }
        //当前线程遇到 await 时，则立刻跳回调用方法继续往下执行。而 Task 执行完成之后将执行 await 之后的代码，并且与 await 之前的线程不是同一个。



    }
}
