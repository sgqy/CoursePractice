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
using ITextLib;

namespace TextClient
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonConvert_Click(object sender, EventArgs e)
        {
            new Thread(ToDo).Start();
        }

        void ToDo()
        {
            try
            {
                IRemoteText itr = (IRemoteText)Activator.GetObject(typeof(IRemoteText), "http://127.0.0.1:30000/TextLibSvc");
                var bytes = itr.Unicode2GBK(textBoxUnicode.Text);
                var str = string.Concat(bytes.Select(x => string.Format("{0:X2} ", x)));
                Invoke(new Action(() => { textBoxGBKValue.Text = str; }));
            }
            catch (Exception ec) { MessageBox.Show(ec.GetBaseException().ToString()); }            
        }
    }
}
