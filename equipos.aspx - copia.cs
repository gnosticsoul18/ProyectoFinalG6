﻿using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI;
using System;

namespace Proyecto
{
    public partial class equipos : Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM equipos"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            EquiposGrid.DataSource = dt;
                            EquiposGrid.DataBind();
                        }
                    }
                }
            }
        }

        protected void bagregarEquipo_Click(object sender, EventArgs e)
        {
            string tipoEquipo = DdlTipoEquipo.SelectedValue;
            string modelo = DdlModelo.SelectedValue;
            int Clienteid = Convert.ToInt32(TClienteid.Text);

            int resultado = AgregarEquipo(tipoEquipo, modelo, Clienteid);

            if (resultado > 0)
            {
                MostrarAlerta("Equipo agregado con éxito");
                TClienteid.Text = string.Empty;
                LlenarGrid();
            }
            else
            {
                MostrarAlerta("Error al agregar equipo");
            }
        }

        protected void BborrarEquipo_Click(object sender, EventArgs e)
        {
            // Obtener el ID del equipo ingresado en el TextBox
            int equipoID = 0;
            if (int.TryParse(TequipoID.Text, out equipoID))
            {
                int resultado = BorrarEquipo(equipoID);

                if (resultado > 0)
                {
                    MostrarAlerta("Equipo eliminado con éxito");
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta("Error al eliminar equipo");
                }
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la eliminación");
            }
        }

        protected void BmodificarEquipo_Click(object sender, EventArgs e)
        {
            // Obtener el ID del equipo ingresado en el TextBox
            int equipoID = 0;
            if (int.TryParse(TequipoID.Text, out equipoID))
            {
                // Obtener la información del equipo desde la base de datos
                Equipo equipo = ObtenerEquipoPorID(equipoID);

                // Verificar si se encontró el equipo
                if (equipo != null)
                {
                    // Actualizar la información del equipo con los nuevos datos
                    equipo.TipoEquipo = DdlTipoEquipo.SelectedValue;
                    equipo.Modelo = DdlModelo.SelectedValue;
                    equipo.Clienteid = Convert.ToInt32(TClienteid.Text);

                    // Llamar al método para modificar el equipo
                    ModificarEquipo(equipo);

                    // Llenar el grid con los datos actualizados
                    LlenarGrid();
                }
                else
                {
                    MostrarAlerta("No se encontró un equipo con el ID proporcionado");
                }
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la modificación");
            }
        }

        protected void BconsultarEquipo_Click(object sender, EventArgs e)
        {
            // Obtener el ID del equipo ingresado en el TextBox
            int equipoID = 0;
            if (int.TryParse(TequipoID.Text, out equipoID))
            {
                // Realizar la consulta del equipo por ID
                ConsultarEquipoPorID(equipoID);
            }
            else
            {
                MostrarAlerta("Ingrese un ID válido para la consulta");
            }
        }

        private int AgregarEquipo(string tipoEquipo, string modelo, int Clienteid)
        {
            int result = 0;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("AgregarEquipo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TipoEquipo", tipoEquipo);
                    cmd.Parameters.AddWithValue("@Modelo", modelo);
                    cmd.Parameters.AddWithValue("@Clienteid", Clienteid);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        private int BorrarEquipo(int equipoID)
        {
            int result = 0;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("EliminarEquipo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EquipoID", equipoID);

                    con.Open();
                    result = cmd.ExecuteNonQuery();
                }
            }
            return result;
        }

        private void ConsultarEquipoPorID(int equipoID)
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarEquipoPorID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EquipoID", equipoID);

                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                // Llenar los controles con los datos del equipo consultado
                                DdlTipoEquipo.SelectedValue = dt.Rows[0]["tipoEquipo"].ToString();
                                DdlModelo.SelectedValue = dt.Rows[0]["modelo"].ToString();
                                TClienteid.Text = dt.Rows[0]["Clienteid"].ToString();
                            }
                            else
                            {
                                MostrarAlerta("No se encontró un equipo con el ID proporcionado");
                            }
                        }
                    }
                }
            }
        }

        private void ModificarEquipo(Equipo equipo)
        {
            // Configura la conexión a la base de datos
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarEquipo", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agrega los parámetros necesarios para el procedimiento almacenado
                    cmd.Parameters.AddWithValue("@EquipoID", equipo.EquipoID);
                    cmd.Parameters.AddWithValue("@TipoEquipo", equipo.TipoEquipo);
                    cmd.Parameters.AddWithValue("@Modelo", equipo.Modelo);
                    cmd.Parameters.AddWithValue("@Clienteid", equipo.Clienteid);

                    // Abre la conexión y ejecuta el comando
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Equipo ObtenerEquipoPorID(int equipoID)
        {
            Equipo equipo = null;
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultarEquipoPorID", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EquipoID", equipoID);

                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            equipo = new Equipo
                            {
                                EquipoID = Convert.ToInt32(reader["EquipoID"]),
                                TipoEquipo = Convert.ToString(reader["tipoEquipo"]),
                                Modelo = Convert.ToString(reader["modelo"]),
                                Clienteid = Convert.ToInt32(reader["Clienteid"])
                            };
                        }
                    }
                }
            }

            return equipo;
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