using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System;

namespace Proyecto
{
    public partial class clientes : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGridClientes();
            }
        }

        protected void LlenarGridClientes()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM clientes"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            ClientesGrid.DataSource = dt;
                            ClientesGrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void bagregarCliente_Click(object sender, EventArgs e)
        {
            string nombreCliente = TnombreCliente.Text;
            string correoElectronico = Tcorreo.Text;
            string numeroTelefono = TnumeroTel.Text;

            int resultado = AgregarCliente(nombreCliente, correoElectronico, numeroTelefono);

            if (resultado > 0)
            {
                MostrarAlerta("Cliente agregado con éxito");
                TnombreCliente.Text = string.Empty;
                Tcorreo.Text = string.Empty;
                TnumeroTel.Text = string.Empty;
                LlenarGridClientes();
            }
            else
            {
                MostrarAlerta("Error al agregar cliente");
            }
        }

        protected void BborrarCliente_Click(object sender, EventArgs e)
        {
            // Obtener el ID del cliente ingresado en el TextBox
            int clienteID = 0;
            if (int.TryParse(TclienteID.Text, out clienteID))
            {
                int resultado = BorrarCliente(clienteID);

                if (resultado > 0)
                {
                    MostrarAlerta("Cliente eliminado con éxito");
                    LlenarGridClientes();
                }
                else
                {
                    MostrarAlerta("Error al eliminar cliente");
                }
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la eliminación");
            }
        }

        protected void BmodificarCliente_Click(object sender, EventArgs e)
        {
            // Obtener el ID del cliente ingresado en el TextBox
            int clienteID = 0;
            if (int.TryParse(TclienteID.Text, out clienteID))
            {
                // Obtener la información del cliente desde la base de datos
                Cliente cliente = ObtenerClientePorID(clienteID);

                // Verificar si se encontró el cliente
                if (cliente != null)
                {
                    // Actualizar la información del cliente con los nuevos datos
                    cliente.Nombre = TnombreCliente.Text;
                    cliente.CorreoElectronico = Tcorreo.Text;
                    cliente.Telefono = TnumeroTel.Text;

                    // Llamar al método para modificar el cliente
                    ModificarCliente(cliente);

                    // Llenar el grid con los datos actualizados
                    LlenarGridClientes();
                }
                else
                {
                    MostrarAlerta("No se encontró un cliente con el ID proporcionado");
                }
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la modificación");
            }
        }

        protected void BconsultarCliente_Click(object sender, EventArgs e)
        {
            // Obtener el ID del cliente ingresado en el TextBox
            int clienteID = 0;
            if (int.TryParse(TclienteID.Text, out clienteID))
            {
                // Realizar la consulta del cliente por ID
                ConsultarClientePorID(clienteID);
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la consulta");
            }
        }

        private int AgregarCliente(string nombre, string correo, string telefono)
        {
            int result = 0;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("AgregarCliente", con))
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

        private int BorrarCliente(int clienteID)
        {
            int result = 0;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarCliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteID", clienteID);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        private void ConsultarClientePorID(int clienteID)
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarClientePorID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteID", clienteID);

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                // Llenar los controles con los datos del cliente consultado
                                TnombreCliente.Text = dt.Rows[0]["nombre"].ToString();
                                Tcorreo.Text = dt.Rows[0]["correoElectronico"].ToString();
                                TnumeroTel.Text = dt.Rows[0]["telefono"].ToString();
                            }
                            else
                            {
                                MostrarAlerta("No se encontró un cliente con el ID proporcionado");
                            }
                        }
                    }
                }
            }
        }

        private void ModificarCliente(Cliente cliente)
        {
            // Configura la conexión a la base de datos
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarCliente", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros necesarios para el procedimiento almacenado
                    cmd.Parameters.AddWithValue("@ClienteID", cliente.ClienteID);
                    cmd.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", cliente.CorreoElectronico);
                    cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);

                    // Abre la conexión y ejecuta el comando
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Cliente ObtenerClientePorID(int clienteID)
        {
            Cliente cliente = null;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarClientePorID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ClienteID", clienteID);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            cliente = new Cliente
                            {
                                ClienteID = Convert.ToInt32(reader["ClienteID"]),
                                Nombre = Convert.ToString(reader["nombre"]),
                                CorreoElectronico = Convert.ToString(reader["correoElectronico"]),
                                Telefono = Convert.ToString(reader["telefono"])
                            };
                        }
                    }
                }
            }

            return cliente;
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