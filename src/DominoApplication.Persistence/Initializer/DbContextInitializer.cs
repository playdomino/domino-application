using System.Threading.Tasks;

namespace DominoApplication.Persistence.Initializer
{
    public class DbContextInitializer
    {
        private readonly IMongoDbContext mongoDbContext;

        public DbContextInitializer(IMongoDbContext mongoDbContext)
        {
            this.mongoDbContext = mongoDbContext;
        }

        public void Initial()
        {
          
        }
    }
}

