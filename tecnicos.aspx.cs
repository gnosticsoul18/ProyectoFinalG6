using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto
{
    public partial class tecnicos : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM tecnicos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            TecnicosGrid.DataSource = dt;
                            TecnicosGrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void bagregarTecnico_Click(object sender, EventArgs e)
        {
            string nombreTecnico = TnombreTecnico.Text;
            string especialidad = Tespecialidad.Text;

            int resultado = AgregarTecnico(nombreTecnico, especialidad);

            if (resultado > 0)
            {
                MostrarAlerta("Técnico agregado con éxito");
                TnombreTecnico.Text = string.Empty;
                Tespecialidad.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                MostrarAlerta("Error al agregar técnico");
            }
        }

        protected void BborrarTecnico_Click(object sender, EventArgs e)
        {
            // Obtener el ID del técnico ingresado en el TextBox
            int tecnicoID = 0;
            if (int.TryParse(TtecnicoID.Text, out tecnicoID))
            {
                int resultado = BorrarTecnico(tecnicoID);

                if (resultado > 0)
                {
                    MostrarAlerta("Técnico eliminado con éxito");
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta("Error al eliminar técnico");
                }
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la eliminación");
            }
        }

        protected void BmodificarTecnico_Click(object sender, EventArgs e)
        {
            // Obtener el ID del técnico ingresado en el TextBox
            int tecnicoID = 0;
            if (int.TryParse(TtecnicoID.Text, out tecnicoID))
            {
                // Obtener la información del técnico desde la base de datos
                Tecnico tecnico = ObtenerTecnicoPorID(tecnicoID);

                // Verificar si se encontró el técnico
                if (tecnico != null)
                {
                    // Actualizar la información del técnico con los nuevos datos
                    tecnico.Nombre = TnombreTecnico.Text;
                    tecnico.Especialidad = Tespecialidad.Text;

                    // Llamar al método para modificar el técnico
                    ModificarTecnico(tecnico);

                    // Llenar el grid con los datos actualizados
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta("No se encontró un técnico con el ID proporcionado");
                }
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la modificación");
            }
        }

        protected void BconsultarTecnico_Click(object sender, EventArgs e)
        {
            // Obtener el ID del técnico ingresado en el TextBox
            int tecnicoID = 0;
            if (int.TryParse(TtecnicoID.Text, out tecnicoID))
            {
                // Realizar la consulta del técnico por ID
                ConsultarTecnicoPorID(tecnicoID);
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la consulta");
            }
        }

        private int AgregarTecnico(string nombre, string especialidad)
        {
            int result = 0;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("AgregarTecnico", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@Especialidad", especialidad);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        private int BorrarTecnico(int tecnicoID)
        {
            int result = 0;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarTecnico", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TecnicoID", tecnicoID);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        private void ConsultarTecnicoPorID(int tecnicoID)
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarTecnicoPorID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TecnicoID", tecnicoID);

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                // Llenar los controles con los datos del técnico consultado
                                TnombreTecnico.Text = dt.Rows[0]["nombre"].ToString();
                                Tespecialidad.Text = dt.Rows[0]["especialidad"].ToString();
                            }
                            else
                            {
                                MostrarAlerta("No se encontró un técnico con el ID proporcionado");
                            }
                        }
                    }
                }
            }
        }

        private void ModificarTecnico(Tecnico tecnico)
        {
            // Configura la conexión a la base de datos
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarTecnico", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros necesarios para el procedimiento almacenado
                    cmd.Parameters.AddWithValue("@TecnicoID", tecnico.TecnicoID);
                    cmd.Parameters.AddWithValue("@Nombre", tecnico.Nombre);
                    cmd.Parameters.AddWithValue("@Especialidad", tecnico.Especialidad);

                    // Abre la conexión y ejecuta el comando
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Tecnico ObtenerTecnicoPorID(int tecnicoID)
        {
            Tecnico tecnico = null;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarTecnicoPorID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TecnicoID", tecnicoID);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tecnico = new Tecnico
                            {
                                TecnicoID = Convert.ToInt32(reader["TecnicoID"]),
                                Nombre = Convert.ToString(reader["nombre"]),
                                Especialidad = Convert.ToString(reader["especialidad"])
                            };
                        }
                    }
                }
            }

            return tecnico;
        }

        private void MostrarAlerta(string mensaje)
        {
            string message = mensaje;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }
    }
}