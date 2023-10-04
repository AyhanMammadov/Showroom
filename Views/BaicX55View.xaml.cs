using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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

    public partial class BaicX55View : UserControl , INotifyPropertyChanged
    {
        public string CarDetails { get; set; }

        private ObservableCollection<string> imageUrls;

        private int currentIndex = 0;

        public event PropertyChangedEventHandler? PropertyChanged;
        public string CurrentImage => imageUrls[this.currentIndex];

        public BaicX55View()
        {
            InitializeComponent();
            this.imageUrls = new ObservableCollection<string>();
            this.DataContext = this;
            CarDetails = File.ReadAllText("Assets/baicX55.txt");
            this.AddPhotos();
        }

        private void PropertyChangeMethod<T>(out T field, T value, [CallerMemberName] string propName = "")
        {
            field = value;

            if (this.PropertyChanged != null)
            {
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
            }
        }
        private void AddPhotos()
        {
            this.imageUrls.Add("https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F10%2F11%2F3960bbf6-05cc-4491-97b3-e78bad92d66b%2F910_2a4pSfzDRtwWRPWeb3dnaw.jpg");
            this.imageUrls.Add("https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F11%2F10%2Fb354061b-58ac-46f8-892b-82edf00dbbbc%2F9734_Nz0nF3hpVMHeZo-vwx5YZg.jpg");
            this.imageUrls.Add("https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F12%2F34%2F49eaa551-0a6e-4e85-b1a8-8e84e993dda2%2F912_gu3FRS-N0nbjmjZiXH3C8A.jpg");
            this.imageUrls.Add("https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F12%2F59%2Fd954106f-aa5f-417d-8d2d-8cc14875bbcc%2F9739_DGI24tOlIAIy5gYB3h4hUw.jpg");
            this.imageUrls.Add("https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F12%2F59%2F4c6e3721-b69d-4d2c-ad95-d1efb5e8dc89%2F89928_S6WCVqHy_J_lwyiPLah58g.jpg");
        }

        private void PreviousImage(object sender, RoutedEventArgs e)
        {
            if (currentIndex > 0)
            {
                currentIndex--;
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentImage)));
            }

        }

        private void NextImage(object sender, RoutedEventArgs e)
        {
            if (currentIndex < imageUrls.Count - 1)
            {
                currentIndex++;
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentImage)));
            }

        }
    }
}
