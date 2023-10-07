using Showroom.ViewModels;
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
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            var viewModel = new MainViewModel();
            viewModel.ActiveViewModel = new HomeViewModel();
            this.DataContext = viewModel;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(100);
            timer.Tick += TimerTick;
            timer.Start();
        }
        private void TimerTick(object sender, EventArgs e)
        {
            DateTextBlock.Text = DateTime.Now.ToString("dd/MM/yyyy");
            DayOfWeekTextBlock.Text = DateTime.Now.ToString("dddd" , new CultureInfo("en-US"));
            TimeTextBlock.Text = DateTime.Now.ToString("HH:mm:ss");
        }
        
        private void SubscribeClicked(object sender, RoutedEventArgs e)
        {
            string wrongEmail = "Wrong email template";
            if (string.IsNullOrWhiteSpace(this.emailAdress.Text) || !this.emailAdress.Text.Contains("@") || !this.emailAdress.Text.Contains("."))
            {
                this.emailtextbox.Text = wrongEmail;
                this.emailtextbox.Visibility = Visibility.Visible;
                return;
            }
            
            this.emailtextbox.Text = $"{this.emailAdress.Text} email adres subscribed succesfully!";
            this.emailtextbox.Visibility = Visibility.Visible;
            this.emailAdress.Clear();
            return;
            
        }
        private void themeClicked(object sender, RoutedEventArgs e)
        {
            if (this.mainGrid.Background is SolidColorBrush brush)
            {
                if (brush.Color == Colors.Black)
                    this.mainGrid.Background = new SolidColorBrush(Colors.CadetBlue);
                else if (brush.Color == Colors.CadetBlue)
                    this.mainGrid.Background = new SolidColorBrush(Colors.Black);
            }
        }
    }

}
