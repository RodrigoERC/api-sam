using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class clsCliente
    {

        public int intId { get; set; } 

        public string pstrNombre { get; set; }

        public string pstrDireccion { get; set; }

        public string pstrTelefono { get; set; }

        public string pstrEMail { get; set; }

        private string strConConnectionString { get; set; }
        private object objSqlDBType { get; set; }



        public clsCliente()
        {
            this.intId = 0;
            this.pstrNombre = "";
            this.pstrDireccion = "";
            this.pstrEMail = "";
            this.pstrTelefono = "";


            this.strConConnectionString = ConfigurationManager.ConnectionStrings["BDPrueba"].ConnectionString;
        }

        public clsCliente(int intId, string pstrNombre, string pstrDireccion, string pstrTelefono, string pstrEMail)
        {
            this.intId = intId;
            this.pstrNombre = pstrNombre;
            this.pstrDireccion = pstrDireccion;
            this.pstrTelefono = pstrTelefono;
            this.pstrEMail = pstrEMail;
        }
       
        public string Agregar(clsCliente objclsCliente)
        {
            try
            {
                SqlConnection objconConexion = new  SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("catClientesAgregar", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter nombre = cmdCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = objclsCliente.pstrNombre;

                SqlParameter direccion = cmdCommand.Parameters.Add("@DIRECCION", SqlDbType.VarChar, 80);
                direccion.Direction = ParameterDirection.Input;
                direccion.Value = objclsCliente.pstrDireccion;

                SqlParameter email = cmdCommand.Parameters.Add("@EMAIL", SqlDbType.VarChar, 80);
                email.Direction = ParameterDirection.Input;
                email.Value = objclsCliente.pstrEMail;

                SqlParameter telefono = cmdCommand.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 10);
                telefono.Direction = ParameterDirection.Input;
                telefono.Value = objclsCliente.pstrTelefono;

                objconConexion.Open();
                cmdCommand.ExecuteNonQuery();
                objconConexion.Close();

                return "ok";

            }
            catch(Exception ex)
            {
                return ex.ToString();
            }
            
        }

        public bool Modificar(clsCliente objclsCliente)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("catClientesModificar", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter idCliente = cmdCommand.Parameters.Add("@IDCLIENTE", SqlDbType.Int);
                idCliente.Direction = ParameterDirection.Input;
                idCliente.Value = objclsCliente.intId;

                SqlParameter nombre = cmdCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = objclsCliente.pstrNombre;

                SqlParameter direccion = cmdCommand.Parameters.Add("@DIRECCION", SqlDbType.VarChar, 80);
                direccion.Direction = ParameterDirection.Input;
                direccion.Value = objclsCliente.pstrDireccion;

                SqlParameter email = cmdCommand.Parameters.Add("@EMAIL", SqlDbType.VarChar, 80);
                email.Direction = ParameterDirection.Input;
                email.Value = objclsCliente.pstrEMail;

                SqlParameter telefono = cmdCommand.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 10);
                telefono.Direction = ParameterDirection.Input;
                telefono.Value = objclsCliente.pstrTelefono;

                objconConexion.Open();
                cmdCommand.ExecuteNonQuery();
                objconConexion.Close();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public SqlDataReader BuscarCliente(clsCliente objclsCliente)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("catClientesBuscar", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;


                SqlParameter nombre = cmdCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = objclsCliente.pstrNombre;

                cmdCommand.CommandType = CommandType.StoredProcedure;
                objconConexion.Open();
                cmdCommand.CommandTimeout = 300;

                return cmdCommand.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public bool eliminar(clsCliente objclsCliente)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("catClientesModificar", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter idCliente = cmdCommand.Parameters.Add("@IDCLIENTE", SqlDbType.Int);
                idCliente.Direction = ParameterDirection.Input;
                idCliente.Value = objclsCliente.intId;

                SqlParameter nombre = cmdCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = objclsCliente.pstrNombre;

                SqlParameter direccion = cmdCommand.Parameters.Add("@DIRECCION", SqlDbType.VarChar, 80);
                direccion.Direction = ParameterDirection.Input;
                direccion.Value = objclsCliente.pstrDireccion;

                SqlParameter email = cmdCommand.Parameters.Add("@EMAIL", SqlDbType.VarChar, 80);
                email.Direction = ParameterDirection.Input;
                email.Value = objclsCliente.pstrEMail;

                SqlParameter telefono = cmdCommand.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 10);
                telefono.Direction = ParameterDirection.Input;
                telefono.Value = objclsCliente.pstrTelefono;

                objconConexion.Open();
                cmdCommand.ExecuteNonQuery();
                objconConexion.Close();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }

        }


        public SqlDataReader CargarDatos()
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("catClientesMostrar", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;
                objconConexion.Open();
                cmdCommand.CommandTimeout = 300;

                return cmdCommand.ExecuteReader(CommandBehavior.CloseConnection); 

            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}