using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace api.Models
{
    public class clsMascota 
    {

        public int id_mascota { get; set; } 

        public string nombre { get; set; }

        public int edad { get; set; }

        public string especie { get; set; }

        public string raza { get; set; }

        public string caracteristicas { get; set; }

        public int id_cliente { get; set; }

        public int estatus { get; set; }

        private string strConConnectionString { get; set; }
        private object objSqlDBType { get; set; }



        public clsMascota()
        {
            this.id_mascota = 0;
            this.nombre = "";
            this.edad = 0;
            this.especie = "";
            this.raza = "";
            this.caracteristicas = "";
            this.id_cliente = 0;
            this.estatus = 0;
            
            this.strConConnectionString = ConfigurationManager.ConnectionStrings["BDPrueba"].ConnectionString;
        }

        public clsMascota(int id_mascota, string nombre, int edad, string especie, string raza, string caracteristicas, int id_cliente, int estatus)
        {
            this.id_mascota = id_mascota;
            this.nombre = nombre;
            this.edad = edad;
            this.especie = especie;
            this.raza = raza;
            this.caracteristicas = caracteristicas;
            this.id_cliente = 0;
            this.estatus = 0;
        }
       
        public string Agregar(clsMascota objMascota)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("mascotaAgregar", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter nombre = cmdCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = objMascota.nombre;

                SqlParameter edad = cmdCommand.Parameters.Add("@EDAD", SqlDbType.Int, 80);
                edad.Direction = ParameterDirection.Input;
                edad.Value = objMascota.edad;

                SqlParameter especie = cmdCommand.Parameters.Add("@ESPECIE", SqlDbType.VarChar, 80);
                especie.Direction = ParameterDirection.Input;
                especie.Value = objMascota.especie;

                SqlParameter raza = cmdCommand.Parameters.Add("@RAZA", SqlDbType.VarChar, 80);
                raza.Direction = ParameterDirection.Input;
                raza.Value = objMascota.raza;

                SqlParameter caracteristicas = cmdCommand.Parameters.Add("@CARACTERISTICAS", SqlDbType.VarChar, 80);
                caracteristicas.Direction = ParameterDirection.Input;
                caracteristicas.Value = objMascota.caracteristicas;

                SqlParameter id_cliente = cmdCommand.Parameters.Add("@ID_CLIENTE", SqlDbType.Int, 80);
                id_cliente.Direction = ParameterDirection.Input;
                id_cliente.Value = objMascota.id_cliente;

                SqlParameter estatus = cmdCommand.Parameters.Add("@ESTATUS", SqlDbType.Int, 10);
                estatus.Direction = ParameterDirection.Input;
                estatus.Value = objMascota.estatus;

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

        public bool Modificar(clsMascota objMascota)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("mascotaModificar", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_mascota = cmdCommand.Parameters.Add("@ID_MASCOTA", SqlDbType.Int);
                id_mascota.Direction = ParameterDirection.Input;
                id_mascota.Value = objMascota.id_mascota;

                SqlParameter nombre = cmdCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = objMascota.nombre;

                SqlParameter edad = cmdCommand.Parameters.Add("@EDAD", SqlDbType.Int, 80);
                edad.Direction = ParameterDirection.Input;
                edad.Value = objMascota.edad;

                SqlParameter especie = cmdCommand.Parameters.Add("@ESPECIE", SqlDbType.VarChar, 80);
                especie.Direction = ParameterDirection.Input;
                especie.Value = objMascota.especie;

                SqlParameter raza = cmdCommand.Parameters.Add("@RAZA", SqlDbType.VarChar, 80);
                raza.Direction = ParameterDirection.Input;
                raza.Value = objMascota.raza;

                SqlParameter caracteristicas = cmdCommand.Parameters.Add("@CARACTERISTICAS", SqlDbType.VarChar, 100);
                caracteristicas.Direction = ParameterDirection.Input;
                caracteristicas.Value = objMascota.caracteristicas;

                SqlParameter id_cliente = cmdCommand.Parameters.Add("@ID_CLIENTE", SqlDbType.Int, 80);
                id_cliente.Direction = ParameterDirection.Input;
                id_cliente.Value = objMascota.id_cliente;

                SqlParameter estatus = cmdCommand.Parameters.Add("@ESTATUS", SqlDbType.Int, 10);
                estatus.Direction = ParameterDirection.Input;
                estatus.Value = objMascota.estatus;


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

        public SqlDataReader BuscarMascota(clsMascota objMascota)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("mascotaBuscar", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;


                SqlParameter nombre = cmdCommand.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = objMascota.nombre;

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

        public bool eliminar(clsMascota objMascota)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdCommand = new SqlCommand("mascotaEliminar", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;

                SqlParameter id_mascota = cmdCommand.Parameters.Add("@ID_MASCOTA", SqlDbType.Int);
                id_mascota.Direction = ParameterDirection.Input;
                id_mascota.Value = objMascota.id_mascota;

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
                SqlCommand cmdCommand = new SqlCommand("mascotaMostrar", objconConexion);
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