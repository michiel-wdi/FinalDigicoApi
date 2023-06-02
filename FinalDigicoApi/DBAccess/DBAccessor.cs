using FinalDigicoApi.Objects;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalDigicoApi.DBAccess
{
    public class DBAccessor : DbContext, IDBAccessor
    {

        public DbSet<BasicOccupation> Occupations { get; set; }
        public DbSet<BasicSkill> Skills { get; set; }

        public DBAccessor(DbContextOptions<DBAccessor> dboptions) : base(dboptions)
        {

        }

        
    }
}
