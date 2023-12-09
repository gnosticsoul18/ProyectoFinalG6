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
    public partial class reparaciones : Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM reparaciones"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ReparacionesGrid.DataSource = dt;
                            ReparacionesGrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void bagregarReparacion_Click(object sender, EventArgs e)
        {
            string descripcion = Tdescripcion.Text;
            string fecha = Tfecha.Text;
            int tecnicoID = Convert.ToInt32(TtecnicoID.Text);

            int resultado = AgregarReparacion(descripcion, fecha, tecnicoID);

            if (resultado > 0)
            {
                MostrarAlerta("Reparación agregada con éxito");
                Tdescripcion.Text = string.Empty;
                Tfecha.Text = string.Empty;
                TtecnicoID.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                MostrarAlerta("Error al agregar reparación");
            }
        }

        protected void BborrarReparacion_Click(object sender, EventArgs e)
        {
            // Obtener el ID de la reparación ingresado en el TextBox
            int reparacionID = 0;
            if (int.TryParse(TreparacionID.Text, out reparacionID))
            {
                int resultado = BorrarReparacion(reparacionID);

                if (resultado > 0)
                {
                    MostrarAlerta("Reparación eliminada con éxito");
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta("Error al eliminar reparación");
                }
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la eliminación");
            }
        }

        protected void BmodificarReparacion_Click(object sender, EventArgs e)
        {
            // Obtener el ID de la reparación ingresado en el TextBox
            int reparacionID = 0;
            if (int.TryParse(TreparacionID.Text, out reparacionID))
            {
                // Obtener la información de la reparación desde la base de datos
                Reparacion reparacion = ObtenerReparacionPorID(reparacionID);

                // Verificar si se encontró la reparación
                if (reparacion != null)
                {
                    // Actualizar la información de la reparación con los nuevos datos
                    reparacion.Descripcion = Tdescripcion.Text;
                    reparacion.Fecha = Tfecha.Text;
                    reparacion.TecnicoID = Convert.ToInt32(TtecnicoID.Text);

                    // Llamar al método para modificar la reparación
                    ModificarReparacion(reparacion);

                    // Llenar el grid con los datos actualizados
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta("No se encontró una reparación con el ID proporcionado");
                }
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la modificación");
            }
        }

        protected void BconsultarReparacion_Click(object sender, EventArgs e)
        {
            // Obtener el ID de la reparación ingresado en el TextBox
            int reparacionID = 0;
            if (int.TryParse(TreparacionID.Text, out reparacionID))
            {
                // Realizar la consulta de la reparación por ID
                ConsultarReparacionPorID(reparacionID);
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la consulta");
            }
        }

        private int AgregarReparacion(string descripcion, string fecha, int tecnicoID)
        {
            int result = 0;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("AgregarReparacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    cmd.Parameters.AddWithValue("@TecnicoID", tecnicoID);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        private int BorrarReparacion(int reparacionID)
        {
            int result = 0;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarReparacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReparacionID", reparacionID);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        private void ConsultarReparacionPorID(int reparacionID)
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarReparacionPorID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReparacionID", reparacionID);

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                // Llenar los controles con los datos de la reparación consultada
                                Tdescripcion.Text = dt.Rows[0]["descripcion"].ToString();
                                Tfecha.Text = dt.Rows[0]["fecha"].ToString();
                                TtecnicoID.Text = dt.Rows[0]["tecnicoID"].ToString();
                            }
                            else
                            {
                                MostrarAlerta("No se encontró una reparación con el ID proporcionado");
                            }
                        }
                    }
                }
            }
        }

        private void ModificarReparacion(Reparacion reparacion)
        {
            // Configura la conexión a la base de datos
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarReparacion", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros necesarios para el procedimiento almacenado
                    cmd.Parameters.AddWithValue("@ReparacionID", reparacion.ReparacionID);
                    cmd.Parameters.AddWithValue("@Descripcion", reparacion.Descripcion);
                    cmd.Parameters.AddWithValue("@Fecha", reparacion.Fecha);
                    cmd.Parameters.AddWithValue("@TecnicoID", reparacion.TecnicoID);

                    // Abre la conexión y ejecuta el comando
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Reparacion ObtenerReparacionPorID(int reparacionID)
        {
            Reparacion reparacion = null;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarReparacionPorID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ReparacionID", reparacionID);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reparacion = new Reparacion
                            {
                                ReparacionID = Convert.ToInt32(reader["ReparacionID"]),
                                Descripcion = Convert.ToString(reader["descripcion"]),
                                Fecha = Convert.ToString(reader["fecha"]),
                                TecnicoID = Convert.ToInt32(reader["tecnicoID"])
                            };
                        }
                    }
                }
            }

            return reparacion;
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