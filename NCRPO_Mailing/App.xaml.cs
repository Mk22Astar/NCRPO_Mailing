using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace NCRPO_Mailing
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var optionsBuilder = new DbContextOptionsBuilder<ncrpoContext>();
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=Ujhbkrf54;Database=ncrpo");

            using (var context = new ncrpoContext(optionsBuilder.Options))
            {
                var initializer = new DatabaseInitializer(context);
                initializer.Initialize();
            }

            
        }
    }
}
