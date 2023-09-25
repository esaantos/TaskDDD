using APIDailyTasks.Domain.Entities;
using AutoMapper;
using DailyTask.Application.Dtos;
using DailyTask.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIGerenciadorTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private ITarefaService _tarefaService;
        private IMapper _mapper;
        public TarefaController(ITarefaService categoryService, IMapper mapper)
        {
            _tarefaService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ReadTarefaDto>> RecuperaTarefa()
        {
            var tarefas = await _tarefaService.RecuperaTarefa();
            return _mapper.Map<IEnumerable<ReadTarefaDto>>(tarefas);
        }
        [HttpPost]
        public async Task<IActionResult> AdicionaTarefa([FromBody] CreateTarefaDto tarefaDto)
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaDto);
            var result = await _tarefaService.AdicionaTarefa(tarefa);
            if(!result.Success)
                return BadRequest();

            var tarefaResource = _mapper.Map<CreateTarefaDto>(result.Resource);
            return Ok(tarefaResource);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> RecuperaTarefaPorId(int id)
        {
            var tarefa = await _tarefaService.RecuperaTarefaPorId(id);
            if (tarefa == null) return NotFound();
            var tarefaDto = _mapper.Map<ReadTarefaDto>(tarefa);
            return Ok(tarefaDto);

        }
        [HttpGet("naofinalizada")]
        public async Task<IEnumerable<ReadTarefaDto>> RecuperaTarefaNaoFinalizadaAsync()
        {
            var tarefas = await _tarefaService.RecuperaTarefaNaoFinalizada();
            return _mapper.Map<IEnumerable<ReadTarefaDto>>(tarefas);
        }
        [HttpGet("finalizada")]
        public async Task<IEnumerable<ReadTarefaDto>> RecuperaTarefaFinalizadaAsync()
        {
            var tarefas = await _tarefaService.RecuperaTarefaFinalizada();
            return _mapper.Map<IEnumerable<ReadTarefaDto>>(tarefas);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizaTarefa(int id, [FromBody] UpdateTarefaDto tarefaDto)
        {
            var tarefa = _mapper.Map<Tarefa>(tarefaDto);
            var result = await _tarefaService.AtualizaTarefa(id, tarefa);
            if (result == null) return NotFound();
            return NoContent();

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletaTarefa(int id)
        {
            var result = await _tarefaService.DeletaTarefa(id);
            if (!result.Success)
            {
                return NotFound();
            }
            return Ok("Tarefa excluída com sucesso!");
        }
    }
}
