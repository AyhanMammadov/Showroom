using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Showroom.Commands.Base;
public class CommandBase : ICommand
{
    private readonly Action execute;

    private readonly Func<bool> canExecute;

    public event EventHandler? CanExecuteChanged;

    public CommandBase(Action execute, Func<bool> canExecute)
    {
        this.execute = execute;
        this.canExecute = canExecute;
    }

    public bool CanExecute(object? parameter) => this.canExecute.Invoke();

    public void Execute(object? parameter) => this.execute.Invoke();
}

