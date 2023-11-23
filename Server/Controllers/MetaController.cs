using ExtensaoCurricular.Server.Repositories.Interfaces;
using ExtensaoCurricular.Shared.Models.General;
using Microsoft.AspNetCore.Mvc;

namespace ExtensaoCurricular.Server.Controllers;

public class MetaController : BaseController<Meta>
{
    private readonly IMetaRepository _repository;

    public MetaController(IMetaRepository repository, ILogger<Meta> logger) : base(repository, logger)
    {
        _repository = repository;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var result = await _repository.GetByIdAsync(id);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetDtosAsync()
    {
        var result = await _repository.GetDtosAsync();
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAsync(Meta meta)
    {
        var hasBeenCreated = await _repository.CreateAsync(meta);
        return Ok(hasBeenCreated);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(Meta meta)
    {
        var hasBeenCreated = await _repository.UpdateAsync(meta);
        return Ok(hasBeenCreated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var hasBeenDeleted = await _repository.DeleteAsync(id);
        return Ok(hasBeenDeleted);
    }
}