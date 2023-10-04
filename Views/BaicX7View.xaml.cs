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
public partial class BaicX7View : UserControl , INotifyPropertyChanged
{
    #region Fields
    public string CarDetails { get; set; }

    private ObservableCollection<string> imageUrls;

    private int currentIndex = 0;

    public event PropertyChangedEventHandler? PropertyChanged;
    public string CurrentImage => imageUrls[this.currentIndex];

    #endregion
    public BaicX7View()
    {
        InitializeComponent();
        this.DataContext = this;
        this.DisplayModelInfo("ModelX7");
        this.AddPhotos();
    }

    #region Methods
    private void AddPhotos()
    {
        imageUrls = new ObservableCollection<string>
            {
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F01%2F46%2F2ccea334-46fd-4323-ab3b-ee2223fa7b95%2F98702_63DrMm0KmbU0uPNiQRApTg.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F01%2F47%2F7e0baf4c-9986-449c-afe3-e18b0d43db20%2F87648_k_PCmR2qJ4yBpdUYjWHNyA.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F01%2F50%2F0a5636f8-6213-4041-93b0-1aa40d33f0c1%2F87612_4k6Fl8DwBNR_9imLoXgeOg.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F01%2F45%2F3f4712ca-bd80-4d4b-8151-f36b516ec600%2F87645_ljyVMczTR8hlzT8yJvTF6A.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F01%2F45%2F508c472c-8268-440f-bd0d-f0ee3d5f1cf8%2F87633_niJazL93hL4bRnXyfvbJ5w.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F01%2F46%2F60b845bf-ad16-484a-b133-14e1b37bb654%2F88507_2oJIdUhRsTfJfpBoT1qWTA.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F01%2F45%2Fe33c8237-dced-4898-b6ad-289d599cba0f%2F98690_f-qyC_ep3ihT8JhGHdJ3ZQ.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F10%2F22%2F12%2F01%2F44%2F67a82199-2fba-4b4b-8441-70534c7adfbd%2F88516_8HOQa0JRlZDgImPaLJPsag.jpg",

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
