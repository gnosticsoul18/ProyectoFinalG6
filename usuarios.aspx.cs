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
    public partial class usuarios : Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            UsuariosGrid.DataSource = dt;
                            UsuariosGrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void bagregarUsuario_Click(object sender, EventArgs e)
        {
            string nombreUsuario = Tnombreusuario.Text;
            string correoElectronico = Tcorreo.Text;
            string numeroTelefono = TnumeroTel.Text;

            int resultado = AgregarUsuario(nombreUsuario, correoElectronico, numeroTelefono);

            if (resultado > 0)
            {
                MostrarAlerta("Usuario agregado con éxito");
                Tnombreusuario.Text = string.Empty;
                Tcorreo.Text = string.Empty;
                TnumeroTel.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                MostrarAlerta("Error al agregar usuario");
            }
        }

        protected void BborrarUsuario_Click(object sender, EventArgs e)
        {
            // Obtener el ID del usuario ingresado en el TextBox
            int usuarioID = 0;
            if (int.TryParse(TusuarioID.Text, out usuarioID))
            {
                int resultado = BorrarUsuario(usuarioID);

                if (resultado > 0)
                {
                    MostrarAlerta("Usuario eliminado con éxito");
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta("Error al eliminar usuario");
                }
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la eliminación");
            }
        }

        protected void BmodificarUsuario_Click(object sender, EventArgs e)
        {
            // Obtener el ID del usuario ingresado en el TextBox
            int usuarioID = 0;
            if (int.TryParse(TusuarioID.Text, out usuarioID))
            {
                // Obtener la información del usuario desde la base de datos
                Usuario usuario = ObtenerUsuarioPorID(usuarioID);

                // Verificar si se encontró el usuario
                if (usuario != null)
                {
                    // Actualizar la información del usuario con los nuevos datos
                    usuario.Nombre = Tnombreusuario.Text;
                    usuario.CorreoElectronico = Tcorreo.Text;
                    usuario.Telefono = TnumeroTel.Text;

                    // Llamar al método para modificar el usuario
                    ModificarUsuario(usuario);

                    // Llenar el grid con los datos actualizados
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta("No se encontró un usuario con el ID proporcionado");
                }
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la modificación");
            }
        }


        protected void BconsultarUsuario_Click(object sender, EventArgs e)
        {
            // Obtener el ID del usuario ingresado en el TextBox
            int usuarioID = 0;
            if (int.TryParse(TusuarioID.Text, out usuarioID))
            {
                // Realizar la consulta del usuario por ID
                ConsultarUsuarioPorID(usuarioID);
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la consulta");
            }
        }

        private int AgregarUsuario(string nombre, string correo, string telefono)
        {
            int result = 0;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("AgregarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", nombre);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", correo);
                    cmd.Parameters.AddWithValue("@Telefono", telefono);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        private int BorrarUsuario(int usuarioID)
        {
            int result = 0;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        private void ConsultarUsuarioPorID(int usuarioID)
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarUsuarioPorID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                // Llenar los controles con los datos del usuario consultado
                                Tnombreusuario.Text = dt.Rows[0]["nombre"].ToString();
                                Tcorreo.Text = dt.Rows[0]["correoElectronico"].ToString();
                                TnumeroTel.Text = dt.Rows[0]["telefono"].ToString();
                            }
                            else
                            {
                                MostrarAlerta("No se encontró un usuario con el ID proporcionado");
                            }
                        }
                    }
                }
            }
        }

        private void ModificarUsuario(Usuario usuario)
        {
            // Configura la conexión a la base de datos
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros necesarios para el procedimiento almacenado
                    cmd.Parameters.AddWithValue("@UsuarioID", usuario.UsuarioID);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", usuario.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);

                    // Abre la conexión y ejecuta el comando
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Usuario ObtenerUsuarioPorID(int usuarioID)
        {
            Usuario usuario = null;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarUsuarioPorID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            usuario = new Usuario
                            {
                                UsuarioID = Convert.ToInt32(reader["UsuarioID"]),
                                Nombre = Convert.ToString(reader["nombre"]),
                                CorreoElectronico = Convert.ToString(reader["correoElectronico"]),
                                Telefono = Convert.ToString(reader["telefono"])
                            };
                        }
                    }
                }
            }

            return usuario;
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
