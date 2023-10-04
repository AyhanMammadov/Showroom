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

namespace Showroom.Views;

public partial class BaicX55View : UserControl, INotifyPropertyChanged
{
    #region Fields
    public string CarDetails { get; set; }

    private ObservableCollection<string> imageUrls;

    private int currentIndex = 0;

    public event PropertyChangedEventHandler? PropertyChanged;
    public string CurrentImage => imageUrls[this.currentIndex];

    #endregion

    public BaicX55View()
    {
        InitializeComponent();
        this.DataContext = this;
        this.DisplayModelInfo("ModelX55");
        this.AddPhotos();
    }
    #region Methods
    private void AddPhotos()
    {
        imageUrls = new ObservableCollection<string>
            {
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F10%2F11%2F3960bbf6-05cc-4491-97b3-e78bad92d66b%2F910_2a4pSfzDRtwWRPWeb3dnaw.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F11%2F10%2F97615167-c7bb-4a0f-b54d-740cd8fbb2fb%2F9732_Vq2Y0w8druOEOA_9QvEw2A.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F11%2F10%2Fb354061b-58ac-46f8-892b-82edf00dbbbc%2F9734_Nz0nF3hpVMHeZo-vwx5YZg.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F12%2F34%2F49eaa551-0a6e-4e85-b1a8-8e84e993dda2%2F912_gu3FRS-N0nbjmjZiXH3C8A.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F16%2F40%2Fd0fb7f97-2f9f-4ea3-96c5-9f5d3a036ae4%2F923_xEnXp2_41ALfmrP-PqWBDA.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F12%2F59%2Fd954106f-aa5f-417d-8d2d-8cc14875bbcc%2F9739_DGI24tOlIAIy5gYB3h4hUw.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F12%2F59%2F2c5766b2-a5ef-4a7e-ba6d-a6f692e2f311%2F86142_l125IiqV_HpcL-McM5LCaw.jpg",
                "https://turbo.azstatic.com/uploads/full/2023%2F02%2F02%2F15%2F12%2F59%2F4c6e3721-b69d-4d2c-ad95-d1efb5e8dc89%2F89928_S6WCVqHy_J_lwyiPLah58g.jpg",

            };
    }
    private void PreviousImage(object sender, RoutedEventArgs e)
    {
        if (currentIndex > 0)
        {
            currentIndex--;
            this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentImage)));
        }

    }
    private void ImageButtonClicked(object sender, RoutedEventArgs e)
    {
        if (sender is Button button)
        {
            if(button.Content.ToString() == "←")
            {
                if (currentIndex > 0)
                    currentIndex--;
            }
            if(button.Content.ToString() == "→")
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
