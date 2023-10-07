using Showroom.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Models;
public class UserLoyalCards
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public override string ToString() => $"{Name} , {Email} , {PhoneNumber}";

}

