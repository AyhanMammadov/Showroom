using Dapper;
using Showroom.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Showroom.Repositories;
public class CarDapperPhotosRepository : ICarPhotosRepository
{

    private const string connectionString = $"Server=localhost;Database=CarsUrl;Integrated Security = True;";
    private readonly SqlConnection sqlConnection;
    public CarDapperPhotosRepository()
    {
        this.sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open(); // sprosi u uchitela
    }
    public IEnumerable<string> getAllPhotosUrl(string carModelName)
    {
        return this.sqlConnection.Query<string>(sql: @$"select ua.UrlAdres 
from UrlAdreses ua
where ua.CarName = '{carModelName}'");
    }
}

    

