using Kolokwium.DAL;

namespace Kolokwium.Tests.UnitTests
{
    public abstract class BaseUnitTests
    {
        protected readonly ApplicationDbContext DbContext;
        public BaseUnitTests(ApplicationDbContext dbContext)
        {
            DbContext = dbContext; ;
        }
    }
}
