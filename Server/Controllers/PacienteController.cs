using ExtensaoCurricular.Server.Repositories.Interfaces;
using ExtensaoCurricular.Shared.Models.Geral;
using Microsoft.AspNetCore.Mvc;

namespace ExtensaoCurricular.Server.Controllers;

    public class PacienteController : BaseController<Paciente>
{
    private readonly IPacienteRepository _repository;

    public PacienteController(IPacienteRepository repository, ILogger<Paciente> logger) : base(repository, logger)
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
    public async Task<IActionResult> CreateAsync(Paciente paciente)
    {
        var hasBeenCreated = await _repository.CreateAsync(paciente);
        return Ok(hasBeenCreated);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(Paciente paciente)
    {
        var hasBeenCreated = await _repository.UpdateAsync(paciente);
        return Ok(hasBeenCreated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var hasBeenDeleted = await _repository.DeleteAsync(id);
        return Ok(hasBeenDeleted);
    }
}