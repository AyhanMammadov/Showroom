using Dapper;
using Showroom.Repositories;
using Showroom.Repositories.Base;
using Showroom.Repositories.EFCoreRepository.DbContext;
using Showroom.ViewModels;
using SimpleInjector;
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
        public static Container container { get; set; } = new Container();

        protected override void OnStartup(StartupEventArgs e)
        {


            container.RegisterSingleton<ICarPhotosRepository ,CarDapperPhotosRepository>();
            container.RegisterSingleton<BaicX3ViewModel>();
            container.RegisterSingleton<BaicX55ViewModel>();
            container.RegisterSingleton<BaicX7ViewModel>();
            container.RegisterSingleton<JacJs8ViewModel>();
            container.RegisterSingleton<JACT8ViewModel>();
            container.Verify();


            var context = new MyEFRepository();
            context.Database.EnsureCreated(); // creating Database on other localhost

            var sqlConnection = new SqlConnection("Server = localhost; Database = EFCoreDb; Integrated Security = True; ");
            sqlConnection.Open();

            string checkDataSql = "SELECT COUNT(*) FROM CarsUrls";
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
