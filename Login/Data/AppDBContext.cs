using Login.Data.Models;
using Login.Variables;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login.Data
{
   public class AppDBContext :DbContext
    {
       public DbSet<User> Users { get; set; }
       public DbSet<Person> Persons { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<CheckPrintingData> CheckPrintingDatas { get; set; }
        public DbSet<CashBox> CashBoxes { get; set; }

       private SqliteConnection _connection;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            _connection ??= InitializeSqliteConnection();
            optionsBuilder.UseSqlite(_connection);
            base.OnConfiguring(optionsBuilder);
        }
        private static SqliteConnection InitializeSqliteConnection()
        {
            var connectionString = new SqliteConnectionStringBuilder
            {
              DataSource =StaticVariable.DatabaseName,
            };
            return new SqliteConnection(connectionString.ToString());
        }
            
    }
}
