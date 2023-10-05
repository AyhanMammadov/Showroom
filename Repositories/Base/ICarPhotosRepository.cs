using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Repositories.Base;
public interface ICarPhotosRepository
{
    public IEnumerable<string> getAllPhotosUrl();
}

