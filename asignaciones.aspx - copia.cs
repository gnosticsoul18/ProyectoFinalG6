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
    public partial class asignaciones : Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM asignaciones"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            AsignacionesGrid.DataSource = dt;
                            AsignacionesGrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void bagregarAsignacion_Click(object sender, EventArgs e)
        {
            int reparacionID = Convert.ToInt32(TreparacionID.Text);
            string fecha = Tfecha.Text;
            int tecnicoID = Convert.ToInt32(TtecnicoID.Text);

            int resultado = AgregarAsignacion(reparacionID, fecha, tecnicoID);

            if (resultado > 0)
            {
                MostrarAlerta("Asignación agregada con éxito");
                TreparacionID.Text = string.Empty;
                Tfecha.Text = string.Empty;
                TtecnicoID.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                MostrarAlerta("Error al agregar asignación");
            }
        }

        protected void BborrarAsignacion_Click(object sender, EventArgs e)
        {
            // Obtener el ID de la asignación ingresado en el TextBox
            int asignacionID = 0;
            if (int.TryParse(TasignacionID.Text, out asignacionID))
            {
                int resultado = BorrarAsignacion(asignacionID);

                if (resultado > 0)
                {
                    MostrarAlerta("Asignación eliminada con éxito");
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta("Error al eliminar asignación");
                }
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la eliminación");
            }
        }

        protected void BmodificarAsignacion_Click(object sender, EventArgs e)
        {
            // Obtener el ID de la asignación ingresado en el TextBox
            int asignacionID = 0;
            if (int.TryParse(TasignacionID.Text, out asignacionID))
            {
                // Obtener la información de la asignación desde la base de datos
                Asignacion asignacion = ObtenerAsignacionPorID(asignacionID);

                // Verificar si se encontró la asignación
                if (asignacion != null)
                {
                    // Actualizar la información de la asignación con los nuevos datos
                    asignacion.ReparacionID = Convert.ToInt32(TreparacionID.Text);
                    asignacion.Fecha = Tfecha.Text;
                    asignacion.TecnicoID = Convert.ToInt32(TtecnicoID.Text);

                    // Llamar al método para modificar la asignación
                    ModificarAsignacion(asignacion);

                    // Llenar el grid con los datos actualizados
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta("No se encontró una asignación con el ID proporcionado");
                }
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la modificación");
            }
        }

        protected void BconsultarAsignacion_Click(object sender, EventArgs e)
        {
            // Obtener el ID de la asignación ingresado en el TextBox
            int asignacionID = 0;
            if (int.TryParse(TasignacionID.Text, out asignacionID))
            {
                // Realizar la consulta de la asignación por ID
                ConsultarAsignacionPorID(asignacionID);
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la consulta");
            }
        }

        private int AgregarAsignacion(int reparacionID, string fecha, int tecnicoID)
        {
            int result = 0;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("AgregarAsignacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReparacionID", reparacionID);  // Cambia aquí de @Descripcion a @ReparacionID
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@TecnicoID", tecnicoID);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        private int BorrarAsignacion(int asignacionID)
        {
            int result = 0;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarAsignacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AsignacionID", asignacionID);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        private void ConsultarAsignacionPorID(int asignacionID)
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarAsignacionPorID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AsignacionID", asignacionID);

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                // Llenar los controles con los datos de la asignación consultada
                                TreparacionID.Text = dt.Rows[0]["reparacionid"].ToString();
                                Tfecha.Text = dt.Rows[0]["fechaAsignacion"].ToString();
                                TtecnicoID.Text = dt.Rows[0]["TecnicoID"].ToString();
                            }
                            else
                            {
                                MostrarAlerta("No se encontró una asignación con el ID proporcionado");
                            }
                        }
                    }
                }
            }
        }

        private void ModificarAsignacion(Asignacion asignacion)
        {
            // Configura la conexión a la base de datos
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarAsignacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros necesarios para el procedimiento almacenado
                    cmd.Parameters.AddWithValue("@AsignacionID", asignacion.AsignacionID);
                    cmd.Parameters.AddWithValue("@Descripcion", asignacion.ReparacionID);
                    cmd.Parameters.AddWithValue("@FechaAsignacion", asignacion.Fecha);
                    cmd.Parameters.AddWithValue("@TecnicoID", asignacion.TecnicoID);

                    // Abre la conexión y ejecuta el comando
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Asignacion ObtenerAsignacionPorID(int asignacionID)
        {
            Asignacion asignacion = null;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarAsignacionPorID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AsignacionID", asignacionID);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            asignacion = new Asignacion
                            {
                                AsignacionID = Convert.ToInt32(reader["AsignacionID"]),
                                ReparacionID = Convert.ToInt32(reader["reparacionid"]),
                                Fecha = Convert.ToString(reader["Fecha"]),
                                TecnicoID = Convert.ToInt32(reader["TecnicoID"])
                            };
                        }
                    }
                }
            }

            return asignacion;
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