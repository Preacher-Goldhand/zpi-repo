using AutoMapper;
using Kolokwium.DAL;
using Microsoft.Extensions.Logging;

namespace Kolokwium.Services.ConcreteServices
{
    public abstract class BaseService
    {
        protected readonly ApplicationDbContext DbContext;
        protected readonly ILogger Logger;
        protected readonly IMapper Mapper;
        protected BaseService(ApplicationDbContext dbContext,
            IMapper mapper, ILogger logger)
        {
            DbContext = dbContext;
            Logger = logger;
            Mapper = mapper;
        }
    }
}
