using System;
using System.Threading;

namespace Threading1
{
    public class Simple
    {
        public static int Main()
        {
                Console.WriteLine("Thread Start/Stop/Join  When you press Enter Key");
            if (Console.ReadKey().Key == ConsoleKey.Enter)
            {

                Alpha oAlpha = new Alpha();

                // Create the thread object, passing in the Alpha.Beta method
                // via a ThreadStart delegate. This does not start the thread.
                Thread oThread = new Thread(new ThreadStart(oAlpha.Beta));

                // Start the thread
                oThread.Start();

                // Spin for a while waiting for the started thread to become
                // alive:
                while (!oThread.IsAlive) ;

                // Put the Main thread to sleep for 1 millisecond to allow oThread
                // to do some work:
                Console.WriteLine("Main Thread is going to sleep");
                Thread.Sleep(1000);

                // Request that oThread be stopped
                oThread.Abort();

                // Wait until oThread finishes. Join also has overloads
                // that take a millisecond interval or a TimeSpan object.
                oThread.Join();

                Console.WriteLine();
                Console.WriteLine("Alpha.Beta has finished");

                Console.WriteLine();
                Console.WriteLine("Try to restart the Alpha.Beta thread");
                Console.ReadLine();

                try
                {
                    oThread.Start();
                }

                catch (ThreadStateException)
                {
                    Console.WriteLine();
                    Console.Write("ThreadStateException trying to restart Alpha.Beta. ");
                    Console.WriteLine();
                    Console.WriteLine("Expected since aborted threads cannot be restarted.");
                    Console.ReadLine();
                }
                return 0;
            }
            else
            { return 0; }
        }     
    }

    public class Alpha
    {
        // This method that will be called when the thread is started
        public void Beta()
        {
            int c = 0;
            while (true)
            {
                Console.WriteLine("Alpha.Beta Function is running in its own thread. The counnt value is {0} the time is {1}", c, DateTime.Now);
                c++;
            }
        }
    };
}