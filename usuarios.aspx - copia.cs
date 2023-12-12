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

        protected void BmodificarUsuario_Click(object sender, EventArgs e)
        {
            int usuarioID = 0;
            if (int.TryParse(TusuarioID.Text, out usuarioID))
            {
                Usuario usuario = ObtenerUsuarioPorID(usuarioID);

                if (usuario != null)
                {
                    // Solo permitir modificar correo y contraseña
                    usuario.CorreoElectronico = Tcorreou.Text;
                    usuario.Contraseña = Tcontraseña.Text;

                    // Nuevo campo para el tipo de usuario
                    usuario.TipoUsuario = DdlTipoUsuario.SelectedValue;

                    ModificarUsuario(usuario);
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
            int usuarioID = 0;
            if (int.TryParse(TusuarioID.Text, out usuarioID))
            {
                ConsultarUsuarioPorID(usuarioID);
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la consulta");
            }
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
                                TnombreUsuario.Text = dt.Rows[0]["nombre"].ToString();
                                Tcorreou.Text = dt.Rows[0]["UsuarioCorreo"].ToString();
                                Tcontraseña.Text = dt.Rows[0]["Contraseña"].ToString();
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
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarUsuario", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@UsuarioID", usuario.UsuarioID);
                    cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    cmd.Parameters.AddWithValue("@UsuarioCorreo", usuario.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@Contrasena", usuario.Contraseña);

                    // Nuevo parámetro para el tipo de usuario
                    cmd.Parameters.AddWithValue("@TipoUsuario", usuario.TipoUsuario);

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
                                CorreoElectronico = Convert.ToString(reader["UsuarioCorreo"]),
                                Contraseña = Convert.ToString(reader["contraseña"])
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

        protected void UsuariosGrid_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            UsuariosGrid.PageIndex = e.NewPageIndex;
            LlenarGrid();
        }
    }
}