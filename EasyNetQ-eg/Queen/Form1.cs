using EasyNetQ;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Queen
{
    public partial class Form1 : Form
    {
        IBus bus = null;

        public Form1()
        {
            InitializeComponent();
            comboReader.SelectedIndex = 0;
            bus = RabbitHutch.CreateBus("host=127.0.0.1");
        }

        Queue<Rescript.Message> mq = new Queue<Rescript.Message>();

        void generate()
        {
            var rd = new Random(DateTime.Now.Millisecond);

            for (int i = 0; i < numctrlTotal.Value; ++i)
            { mq.Enqueue(new Rescript.Message(i, rd.Next() + "-" + rd.Next())); }
        }

        void send()
        {
            // wait for full queue
            for (int i = 0; i < 10 && mq.Count == 0; ++i)
            { Thread.Sleep(500); }

            // exit when empty for 5s
            if (mq.Count == 0) return;

            var rd = new Random(DateTime.Now.Millisecond);
            var readers = comboReader.Items;
            string custom = "default";
            Invoke(new Action(() => custom = comboReader.Text));

            try
            {
                while (true)
                {
                    var box = mq.Dequeue(); // when empty, throw and exit
                    string reader =
                        checkRandom.Checked
                        ? readers[rd.Next(0, readers.Count)].ToString()
                        : custom;
                    //MessageBox.Show(reader);
                    try { bus.Send(reader, box); } catch { } // ignore

                    //Invoke(new Action(() => ++progressBar1.Value));
                }
            }
            catch { }
        }

        void update()
        {
            while (true)
            {
                Invoke(new Action(() => 
                {
                    int val = progressBar1.Maximum - mq.Count;
                    if (val < 0) val = 0;
                    progressBar1.Value = val;
                }));
                Thread.Sleep(100);
            }
        }

        private void buttonPublish_Click(object sender, EventArgs e)
        {
            mq.Clear();
            progressBar1.Value = 0;
            progressBar1.Maximum = (int)numctrlTotal.Value;

            new Thread(() => generate()).Start();
            new Thread(() => update()).Start();

            for (int i = 0; i < 200; ++i)
            { new Thread(() => send()).Start(); }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0); // force exit (thread hangs when using EasyNetQ = =)
        }
    }
}
