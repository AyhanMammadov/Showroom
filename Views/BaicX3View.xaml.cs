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
   
public partial class BaicX3View : UserControl , INotifyPropertyChanged
{
    #region Fields
    public string CarDetails { get; set; }

    private ObservableCollection<string> imageUrls;

    private int currentIndex = 0;

    public event PropertyChangedEventHandler? PropertyChanged;
    public string CurrentImage => imageUrls[this.currentIndex];

    #endregion
    public BaicX3View()
    {
        InitializeComponent();
        this.DataContext = this;
        this.DisplayModelInfo("ModelX3");
        this.AddPhotos();
    }
    #region Methods
    private void AddPhotos()
    {
        imageUrls = new ObservableCollection<string>
            {
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F39%2F49%2Fa882ee44-2ac8-404e-aecf-bf75e7d060d4%2F88499_pzieTJJ9wwsV1P83GPjvEg.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F39%2F46%2F5c894707-3ef5-4203-9b10-2b1fe9c2524c%2F98694_oW_TH4W5fauDKEMVhoOq7w.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F39%2F49%2Fbdaea04a-c982-46de-b033-ab811e9d376c%2F98694_mByhQPdf0Yd_lP5Miypxtg.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F39%2F48%2Fb8618e60-6815-4cb2-ae7c-638b16e3927b%2F48613_BBEgn7PQaRLxSTGJhgH47g.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F39%2F48%2Fd3c0cf2a-cb93-449a-b50f-b4e46c99caac%2F98679_yeX0quJPg0cNNTM2ZNge7Q.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F39%2F49%2F3ab7b781-6ace-4051-a641-dcf47c5302cb%2F98703_y0swSWkSkH6uujJS4HtrRA.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F39%2F47%2F8a94076e-9171-44fc-9c43-f5a9cacfaea2%2F98709_qz-9242D-4FqhSM48FZUWw.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F39%2F46%2Ff6d385b1-f906-4f8e-a3d9-f4fe915306e1%2F87613_r7s0UGV7s1pBIlw028Y46A.jpg",

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

