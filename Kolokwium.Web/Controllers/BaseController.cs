using AutoMapper;
using Kolokwium.DAL;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Web.Controllers;

/// <summary>
/// BaseController jest kontrolerem bazowym!!! Prosze nie usuwac modyfikatora abstact.  
/// </summary>
//[Authorize]
[ApiController]
[Produces ("application/json")]
[Route ("api/[controller]")]
public abstract class BaseController : Controller
{
    protected readonly ILogger Logger;
    protected readonly IMapper Mapper;
    public BaseController(ILogger logger, IMapper mapper)
    {
        Logger = logger;
        Mapper = mapper;
    }
}
