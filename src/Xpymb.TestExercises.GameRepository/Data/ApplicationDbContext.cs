using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Xpymb.TestExercises.GameRepository.Data.Entities;

namespace Xpymb.TestExercises.GameRepository.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public virtual DbSet<GameInfoEntity> GamesInfo { get; set; }
        
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}