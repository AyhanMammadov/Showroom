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

    private const string connectionString = $"Server=localhost;Database=EFCoreDb;Integrated Security = True;";
    private readonly SqlConnection sqlConnection;
    public CarDapperPhotosRepository()
    {
        this.sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();
    }
    public IEnumerable<string> getAllPhotosUrl(string carModelName)
    {
        return this.sqlConnection.Query<string>(sql: @$"select ua.UrlAdres 
from dbo.CarsUrls ua
where ua.CarName = '{carModelName}'");
    }
}

    

