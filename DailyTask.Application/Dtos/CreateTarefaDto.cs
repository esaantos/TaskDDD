using System.ComponentModel.DataAnnotations;

namespace DailyTask.Application.Dtos
{
    public class CreateTarefaDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }        
        public bool Finalizado { get; set; } = false;
    }
}
