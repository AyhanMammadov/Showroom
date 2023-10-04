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

public partial class JacT8View : UserControl , INotifyPropertyChanged
{
    #region Fields
    public string CarDetails { get; set; }

    private ObservableCollection<string> imageUrls;

    private int currentIndex = 0;

    public event PropertyChangedEventHandler? PropertyChanged;
    public string CurrentImage => imageUrls[this.currentIndex];

    #endregion
    public JacT8View()
    {
        InitializeComponent();
        this.DataContext = this;
        this.DisplayModelInfo("ModelT8");
        this.AddPhotos();
    }

    #region Methods
    private void AddPhotos()
    {
        imageUrls = new ObservableCollection<string>
            {
                "https://turbo.azstatic.com/uploads/full/2022%2F03%2F15%2F15%2F37%2F29%2F2429b042-fdeb-4bd6-b15c-4243d7e3c6d3%2F58618_GK-D_o1zXx3RxuDnrZ3yoA.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F03%2F15%2F15%2F37%2F26%2Fe34b5f7b-be93-4740-ae66-1e2694bb9e14%2F19398_JvnSaaRtR5mavSW5i_0FRQ.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F03%2F15%2F15%2F37%2F26%2Feec0f1cc-e4f4-4781-929b-963dc0ba5be1%2F70380_hVWDTiSooFKHKKAFeIOlvA.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F03%2F15%2F15%2F37%2F27%2F5108cec4-2bc5-42a7-a2db-d58855d977e4%2F70361_OvkKuAWML1Kjv8Bj5zGJCg.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F03%2F15%2F15%2F37%2F26%2F561a9c24-3a1a-4068-9b3a-0a4939cb9638%2F19400_dF_k80T6TKG3wcAcubKFeg.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F03%2F15%2F15%2F37%2F26%2Fdd1f497e-be0e-47f3-9df9-470e296a674f%2F19388_HYQ1Rw_sANMz9l6HyFjiKw.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F03%2F15%2F15%2F37%2F25%2F660870e5-2348-4868-a634-a87368785cfe%2F70358_ywbg11pCptNGpNyzQrMHig.jpg",
                "https://turbo.azstatic.com/uploads/full/2022%2F03%2F15%2F15%2F37%2F25%2Ff92db850-baac-4569-83a3-ab211312b418%2F58618_9LNAYtiEzpERCENLqQCqPg.jpg",

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

