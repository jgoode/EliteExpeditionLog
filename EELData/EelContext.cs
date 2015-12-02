using System;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace EELData {
    public class EelContext: DbContext {
        public DbSet<Expedition> Expeditions { get; set; }
        public DbSet<StarSystem> StarSystems { get; set; }
        public DbSet<SystemObject> SystemObjects { get; set; }
        public DbSet<ObjectType> ObjectTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBulder) {
            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "eel.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);

            optionsBulder.UseSqlite(connection);
        }
    }
}
