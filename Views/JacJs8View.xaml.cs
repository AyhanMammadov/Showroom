using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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

namespace Showroom.Views;
public partial class JacJs8View : UserControl , INotifyPropertyChanged
{
    #region Fields
    public string CarDetails { get; set; }

    private ObservableCollection<string> imageUrls;

    private int currentIndex = 0;

    public event PropertyChangedEventHandler? PropertyChanged;
    public string CurrentImage => imageUrls[this.currentIndex];

    #endregion
    public JacJs8View()
    {
        InitializeComponent();
        this.DataContext = this;
        this.DisplayModelInfo("ModelJS8");
        this.AddPhotos();
    }
    #region Methods
    private void AddPhotos()
    {
        imageUrls = new ObservableCollection<string>
            {
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F13%2F11%2F12%2F12%2F2aebc425-022a-40f9-aaec-f8f6e4f215ea%2F49785_cm6zN7-KWJhm2uF2aQicXw.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F13%2F11%2F12%2F35%2F78705c02-b2c5-4a50-bac3-7b8e7c221370%2F49795_UQTQfC8YgZNFEXCrjrnhEg.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F13%2F11%2F12%2F36%2Fb5771555-1030-459c-abe4-f208d298359d%2F49777_Fzh5cC7zmVcjlu_b5Jo8uA.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F13%2F11%2F12%2F37%2F3136cc54-5a8f-4a32-aed9-a5ef5faf29b8%2F49799_xz28fX8EaoCkeHKTObTN8g.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F13%2F11%2F12%2F12%2Ffc94702f-35f3-4caf-9d9b-7ef21278834b%2F80555_tfx38JRRjnp3YAJJSo2hig.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F13%2F11%2F15%2F20%2Fc2182630-abb6-45cd-9eb3-2e46352df13f%2F49777_OczPgYUUArQCPAhMw8A2gg.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F13%2F11%2F16%2F38%2F101c66f5-e144-4d1b-b69c-4fef43e8c8c1%2F2007_okG1UeC759dxpIkdMuyEvQ.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F13%2F11%2F12%2F37%2Ff30d8cbb-fc68-4a0f-a054-9e0fdb8313af%2F49813_QJ5JAgyi25WfFILjgbQJWA.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F13%2F11%2F12%2F35%2F3098f14b-d207-41a4-9984-6154291e1d33%2F80550_UXu2Vkjr1ignCReOAsx8Vw.jpg",

            };
    }

    private void ImageButtonClicked(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            if (button.Content.ToString() == "←")
            {
                if (currentIndex > 0)
                    currentIndex--;
            }
            if (button.Content.ToString() == "→")
            {
                if (currentIndex < imageUrls.Count - 1)
                    currentIndex++;
            }
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentImage)));
        }


    }
    private void DisplayModelInfo(string modelName)
    {
        try
        {
            string filePath = "Assets/carsInfo.txt";
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                string modelInfo = "";
                bool isReading = false;

                foreach (string line in lines)
                {
                    if (line.StartsWith(modelName))
                    {
                        isReading = true;
                        continue;
                    }
                    else if (isReading && !string.IsNullOrWhiteSpace(line))
                        modelInfo += line + Environment.NewLine;
                    else if (isReading && string.IsNullOrWhiteSpace(line))
                        break;
                }
                this.CarDetails = modelInfo;
            }
            else
            {
                this.CarDetails = "Cant find the path";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Error: " + ex.Message);
        }
    }
    #endregion
}

