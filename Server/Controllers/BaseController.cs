using ExtensaoCurricular.Server.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExtensaoCurricular.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class BaseController<T> : ControllerBase
{
    private readonly IBaseRepository<T> _repository;
    private readonly ILogger<T> _logger;

    public BaseController(IBaseRepository<T> repository, ILogger<T> logger)
    {
        _repository = repository;
        _logger = logger;
    }

    protected IActionResult HandleStatusCodeResponse(object obj)
    {
        if (obj is null)
            return BadRequest();

        return Ok(obj);
    }
}