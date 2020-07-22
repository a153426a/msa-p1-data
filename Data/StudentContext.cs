﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using msa_p1_data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace msa_p1_data.Data
{
    public class StudentContext : DbContext
    {
        // an empty constructor
        public StudentContext() { }

        // base(options) calls the base class's constructor,
        // in this case, our base class is DbContext
        public StudentContext(DbContextOptions<StudentContext> options) : base(options) { }

        // Use DbSet<Student> to query or read and 
        // write information about A Student
        public DbSet<Student> Student { get; set; }

        // Use DbSet<Address> to query or read and 
        // write information about An Address
        public DbSet<Address> Address { get; set; }
        public static System.Collections.Specialized.NameValueCollection AppSettings { get; }

        // configure the database to be used by this context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

            // schoolSIMSConnection is the name of the key that
            // contains the has the connection string as the value
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("schoolSIMSConnection"));
        }
    }
}
