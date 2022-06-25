using BatteryBuddy.Utils;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace BatteryBuddy
{
    class TrayIcon
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool DestroyIcon(IntPtr handle);

        private Bitmap bitmap;
        private string batteryPercentage;
        private NotifyIcon notifyIcon;

        public TrayIcon()
        {
            ContextMenu contextMenu = new ContextMenu();
            MenuItem menuItem = new MenuItem();

            notifyIcon = new NotifyIcon();

            contextMenu.MenuItems.AddRange(new MenuItem[] { menuItem });

            menuItem.Index = 0;
            menuItem.Text = "退出";
            menuItem.Click += new EventHandler(MenuItem_Click);

            notifyIcon.ContextMenu = contextMenu;

            batteryPercentage = "?";

            notifyIcon.Visible = true;

            Timer timer = new Timer();
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Interval = 1000;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            PowerStatus powerStatus = SystemInformation.PowerStatus;
            batteryPercentage = (powerStatus.BatteryLifePercent * 100).ToString();

            bool high = SystemInformation.PowerStatus.BatteryChargeStatus.HasFlag(BatteryChargeStatus.High);
            bool low = SystemInformation.PowerStatus.BatteryChargeStatus.HasFlag(BatteryChargeStatus.Low);
            bool critical = SystemInformation.PowerStatus.BatteryChargeStatus.HasFlag(BatteryChargeStatus.Critical);

            bool charging = SystemInformation.PowerStatus.BatteryChargeStatus.HasFlag(BatteryChargeStatus.Charging);
            bool pluged_in = SystemInformation.PowerStatus.PowerLineStatus.HasFlag(PowerLineStatus.Online);

            bool light = UIUtils.IsLightTheme();

            bitmap = BitmapUtils.GetBitmap(high, low, critical, pluged_in, charging, light);

            IntPtr intPtr = bitmap.GetHicon();
            try
            {
                using(Icon icon=Icon.FromHandle(intPtr))
                {
                    notifyIcon.Icon = icon;
                    notifyIcon.Text = "剩余" + batteryPercentage + "%";
                    if (!pluged_in)
                    {
                        int seconds = SystemInformation.PowerStatus.BatteryLifeRemaining;
                        if (seconds > 0)
                        {
                            int mins = seconds / 60;
                            notifyIcon.Text += "\n还能用" + " " + (mins / 60) + ":" + (mins % 60);
                        }
                    }
                    else
                    {
                        notifyIcon.Text += "\n已连接电源";
                    }
                }
            }
            finally
            {
                DestroyIcon(intPtr);
            }
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = false;
            notifyIcon.Dispose();
            Application.Exit();
        }
    }
}
