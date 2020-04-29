using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using TestConApp.Core;

namespace TestConApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Process processes = Process.GetCurrentProcess();
            Log.Debug("Hello World! ，当前进程Id为{0}, 线程Id为：{1}", processes.Id.ToString(), Thread.CurrentThread.ManagedThreadId.ToString());

            //var gc = new GeneralCleaning();
            //gc.DropLitter();

            //var wtv = new WatchTV();
            //wtv.OpenMainsSwitch();


            //var buy = new BuySalt();
            //buy.CookDinner();

            //int MaxWorkerThreads, miot, AvailableWorkerThreads, aiot;

            ////获得最大的线程数量
            //System.Threading.ThreadPool.GetMaxThreads(out MaxWorkerThreads, out miot);

            //AvailableWorkerThreads = aiot = 0;

            ////获得可用的线程数量
            //System.Threading.ThreadPool.GetAvailableThreads(out AvailableWorkerThreads, out aiot);

            ////返回线程池中活动的线程数

            //Log.Debug($"{MaxWorkerThreads},  {AvailableWorkerThreads}  {MaxWorkerThreads - AvailableWorkerThreads}");

            //TestRunAsync().GetAwaiter().GetResult();

            //Thread.Sleep(5000);


            var fetch = new FetchWeb();
            //fetch.GetWeb();
            fetch.GetWeb2();

            Log.Debug("按任意键结束! ，线程Id为：{0}", Thread.CurrentThread.ManagedThreadId.ToString());
            Console.ReadKey();

        }

    }
}
