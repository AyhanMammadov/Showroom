using Showroom.Commands.Base;
using Showroom.Models;
using Showroom.Repositories.EFCoreRepository.DbContext;
using Showroom.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Showroom.ViewModels;
public class TestDriveViewModel : ViewModelBase , INotifyPropertyChanged
{
    #region Fields
    private readonly MyEFRepository context;
    public ObservableCollection<CarsName> CarsNames { get; set; } = new ObservableCollection<CarsName>();

    public event PropertyChangedEventHandler? PropertyChanged;


    private string name;

    public string Name
    {
        get => this.name;
        set
        {
            this.name = value;
            OnPropertyChanged("Name");
        }
    }

    private string surname;

    public string Surname
    {
        get => this.surname;
        set
        {
            this.surname = value;
            OnPropertyChanged("Surname");
        }
    }

    private string email;

    public string Email
    {
        get => this.email;
        set
        {
            this.email = value;
            OnPropertyChanged("Email");
        }
    }


    private string phone;

    public string Phone
    {
        get => this.phone;
        set
        {
            this.phone = value;
            OnPropertyChanged("Phone");
        }
    }

    private string notes;

    public string Notes
    {
        get => this.notes;
        set
        {
            this.notes = value;
            OnPropertyChanged("Notes");
        }
    }

    private CarsName? selectedCarName;
    public CarsName? SelectedCarName
    {
        get { return selectedCarName; }
        set { base.PropertyChangeMethod(out selectedCarName, value); }
    }


    #endregion

    public TestDriveViewModel()
    {
        this.context = new MyEFRepository();
        
        this.RefreshCarNames();
    }

    #region Methods
    private void RefreshCarNames()
    {
        this.CarsNames.Clear();

        foreach (var item in this.context.Cars)
        {
            CarsNames.Add(item);
        }
    }

    private void OnPropertyChanged([CallerMemberName] string propName = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }

    private bool CheckInput()
    {
        if (string.IsNullOrWhiteSpace(this.Name) || string.IsNullOrWhiteSpace(this.Phone))
            return false;

        if (this.Name.Length < 3)
            return false;

        if (this.Phone.Length < 10)
            return false;

        return true;
    }
    #endregion


    #region Commands
    private CommandBase applyCommand;

    public CommandBase ApplyCommand => applyCommand ??= new CommandBase(
        execute: () =>
        {
            if (!this.CheckInput())
            {
                return;
            }
            var context = new MyEFRepository();
            var user = new TestDriveUsers()
            {
                Name = this.Name,
                Phone = this.Phone,
                Surname = this.Surname,
                Email = this.Email,
                Notes = this.Notes,
                CarsId = this.selectedCarName?.Id
            };

            context.Add(user);
            context.SaveChanges();

            MessageBox.Show($"{this.Name} added succesfully", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
        },
        canExecute: () => true);
    #endregion


}

