using TeprestpApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TeprestpApi.Data
{
    public class Contexto: DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }
        public DbSet<Ocupaciones> ocupaciones => Set<Ocupaciones>();
    }
}
