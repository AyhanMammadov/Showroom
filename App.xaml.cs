using Dapper;
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
            var sqlConnection = new SqlConnection("Server = localhost; Database = CarsUrl; Integrated Security = True; ");
            sqlConnection.Open();

            string checkDataSql = "SELECT COUNT(*) FROM UrlAdreses";
            int dataCount = sqlConnection.ExecuteScalar<int>(checkDataSql);

            if (dataCount == 0)
            {
                string createTableSql = File.ReadAllText("SQL/CarPhotos/Create.sql");
                sqlConnection.Execute(createTableSql);

                string insertDataSql = File.ReadAllText("SQL/CarPhotos/Insert.sql");
                sqlConnection.Execute(insertDataSql);
            }
                base.OnStartup(e);
        }
    }
}
