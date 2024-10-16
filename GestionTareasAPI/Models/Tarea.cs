using System.ComponentModel.DataAnnotations;

namespace GestionTareasAPI.Models
{
    //Representa una tarea en el sistema
    public class Tarea
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria mi chinito")]
        [MaxLength(500, ErrorMessage = "La descrión no puede exceder los 500 caracteres")]
        public string Descripcion { get; set; }
        public bool Completada { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }
    }
}
