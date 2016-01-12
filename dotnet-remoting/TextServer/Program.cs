using System;
using System.Diagnostics;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;

namespace TextServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //string ConfigFile = Process.GetCurrentProcess().MainModule.FileName + ".config";
            //Console.WriteLine("Using config: " + ConfigFile);
            //RemotingConfiguration.Configure(ConfigFile, false);

            var ch = new HttpChannel(30000);
            ChannelServices.RegisterChannel(ch, false);

            RemotingConfiguration.RegisterWellKnownServiceType(
                typeof(TextLib.Converter), "TextLibSvc", WellKnownObjectMode.Singleton
                );

            string cmd = "";
            while(true)
            {
                cmd = Console.ReadLine();
                switch(cmd)
                {
                    case "q":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
