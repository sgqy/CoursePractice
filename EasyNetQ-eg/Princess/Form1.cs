using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using EasyNetQ;

namespace Princess
{
    public partial class Form1 : Form
    {
        IBus bus = null;
        public Form1()
        {
            InitializeComponent();
            bus = RabbitHutch.CreateBus("host=127.0.0.1");
            listMessage.Items.Clear();
        }

        Queue<Rescript.Message> mq = new Queue<Rescript.Message>();

        void reciever()
        {
            try
            {
                string reader = "default";
                Invoke(new Action(() => reader = comboReader.Text));

                while (true)
                {
                    var last = mq.Count;
                    try { bus.Receive<Rescript.Message>(reader, msg => { mq.Enqueue(msg); }); } catch { }
                    if (last == mq.Count) Thread.Sleep(2000); // suspend if there is no message
                }
            }
            catch { }
        }

        void updater()
        {
            try
            {
                while (true)
                {
                    updateOnce();
                    Thread.Sleep(1000);
                }
            }
            catch (ThreadAbortException) { }
            catch { MessageBox.Show("update loop fail"); }
        }

        private void updateOnce()
        {
            Invoke(new Action(() => labelCount.Text = string.Format("{0:N0}", mq.Count)));
            var mqArr = mq.ToArray();
            var items = new List<ListViewItem>();
            for(int i = mqArr.Length > 20 ? mqArr.Length - 20 : 0; i < mqArr.Length; ++i)
            {
                var lvt = new ListViewItem();
                lvt.Text = mqArr[i].order + "";
                lvt.SubItems.Add(mqArr[i].content);
                items.Add(lvt);
                //Invoke(new Action(() => listMessage.Items.Add(lvt)));
            }
            Invoke(new Action(() => listMessage.Items.Clear()));
            Invoke(new Action(() => listMessage.Items.AddRange(items.ToArray())));
            //Invoke(new Action(() => { try { listMessage.Items[listMessage.Items.Count - 1].EnsureVisible(); } catch { } }));
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        Thread thRecieve = null;
        Thread thUpdate = null;

        private void buttonStart_Click(object sender, EventArgs e)
        {
            mq.Clear();

            buttonStart.Enabled = false;
            buttonStop.Enabled = true;
            comboReader.Enabled = false;

            thRecieve = new Thread(reciever);
            thUpdate = new Thread(updater);

            thUpdate.Priority = ThreadPriority.Lowest;
            thRecieve.Priority = ThreadPriority.Lowest;

            thUpdate.Start();
            thRecieve.Start();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            buttonStart.Enabled = true;
            buttonStop.Enabled = false;
            comboReader.Enabled = true;

            thRecieve.Abort();
            thUpdate.Abort();

            thRecieve = null;
            thUpdate = null;

            updateOnce();
        }
    }
}
