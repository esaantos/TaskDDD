using System.ComponentModel.DataAnnotations;

namespace DailyTask.Application.Dtos
{
    public class ReadTarefaDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; }        
        public string Descricao { get; set; }
        public bool Finalizado { get; set; }
        public DateTime DataConsulta { get; set; } = DateTime.Now;
    }
}
