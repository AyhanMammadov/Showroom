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
public class CarPhotosRepository : ICarPhotosRepository
{

    private const string connectionString = $"Server=localhost;Database=CarsUrl;Integrated Security = True;";
    private readonly SqlConnection sqlConnection;
    public CarPhotosRepository()
    {
        this.sqlConnection = new SqlConnection(connectionString);
        sqlConnection.Open();

        string checkDataSql = "SELECT COUNT(*) FROM UrlAdreses";
        int dataCount = sqlConnection.ExecuteScalar<int>(checkDataSql);

        if (dataCount == 0)
        {
            string createTableSql = File.ReadAllText("SQL/CarPhotos/CreateX55.sql");
            sqlConnection.Execute(createTableSql);

            string insertDataSql = File.ReadAllText("SQL/CarPhotos/InsertX55.sql");
            sqlConnection.Execute(insertDataSql);
        }
    }
    public IEnumerable<string> getAllPhotosUrl()
    {
        return this.sqlConnection.Query<string>(sql: @"select ua.UrlAdres 
from UrlAdreses ua
where ua.CarName = 'BaicX55'");
    }
}

    

