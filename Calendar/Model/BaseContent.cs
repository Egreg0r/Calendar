using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Calendar.Model
{
    public class BaseContent : DbContext
    {
        public DbSet<Reminder> Reminders { get; set; }

        //public BaseContent(DbContextOptions<BaseContent> options)
        //           : base(options)
        //{

        //}

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "./calendar.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            options.UseSqlite(connection);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //}

    }

}
