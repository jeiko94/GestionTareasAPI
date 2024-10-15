namespace GestionTareasAPI.Models
{
    //Representa una tarea en el sistema
    public class Tarea
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Completada { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
