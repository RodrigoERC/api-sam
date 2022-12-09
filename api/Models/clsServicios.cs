using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class clsServicios
    {

        public int intIdServicio { get; set; } 

        public string pstrNombre { get; set; }

        public string pstrDescripcion { get; set; }

        public double pstrCosto { get; set; }

        public string pstrImagen { get; set; }

        private string strConConnectionString { get; set; }


        public clsServicios()
        {
            this.intIdServicio = 0;
            this.pstrNombre = "";
            this.pstrDescripcion = "";
            this.pstrCosto = 0.0;
            this.pstrImagen = "";


            this.strConConnectionString = ConfigurationManager.ConnectionStrings["BDPrueba"].ConnectionString;
        }

        public clsServicios(int intIdServicio, string pstrNombre, string pstrDescripcion, double pstrCosto, string pstrImagen)
        {
            this.intIdServicio = intIdServicio;
            this.pstrNombre = pstrNombre;
            this.pstrDescripcion = pstrDescripcion;
            this.pstrCosto = pstrCosto;
            this.pstrImagen = pstrImagen;
        }
       
        public string Agregar(clsServicios objclsServicios)
        {
            try
            {
                SqlConnection objconConexion = new  SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("catServicioAgregar", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter nombre = cmdCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = objclsServicios.pstrNombre;

                SqlParameter descripcion = cmdCommand.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 80);
                descripcion.Direction = ParameterDirection.Input;
                descripcion.Value = objclsServicios.pstrDescripcion;

                SqlParameter costo = cmdCommand.Parameters.Add("@COSTO", SqlDbType.VarChar, 80);
                costo.Direction = ParameterDirection.Input;
                costo.Value = objclsServicios.pstrCosto;

                SqlParameter imagen = cmdCommand.Parameters.Add("@IMAGEN", SqlDbType.VarChar, 10);
                imagen.Direction = ParameterDirection.Input;
                imagen.Value = objclsServicios.pstrImagen;

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

        public string Modificar(clsServicios objclsServicios)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("catServiciosModificarF", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter idCliente = cmdCommand.Parameters.Add("@IDSERVICIO", SqlDbType.Int);
                idCliente.Direction = ParameterDirection.Input;
                idCliente.Value = objclsServicios.intIdServicio;

                SqlParameter nombre = cmdCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = objclsServicios.pstrNombre;

                SqlParameter descripcion = cmdCommand.Parameters.Add("@DESCRIPCION", SqlDbType.VarChar, 80);
                descripcion.Direction = ParameterDirection.Input;
                descripcion.Value = objclsServicios.pstrDescripcion;

                SqlParameter costo = cmdCommand.Parameters.Add("@COSTO", SqlDbType.VarChar, 80);
                costo.Direction = ParameterDirection.Input;
                costo.Value = objclsServicios.pstrCosto;

                SqlParameter imagen = cmdCommand.Parameters.Add("@IMAGEN", SqlDbType.VarChar, 10);
                imagen.Direction = ParameterDirection.Input;
                imagen.Value = objclsServicios.pstrImagen;

                objconConexion.Open();
                cmdCommand.ExecuteNonQuery();
                objconConexion.Close();

                return "Actualizacion Correcta";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }

        public SqlDataReader BuscarServicio(clsServicios objclsServicios)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("catServicioBuscar", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;


                SqlParameter nombre = cmdCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = objclsServicios.pstrNombre;

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

        public string eliminar(clsServicios objclsServicios)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("catServiciosEliminarF", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter idCliente = cmdCommand.Parameters.Add("@IDSERVICIO", SqlDbType.Int);
                idCliente.Direction = ParameterDirection.Input;
                idCliente.Value = objclsServicios.intIdServicio;

                

                objconConexion.Open();
                cmdCommand.ExecuteNonQuery();
                objconConexion.Close();

                return "";

            }
            catch (Exception ex)
            {
                return ex.ToString();
            }

        }


        public SqlDataReader CargarDatos()
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("catServiciosMostrar", objconConexion);
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