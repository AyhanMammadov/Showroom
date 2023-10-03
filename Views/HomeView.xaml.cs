using System;
using System.Collections.Generic;
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

namespace Showroom.Views
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }


        private void OnMouseEnter(object sender, MouseEventArgs e)
        {
            this.imageControl.Source = new BitmapImage(new Uri("https://performance-center.az/frontend/web/uploads//images/X7png.png", UriKind.RelativeOrAbsolute));
        }

        private void OnMouseLeave(object sender, MouseEventArgs e)
        {
            this.imageControl.Source = new BitmapImage(new Uri("https://static.vecteezy.com/system/resources/previews/012/006/391/non_2x/old-style-classic-car-png.png", UriKind.RelativeOrAbsolute));
        }
    }
}
