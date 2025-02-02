﻿using TestAPI.Managers;
using Microsoft.EntityFrameworkCore;

namespace TestAPI.Context
{
    public class ApplicationContext
    {

        public ApplicationContext(IConfiguration config)
        {
            Version = "0.1";
            Title = "TestAPI";
            Configuration = config;
            Initialize();
        }

        public void Initialize()
        {

            /*Инициализация менеджеров*/
            DoctorsManager = new DoctorsManager(this);
            PatientsManager = new PatientsManager(this);

            DoctorsManager.Read();
            PatientsManager.Read();

        }

        public DoctorsManager DoctorsManager { get; set; }
        public PatientsManager PatientsManager { get; set; }
        public string Version { get; set; }
        public string Title { get; set; }
        public IConfiguration Configuration { get; set; }

        /*Здесь указать название подключения из appsettings*/
        public DBContext CreateDbContext() => new DBContext(Configuration.GetConnectionString("DefaultConnection"));

    }
}
