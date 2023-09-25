using System.ComponentModel.DataAnnotations;

namespace APIDailyTasks.Domain.Entities
{
    public class Tarefa
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descricao { get; set; }
        public bool Finalizado { get; set; }
    }
}
