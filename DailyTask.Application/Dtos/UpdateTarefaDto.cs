using System.ComponentModel.DataAnnotations;

namespace DailyTask.Application.Dtos
{
    public class UpdateTarefaDto
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public bool Finalizado { get; set; }
    }
}
