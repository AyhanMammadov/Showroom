using Showroom.Models;
using Showroom.Repositories.EFCoreRepository.DbContext;
using Showroom.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.ViewModels;
public class TestDriveViewModel : ViewModelBase
{
    private readonly MyEFRepository context;
    public ObservableCollection<CarsName> CarsNames { get; set; } = new ObservableCollection<CarsName>();
    public TestDriveViewModel()
    {
        this.context = new MyEFRepository();
        
        this.RefreshCarNames();
    }
    private void RefreshCarNames()
    {
        this.CarsNames.Clear();

        foreach (var item in this.context.Cars)
        {
            CarsNames.Add(item);
        }
    }

}

