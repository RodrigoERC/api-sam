using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ApiVeterinaria.Models
{
    public class clsProveedor
    {
        public int Id { get; set; }

        public string StrNombre { get; set; }

        public string StrTelefono { get; set; }

        public string StrCorreo { get; set; }

        public string StrDireccion { get; set; }

        private string strconConnectionString { get; set; }

        private object objIdSqlDbType { get; set; }

        public clsProveedor() {
            this.Id = 0;
            this.StrNombre = "";
            this.StrTelefono = "";
            this.StrCorreo = "";
            this.StrDireccion = "";

            this.strconConnectionString = ConfigurationManager.ConnectionStrings["veterinaria"].ConnectionString;

        }

        public clsProveedor(int pId, string pNombre, string pTelefono, string pCorreo, string pDireccion) {
            this.Id = pId;
            this.StrNombre = pNombre;
            this.StrTelefono = pTelefono;
            this.StrCorreo = pCorreo;
            this.StrDireccion = pDireccion;
        }

        public bool Agregar(clsProveedor proveedor)
        {
            try {
                SqlConnection objconConnection = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("spAgregarProveedor", objconConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter nombre = cmdComando.Parameters.Add("@nombre", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = proveedor.StrNombre;

                SqlParameter telefono = cmdComando.Parameters.Add("@telefono", SqlDbType.VarChar, 80);
                telefono.Direction = ParameterDirection.Input;
                telefono.Value = proveedor.StrTelefono;

                SqlParameter correo = cmdComando.Parameters.Add("@correo", SqlDbType.VarChar, 80);
                correo.Direction = ParameterDirection.Input;
                correo.Value = proveedor.StrCorreo;

                SqlParameter Direccion = cmdComando.Parameters.Add("@direccion", SqlDbType.VarChar, 80);
                Direccion.Direction = ParameterDirection.Input;
                Direccion.Value = proveedor.StrDireccion;

                objconConnection.Open();
                cmdComando.ExecuteNonQuery();
                objconConnection.Close();

                return true;
            }
            catch (Exception e) {
                return false;
            }

        }

        public bool Modificar(clsProveedor proveedor)
        {
            try
            {
                SqlConnection objconConnection = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("spModificarProveedor", objconConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter id = cmdComando.Parameters.Add("@idProveedor", SqlDbType.VarChar, 80);
                id.Direction = ParameterDirection.Input;
                id.Value = proveedor.Id;


                SqlParameter nombre = cmdComando.Parameters.Add("@nombre", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = proveedor.StrNombre;

                SqlParameter telefono = cmdComando.Parameters.Add("@telefono", SqlDbType.VarChar, 80);
                telefono.Direction = ParameterDirection.Input;
                telefono.Value = proveedor.StrTelefono;

                SqlParameter correo = cmdComando.Parameters.Add("@correo", SqlDbType.VarChar, 80);
                correo.Direction = ParameterDirection.Input;
                correo.Value = proveedor.StrCorreo;

                SqlParameter Direccion = cmdComando.Parameters.Add("@direccion", SqlDbType.VarChar, 80);
                Direccion.Direction = ParameterDirection.Input;
                Direccion.Value = proveedor.StrDireccion;

                objconConnection.Open();
                cmdComando.ExecuteNonQuery();
                objconConnection.Close();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool Eliminar(int id)
        {
            try {
                SqlConnection objconConnection = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("spEliminarProveedor", objconConnection); // Nombre del storeProcedure
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter idProveedor = cmdComando.Parameters.Add("@idProveedor", SqlDbType.Int);
                idProveedor.Direction = ParameterDirection.Input;
                idProveedor.Value = id;

                objconConnection.Open();
                cmdComando.ExecuteNonQuery();
                objconConnection.Close();

                return true;
            }
            catch (Exception e) {
                return false;
            }
        }

        public string CargarProveedor() {
            try
            {
                SqlConnection objconConnection = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("spProveedorDatos", objconConnection); // Nombre del storeProcedure
                cmdComando.CommandType = CommandType.StoredProcedure;

                objconConnection.Open();
                cmdComando.CommandTimeout = 300;


                StringBuilder Datos = new StringBuilder();

                SqlDataReader Registros = cmdComando.ExecuteReader(CommandBehavior.CloseConnection);

                Datos.Append("[");
                while (Registros.Read())
                       Datos.Append("{" + '"' + "idProveedor" + '"' + ":" + Registros["idProveedor"] + ","
                                        + '"' + "Nombre" + '"' + ":" + Registros["Nombre"] + ","
                                        + '"' + "Telefono" + '"' + ":" + Registros["Telefono"] + ","
                                        + '"' + "Correo" + '"' + ":" + Registros["Correo"] + ","
                                        + '"' + "Direccion" + '"' + ":" + Registros["Direccion"] + "}, ");
                Datos.Remove(Datos.Length - 2, 2);
                Datos.Append("]");
                Registros.Close();

                return Datos.ToString();

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string Buscar(string b) {
            try {
                SqlConnection objconConnection = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("spProveedorDatos", objconConnection); // Nombre del storeProcedure
                cmdComando.CommandType = CommandType.StoredProcedure;

                objconConnection.Open();
                cmdComando.CommandTimeout = 300;

                StringBuilder Datos = new StringBuilder();

                SqlDataReader Registros = cmdComando.ExecuteReader(CommandBehavior.CloseConnection);

                Datos.Append("[");
                while (Registros.Read())
                {
                    string drNombre = Registros["Nombre"].ToString().ToLower();
                    if (drNombre.Contains(b.ToLower()))
                    {
                        Datos.Append("{" + '"' + "idProveedor" + '"' + ":" + Registros["idProveedor"] + ","
                                        + '"' + "Nombre" + '"' + ":" + Registros["Nombre"] + ","
                                        + '"' + "Telefono" + '"' + ":" + Registros["Telefono"] + ","
                                        + '"' + "Correo" + '"' + ":" + Registros["Correo"] + ","
                                        + '"' + "Direccion" + '"' + ":" + Registros["Direccion"] + "}, ");
                    }
                }

                Datos.Remove(Datos.Length - 2, 2);
                Datos.Append("]");
                Registros.Close();

                return Datos.ToString();


            }
            catch (Exception e) {
                return "Error";
            }
        }

    }
}