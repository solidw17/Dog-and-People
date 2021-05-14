using DogAndPeople.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogAndPeople.DataAccess.SQL
{
    public class DataContext : DbContext
    {
        public DataContext() : base("DefaultConnection")
        {

        }

        public DbSet<Caes> Dogs { get; set; }
        public DbSet<Donos> Owners { get; set; }
        public DbSet<CaesDonos> DogAndOwners { get; set; }
    }
}
