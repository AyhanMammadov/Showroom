using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Models;
public class TestDriveUsers
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Surname { get; set; }
    public string Phone { get; set; }
    public string? Email { get; set; }
    public CarsName? Cars { get; set; }
    public int? CarsId { get; set; }
    public string? Notes { get; set; }

}

