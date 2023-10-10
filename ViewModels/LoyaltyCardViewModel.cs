using Showroom.Commands.Base;
using Showroom.Models;
using Showroom.Repositories.EFCoreRepository.DbContext;
using Showroom.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Showroom.ViewModels;
public class LoyaltyCardViewModel : ViewModelBase
{

    #region fullProperties
    private string nameValue;

    public string NameValue
    {
        get => this.nameValue;
        set
        {
            this.nameValue = value;
            base.PropertyChangeMethod(out nameValue , value);
        }
    }

    private string emailValue;

    public string EmailValue
    {
        get => this.emailValue;
        set
        {
            this.emailValue = value;
            base.PropertyChangeMethod(out emailValue, value);
        }
    }


    private string phoneNumber;

    public string PhoneNumber
    {
        get => this.phoneNumber;
        set
        {
            this.phoneNumber = value;
            base.PropertyChangeMethod(out phoneNumber, value);
        }
    }


    private Visibility incorrectInput;
    public Visibility IncorrectInput
    {
        get => incorrectInput;

        set
        {
            incorrectInput = value;
            base.PropertyChangeMethod(out incorrectInput, value);
        }
    }
    #endregion

    

    public LoyaltyCardViewModel()
    {
        IncorrectInput = Visibility.Hidden;
    }


    #region Commands
    private CommandBase applyCommand;

    public CommandBase ApplyCommand => applyCommand ??= new CommandBase(
        execute: () =>
        {
            if (!this.CheckInput())
            {
                IncorrectInput = Visibility.Visible;
                return;
            }
            IncorrectInput = Visibility.Hidden;
            var context = new MyEFRepository();
            var user = new UserLoyalCards()
            {
                Name = this.NameValue,
                Email = this.EmailValue,
                PhoneNumber = this.PhoneNumber,
            };

            context.Add(user);
            context.SaveChanges();
            MessageBox.Show($"{this.NameValue} added succesfully", "Success!", MessageBoxButton.OK , MessageBoxImage.Information);

        },
        canExecute: () => true);
    #endregion


    #region Methonds
    private bool CheckInput()
    {
        if (string.IsNullOrWhiteSpace(this.NameValue) || string.IsNullOrWhiteSpace(this.PhoneNumber) || string.IsNullOrWhiteSpace(this.EmailValue))
            return false;

        if (this.NameValue.Length < 3)
            return false;

        if (this.phoneNumber.Length < 10)
            return false;

        if (!this.EmailValue.Contains('@') || !this.EmailValue.Contains('.'))
            return false;

        return true;
    }

    #endregion



}

