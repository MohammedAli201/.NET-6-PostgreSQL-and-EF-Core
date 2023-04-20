using Microsoft.EntityFrameworkCore;
using PostgresDB.Data;
using PostgresDB.Models;

namespace PostgresDB.Services
{
    public class TeamRepo : GenericRepository<Team>, ITeamRepo
    {
        public TeamRepo(ApiDbContext context, ILogger logger) : base(context, logger) { }

        public override async Task<IEnumerable<Team>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All function error", typeof(TeamRepo));
                return new List<Team>();
            }
        }

        public override async Task<bool> Upsert(Team entity)
        {
            try
            {
                // var existingUser = await dbSet.Where(x => x.Id == entity.Id)
                //                                     .FirstOrDefaultAsync();

                // if (existingUser == null)
                //     return await Add(entity);

                // existingUser.FirstName = entity.FirstName;
                // existingUser.LastName = entity.LastName;
                // existingUser.Email = entity.Email;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Upsert function error", typeof(TeamRepo));
                return false;
            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                // var exist = await dbSet.Where(x => x.Id == id)
                //                         .FirstOrDefaultAsync();

                // if (exist == null) return false;

                // dbSet.Remove(exist);

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(TeamRepo));
                return false;
            }
        }
    }
}