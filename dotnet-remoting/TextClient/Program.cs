using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels;

using System.Diagnostics;


namespace TextClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //string ConfigFile = Process.GetCurrentProcess().MainModule.FileName + ".config";
            //Console.WriteLine("Using config: " + ConfigFile);
            try
            {
                //RemotingConfiguration.Configure(ConfigFile, false);
                var ch = new HttpChannel();
                ChannelServices.RegisterChannel(ch, false);
            }
            catch (Exception ec)
            { MessageBox.Show(ec.GetBaseException().ToString()); }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
