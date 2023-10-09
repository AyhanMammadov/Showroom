using Dapper;
using Showroom.Repositories.EFCoreRepository.DbContext;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Showroom
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {

            var context = new MyEFRepository();
            context.Database.EnsureCreated(); // creating Database on other localhost

            var sqlConnection = new SqlConnection("Server = localhost; Database = CarsUrl; Integrated Security = True; ");
            sqlConnection.Open();

            string checkDataSql = "SELECT COUNT(*) FROM UrlAdreses";
            int dataCount = sqlConnection.ExecuteScalar<int>(checkDataSql);

            if (dataCount == 0)
            {
                string SqlCarsUrl = File.ReadAllText("SQL/CarPhotos/CarsUrl.sql");
                sqlConnection.Execute(SqlCarsUrl);

                string CarsName = File.ReadAllText("SQL/CarPhotos/CarsName.sql");
                sqlConnection.Execute(CarsName);
            }
                base.OnStartup(e);
        }
    }
}
