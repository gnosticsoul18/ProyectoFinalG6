using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace proyecto
{
    public partial class login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Bingresar_Click(object sender, EventArgs e)
        {
            try
            {
                // Configura la conexión a la base de datos
                string constr = System.Configuration.ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

                using (SqlConnection con = new SqlConnection(constr))
                {
                    // Abre la conexión
                    con.Open();

                    // Crea el comando SQL para obtener el usuario por correo y contraseña
                    using (SqlCommand cmd = new SqlCommand("ValidarUsuario", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Correo", Tlogin.Text);
                        cmd.Parameters.AddWithValue("@Clave", Tclave.Text);

                        using (SqlDataReader registro = cmd.ExecuteReader())
                        {
                            if (registro.Read())
                            {
                                // Redirige a la página de inicio si la autenticación es exitosa
                                Response.Redirect("inicio.aspx");
                            }
                            else
                            {
                                Lmensaje.Text = "Usuario o contraseña incorrectos";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Lmensaje.Text = "Error: " + ex.Message;
            }
        }
    }
}