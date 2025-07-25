namespace ToDoListPractice1.Models
{
    public class Tarea
    {

        // Propiedades de la clase Tarea que se van a mapear a la base de datos

        #region Propiedades
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public bool Completado { get; set; }

        #endregion

    }
}
