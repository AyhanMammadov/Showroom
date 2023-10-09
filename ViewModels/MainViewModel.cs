using Showroom.Commands.Base;
using Showroom.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.ViewModels;
public class MainViewModel : ViewModelBase
{
    private ViewModelBase activeViewModel;

    public ViewModelBase ActiveViewModel
    {
        get => activeViewModel;
        set => base.PropertyChangeMethod(out activeViewModel, value);
    }

    #region Commands
    private CommandBase baicX55Command;

    public CommandBase BaicX55Command => this.baicX55Command ??= new CommandBase(
        execute: () => ActiveViewModel = App.container.GetInstance<BaicX55ViewModel>(),
        canExecute: () => true);


    private CommandBase baicX7Command;

    public CommandBase BaicX7Command => this.baicX7Command ??= new CommandBase(
        execute: () => ActiveViewModel = App.container.GetInstance<BaicX7ViewModel>(),
        canExecute: () => true);


    private CommandBase baicX3Command;

    public CommandBase BaicX3Command => this.baicX3Command ??= new CommandBase(
        execute: () => ActiveViewModel = App.container.GetInstance<BaicX3ViewModel>(),
        canExecute: () => true);


    private CommandBase jacJS8Command;

    public CommandBase JacJS8Command => this.jacJS8Command ??= new CommandBase(
        execute: () => ActiveViewModel = App.container.GetInstance<JacJs8ViewModel>(),
        canExecute: () => true);


    private CommandBase jacT8Command;

    public CommandBase JacT8Command => this.jacT8Command ??= new CommandBase(
        execute: () => ActiveViewModel = App.container.GetInstance<JACT8ViewModel>(),
        canExecute: () => true);


    private CommandBase loyaltyCommand;

    public CommandBase LoyaltyCommand => this.loyaltyCommand ??= new CommandBase(
        execute: () => ActiveViewModel = new LoyaltyCardViewModel(),
        canExecute: () => true);

    private CommandBase aboutUsCommand;

    public CommandBase AboutUsCommand => this.aboutUsCommand ??= new CommandBase(
        execute: () => ActiveViewModel = new AboutUsViewModel(),
        canExecute: () => true);


    private CommandBase testDriveCommand;

    public CommandBase TestDriveCommand => this.testDriveCommand ??= new CommandBase(
        execute: () => ActiveViewModel = new TestDriveViewModel(),
        canExecute: () => true);
    #endregion








}

