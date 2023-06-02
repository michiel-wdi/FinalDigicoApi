using FinalDigicoApi.Objects;
using Microsoft.EntityFrameworkCore;

namespace FinalDigicoApi.DBAccess
{
    public interface IDBAccessor 
    {
        DbSet<BasicOccupation> Occupations { get; set; }
        DbSet<BasicSkill> Skills { get; set; }
    }
}