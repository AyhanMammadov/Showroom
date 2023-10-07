﻿using Showroom.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.IO;
using Showroom.Repositories.Base;
using Showroom.Repositories;
using Showroom.Commands.Base;
using System.Windows.Input;

namespace Showroom.ViewModels;
public class BaicX55ViewModel : ViewModelBase, INotifyPropertyChanged
{
    #region Fields
    public string CarDetails { get; set; }

    private ObservableCollection<string> imageUrls;

    private int currentIndex = 0;

    public event PropertyChangedEventHandler? PropertyChanged;
    public string CurrentImage => imageUrls[this.currentIndex];

    #endregion

    public BaicX55ViewModel()
    {
        imageUrls = new ObservableCollection<string>();
        this.DisplayModelInfo("ModelX55");
        this.AddPhotos();
    }

    #region Methods
    private void AddPhotos()
    {
        ICarPhotosRepository carPhotos = new CarDapperPhotosRepository();
        var result = carPhotos.getAllPhotosUrl("BaicX55");

        foreach (var photo in result)
        {
            this.imageUrls.Add(photo);
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


    #region Commands
    private CommandBase nextButtonCommand;

    public CommandBase NextButtonCommand => this.nextButtonCommand ??= new CommandBase(
        execute: () =>
        {
            if (this.currentIndex < this.imageUrls.Count - 1)
                currentIndex++;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentImage)));
        },
        canExecute: () => true);


    private CommandBase previewButtonCommand;

    public CommandBase PreviewButtonCommand => this.previewButtonCommand ??= new CommandBase(
        execute: () =>
        {
            if (this.currentIndex > 0)
                currentIndex--;
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(CurrentImage)));
        },
        canExecute: () => true);
    #endregion

}

