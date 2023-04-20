using PostgresDB.Data;

namespace PostgresDB.Services
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApiDbContext _context;
        private readonly ILogger _logger;

        public ITeamRepo Teams { get; private set; }



        public UnitOfWork(ApiDbContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Teams = new TeamRepo(context, _logger);
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }


    }
}