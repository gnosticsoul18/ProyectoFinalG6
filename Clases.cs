namespace Proyecto
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Telefono { get; set; }
    }

    public class Tecnico
    {
        public int TecnicoID { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }
        public string CorreoElectronico { get; set; }
    }

    public class Equipo
    {
        public int EquipoID { get; set; }
        public string TipoEquipo { get; set; }
        public string Modelo { get; set; }
        public int Clienteid { get; set; }
    }

    public class Reparacion
    {
        public int ReparacionID { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public int TecnicoID { get; set; }
    }

    public class DetalleReparacion
    {
        public int ReparacionID { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public int TecnicoID { get; set; }
    }

    public class Asignacion
    {
        public int AsignacionID { get; set; }
        public string Descripcion { get; set; }
        public string Fecha { get; set; }
        public int TecnicoID { get; set; }
    }

    public class Usuario
    {
        public int UsuarioID { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
        public string TipoUsuario { get; set; }
    }
}