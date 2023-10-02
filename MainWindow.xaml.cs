using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Showroom
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();


            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Обновление каждую секунду
            timer.Tick += TimerTick;
            timer.Start();
        }


        private void TimerTick(object sender, EventArgs e)
        {
            DateTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DayOfWeekTextBlock.Text = DateTime.Now.ToString("dddd" , new CultureInfo("en-US"));
            TimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}
