


using System;
using System.Windows;
using System.Windows.Threading;

namespace ElevatorControl
{
    public partial class MainWindow : Window
    {
        DispatcherTimer DTUpdate = new DispatcherTimer(); // Call method async repeatly
        Elevator.Controller ECMain = new Elevator.Controller();

        public MainWindow()
        {
            InitializeComponent();
            try
            {
                btnSend.Click += btnSend_Click;
                btnWarn.Click += btnWarn_Click;

                for (int i = 0; i < 5; ++i)
                    ECMain.Add(new Elevator.Elevator(20));

                DTUpdate.Tick += Update;
                //DTUpdate.Interval = new TimeSpan(1);
                //DTUpdate.Interval = new TimeSpan(0, 0, 1);
                DTUpdate.Interval = new TimeSpan(0, 0, 0, 0, 200);
                DTUpdate.Start();
            }
            catch (Exception ec) { tbStatus.Text = ec.ToString(); }

        }

        void Update(object sender, EventArgs e) // Async method
        {
            try
            {
                ECMain.Update();
                var status = ECMain.GetStatus();
                pbElevator1.Value = status[0];
                pbElevator2.Value = status[1];
                pbElevator3.Value = status[2];
                pbElevator4.Value = status[3];
                pbElevator5.Value = status[4];

                tbStatus.Text = ECMain.ToString();
            }
            catch (Exception ec) { tbStatus.Text = ec.ToString(); }
        }

        void btnWarn_Click(object sender, RoutedEventArgs e)
        {
            try { ECMain.SetError(int.Parse(tbWarn.Text) - 1); }
            catch (Exception ec) { tbStatus.Text = ec.ToString(); }
        }

        void btnSend_Click(object sender, RoutedEventArgs e)
        {
            try { ECMain.SetWish(int.Parse(tbSource.Text) - 1, int.Parse(tbTarget.Text) - 1); }
            catch (Exception ec) { tbStatus.Text = ec.ToString(); }
        }
    }
}
