using AutoMapper;
using Login.Data;
using Login.IRepository;
using Login.Repository;
using Login.Service;
using Login.Variables;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;

namespace Login
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static IHost AppHost { get; set; }
        private string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "RoboticsPos");
        public App()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            if (!File.Exists(StaticVariable.DatabaseName))
            {
                File.Create(StaticVariable.DatabaseName);
            }
            using var dbContext = new AppDBContext();
            dbContext.Database.Migrate();

            AppHost = Host.CreateDefaultBuilder().ConfigureServices((_, services) =>
            {
                services.AddDbContext<AppDBContext>();
                services.AddAutoMapper(typeof(IMapper));
                services.AddScoped<IUserService, UserService>();
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

                services.AddScoped<IEmployeeRepository, EmployeeRepository>();
                services.AddScoped<EmployeService>();
                

                services.AddTransient<MainWindow>();

            }).Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();

            var startupFrom=AppHost.Services.GetRequiredService<MainWindow>();
            startupFrom.Show();

            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }
    }

}
