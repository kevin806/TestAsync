using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestConApp
{
    /// <summary>
    /// 看电视
    /// </summary>
    public class WatchTV
    {
        /// <summary>
        /// 打开电源开关
        /// </summary>
        public void OpenMainsSwitch()
        {
            Console.WriteLine("我和老婆正在看电视，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            Console.WriteLine("突然停电了，快去看下是不是跳闸了");
            Task task = CommandOpenMainsSwitch();
            Console.WriteLine("没电了先玩会儿手机吧，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            Thread.Sleep(100);
            Console.WriteLine("手机也没电了只等电源打开，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());

            //task.Wait();    //所以这里将被阻塞，直到任务完成
            //或者
            while (!task.IsCompleted) { Thread.Sleep(100); }

            Console.WriteLine("又有电了我们继续看电视，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
        }

        /// <summary>
        /// 通知我去打开电源开关
        /// </summary>
        public async Task CommandOpenMainsSwitch()
        {
            Console.WriteLine("这时我准备去打开电源开关，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            await Task.Run(() =>
            {
                Console.WriteLine("屁颠屁颠的去打开电源开关，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
                Thread.Sleep(1500);
                Console.WriteLine("打开电源开关中,马上打开，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            });

            Console.WriteLine("我完成任务，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
        }
        //1) 可见，调用 Wait() 方法后，当前线程被阻塞了，直到 Task 执行完成后，当前线程才继续执行。


    }
}
