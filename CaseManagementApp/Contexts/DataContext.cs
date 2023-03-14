using CaseManagementApp.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseManagementApp.Contexts
{
    internal class DataContext : DbContext
    {
        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\hanna\OneDrive\Skrivbord\EC-utbildning\Datalagring\EC-DataStorage-Assignment\CaseManagementApp\Contexts\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        #region constructors

        public DataContext()
        {
            
        }

        public DataContext(DbContextOptions options) : base(options)
        {

        }
        #endregion

        #region overrides

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer(_connectionString);
        }

        #endregion

        #region entities

        public DbSet<ReportEntity> Reports { get; set; } = null!;
        public DbSet<ClientEntity> Clients { get; set; } = null!;
        public DbSet<CommentEntity> Comments { get; set; } = null!;
        public DbSet<StatusEntity> Statuses { get; set; } = null!;

        #endregion
    }
}
