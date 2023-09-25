using APIDailyTasks.Domain.Entities;
using DailyTask.Domain.Communication;
using DailyTask.Domain.Interfaces.Repositories;
using DailyTask.Domain.Interfaces.Services;

namespace DailyTask.Domain.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IUnitOfWork _unitOfWork;

        public TarefaService(ITarefaRepository tarefaRepository, IUnitOfWork unitOfWork)
        {
            _tarefaRepository = tarefaRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Tarefa>> RecuperaTarefa()
        {
            return await _tarefaRepository.ToListAsync();
        }
        public async Task<Response<Tarefa>> AdicionaTarefa(Tarefa tarefa)
        {
            try
            {
                await _tarefaRepository.AddAsync(tarefa);
                await _unitOfWork.CompleteAsync();
                return new Response<Tarefa>(tarefa);
            }
            catch (Exception ex)
            {
                return new Response<Tarefa>($"Ocorreu um erro ao tentar salvar tafefa: {ex.Message}");
            }
        }
        public async Task<Response<Tarefa>> AtualizaTarefa(int id, Tarefa tarefa)
        {
            var buscaTarefa = await _tarefaRepository.FindByIdAsync(id);
            if(buscaTarefa == null)
                return new Response<Tarefa>("Tarefa não encontrada!");

            buscaTarefa.Titulo = tarefa.Titulo;
            buscaTarefa.Descricao = tarefa.Descricao;
            buscaTarefa.Finalizado = tarefa.Finalizado;
            try
            {
                _tarefaRepository.Update(buscaTarefa);
                await _unitOfWork.CompleteAsync();
                return new Response<Tarefa>(tarefa);
            }
            catch (Exception ex)
            {
                return new Response<Tarefa>($"Ocorreu um erro ao tentar salvar tafefa: {ex.Message}");
            }

        }
        public async Task<Response<Tarefa>> DeletaTarefa(int id)
        {
            var buscaTarefa = await _tarefaRepository.FindByIdAsync(id);
            if (buscaTarefa == null)
                return new Response<Tarefa>("Tarefa não encontrada!");
            try
            {
                _tarefaRepository.Remove(buscaTarefa);
                await _unitOfWork.CompleteAsync();
                return new Response<Tarefa>(buscaTarefa);
            }
            catch (Exception ex)
            {
                return new Response<Tarefa>($"Ocorreu um erro ao tentar excluir tafefa: {ex.Message}");
            }
        }
        public async Task<IEnumerable<Tarefa>> RecuperaTarefaFinalizada()
        {
            return await _tarefaRepository.RecuperaTarefaFinalizada();
        }
        public async Task<IEnumerable<Tarefa>> RecuperaTarefaNaoFinalizada()
        {
            return await _tarefaRepository.RecuperaTarefaNaoFinalizada();
        }
        public Task<Tarefa> RecuperaTarefaPorId(int id)
        {
            throw new NotImplementedException();
        }
    }
}
