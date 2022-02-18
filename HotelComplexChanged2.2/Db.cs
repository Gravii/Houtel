using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HotelComplexChanged2._2
{
    public class Db : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Staff> Staffs { get; set; } // Штат
        public DbSet<Status> Statuses { get; set; } // Статус
        public DbSet<Duty> Duties { get; set; } // Должности
        public DbSet<Reserv> Reservs { get; set; } // Бронирование
        // public DbSet<Schedule> Schedules { get; set; } // График дежурств
        public DbSet<Cleaning> Cleanings { get; set; } // График уборки
        // public DbSet<Department> Departments { get; set; } // Департаменты (Кухня, Ресторан, Руководство и т.д.)

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var sb = new SqlConnectionStringBuilder();
            sb.DataSource = @"COMP3-CAB1\SQLEXPRESS"; // DESKTOP-IMA24TP -- COMP4-CAB1\SQLEXPRESS
            sb.InitialCatalog = "ChangedHotelBase";
            sb.IntegratedSecurity = true;
            optionsBuilder.UseSqlServer(sb.ToString());
            base.OnConfiguring(optionsBuilder);
        }
        private Db()
        {
            Database.EnsureCreated();
        }

        static Db db;
        public static Db GetDb()
        {
            if (db == null)
                db = new Db();
            return db;
        }
    }
}
