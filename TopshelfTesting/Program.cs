using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Topshelf;

namespace TopshelfTesting
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(
            x =>
            {
                x.Service<TownCrier>(
                    s =>
                    {
                        s.ConstructUsing(name => new TownCrier());
                        s.WhenStarted(tc => tc.Start());
                        s.WhenStopped(tc => tc.Stop());
                    });
                x.RunAsLocalSystem();
                x.SetDescription("TopshelfInstaller");
                x.SetDisplayName("TopshelfInstaller");
                x.SetServiceName("TopshelfInstaller");
            });
        }
    }

    public class TownCrier
    {
        private readonly Timer _timer;

        public TownCrier()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => Console.WriteLine("It is {0} an all is well", DateTime.Now);
        }

        public void Start()
        {
            _timer.Start();
        }

        public void Stop()
        {
            _timer.Stop();
        }
    }
}
