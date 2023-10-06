using Showroom.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.ViewModels;
public class AboutUsViewModel : ViewModelBase
{
    public string AboutUsInfo { get; set; }
    public AboutUsViewModel()
    {
        AboutUsInfo = File.ReadAllText("Assets/aboutUsInfo.txt");
    }
}

