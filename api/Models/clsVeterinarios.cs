using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class clsVeterinario
    {
        public int intId { get; set; }
        public string strNombre { get; set; }
        public string straPaterno { get; set; }
        public string straMaterno { get; set; }
        public string strCedula { get; set; }
        public DateTime datefechaNac { get; set; }
        public string strCalle { get; set; }
        public string strColonia { get; set; }
        public string strCodigoPostal { get; set; }
        public string strTelefono { get; set; }

        private string strconConnectionString { get; set; }
        private object objIdSqlDbType { get; set; }

        public clsVeterinario()
        {
            this.intId = 0;
            this.strNombre = "";
            this.straPaterno = "";
            this.straMaterno = "";
            this.strCedula = "";
            this.datefechaNac = DateTime.Now;
            this.strCalle = "";
            this.strColonia = "";
            this.strCodigoPostal = "";
            this.strTelefono= "";

            this.strconConnectionString = ConfigurationManager.ConnectionStrings["BDPrueba"].ConnectionString;
        }

        public clsVeterinario(int pintId, string pstrNombre, string pstraPaterno, string pstraMaterno, string pstrCedula, DateTime pdateFechaNac, string pstrCalle, string pstrColonia, string pstrCodigoPostal, string pstrTelefono)
        {
            this.intId = pintId;
            this.strNombre = pstrNombre;
            this.straPaterno = pstraPaterno;
            this.straMaterno = pstraMaterno;
            this.strCedula = pstrCedula;
            this.datefechaNac = pdateFechaNac;
            this.strCalle = pstrCalle;
            this.strColonia = pstrColonia;
            this.strCodigoPostal = pstrCodigoPostal;
            this.strTelefono = pstrTelefono;
        }

        public bool Agregar(clsVeterinario pobjVeterinario)
        {

            try
            {
                SqlConnection objconConnection = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("catVeterinarioAgregar", objconConnection); // Nombre del storeProcedure
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter nombre = cmdComando.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = pobjVeterinario.strNombre;

                SqlParameter aPaterno = cmdComando.Parameters.Add("@APATERNO", SqlDbType.VarChar, 80);
                aPaterno.Direction = ParameterDirection.Input;
                aPaterno.Value = pobjVeterinario.straPaterno;

                SqlParameter aMaterno = cmdComando.Parameters.Add("@AMATERNO", SqlDbType.VarChar, 80);
                aMaterno.Direction = ParameterDirection.Input;
                aMaterno.Value = pobjVeterinario.straMaterno;

                SqlParameter cedula = cmdComando.Parameters.Add("@CEDULA", SqlDbType.VarChar, 80);
                cedula.Direction = ParameterDirection.Input;
                cedula.Value = pobjVeterinario.strCedula;

                SqlParameter fechaNac = cmdComando.Parameters.Add("@FECHANAC", SqlDbType.DateTime);
                fechaNac.Direction = ParameterDirection.Input;
                fechaNac.Value = pobjVeterinario.datefechaNac;

                SqlParameter calle = cmdComando.Parameters.Add("@CALLE", SqlDbType.VarChar, 80);
                calle.Direction = ParameterDirection.Input;
                calle.Value = pobjVeterinario.strCalle;

                SqlParameter colonia = cmdComando.Parameters.Add("@COLONIA", SqlDbType.VarChar, 80);
                colonia.Direction = ParameterDirection.Input;
                colonia.Value = pobjVeterinario.strColonia;

                SqlParameter cp = cmdComando.Parameters.Add("@CODIGOPOSTAL", SqlDbType.VarChar, 80);
                cp.Direction = ParameterDirection.Input;
                cp.Value = pobjVeterinario.strCodigoPostal;

                SqlParameter telefono = cmdComando.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 10);
                telefono.Direction = ParameterDirection.Input;
                telefono.Value = pobjVeterinario.strTelefono;

                objconConnection.Open();
                cmdComando.ExecuteNonQuery();
                objconConnection.Close();

                return true;
            }catch (Exception ex)
            {
                return false;
            }
        }

        public bool Modificar(clsVeterinario pobjVeterinario)
        {

            try
            {
                SqlConnection objconConnection = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("catVeterinarioModificar", objconConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter idVeterinario = cmdComando.Parameters.Add("@IDUSER", SqlDbType.Int);
                idVeterinario.Direction = ParameterDirection.Input;
                idVeterinario.Value = pobjVeterinario.intId;

                SqlParameter nombre = cmdComando.Parameters.Add("@NOMBRE", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = pobjVeterinario.strNombre;

                SqlParameter aPaterno = cmdComando.Parameters.Add("@APATERNO", SqlDbType.VarChar, 80);
                aPaterno.Direction = ParameterDirection.Input;
                aPaterno.Value = pobjVeterinario.straPaterno;

                SqlParameter aMaterno = cmdComando.Parameters.Add("@AMATERNO", SqlDbType.VarChar, 80);
                aMaterno.Direction = ParameterDirection.Input;
                aMaterno.Value = pobjVeterinario.straMaterno;

                SqlParameter cedula = cmdComando.Parameters.Add("@CEDULA", SqlDbType.VarChar, 80);
                cedula.Direction = ParameterDirection.Input;
                cedula.Value = pobjVeterinario.strCedula;

                SqlParameter fechaNac = cmdComando.Parameters.Add("@FECHANAC", SqlDbType.DateTime);
                fechaNac.Direction = ParameterDirection.Input;
                fechaNac.Value = pobjVeterinario.datefechaNac;

                SqlParameter calle = cmdComando.Parameters.Add("@CALLE", SqlDbType.VarChar, 80);
                calle.Direction = ParameterDirection.Input;
                calle.Value = pobjVeterinario.strCalle;

                SqlParameter colonia = cmdComando.Parameters.Add("@COLONIA", SqlDbType.VarChar, 80);
                colonia.Direction = ParameterDirection.Input;
                colonia.Value = pobjVeterinario.strColonia;

                SqlParameter cp = cmdComando.Parameters.Add("@CODIGOPOSTAL", SqlDbType.VarChar, 80);
                cp.Direction = ParameterDirection.Input;
                cp.Value = pobjVeterinario.strCodigoPostal;

                SqlParameter telefono = cmdComando.Parameters.Add("@TELEFONO", SqlDbType.VarChar, 10);
                telefono.Direction = ParameterDirection.Input;
                telefono.Value = pobjVeterinario.strTelefono;

                objconConnection.Open();
                cmdComando.ExecuteNonQuery();
                objconConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public SqlDataReader BuscarVeterinario(clsVeterinario pobjVeterinario)
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdCommand = new SqlCommand("catVeterinarioBuscar", objconConexion);
                cmdCommand.CommandType = CommandType.StoredProcedure;


                SqlParameter nombre = cmdCommand.Parameters.Add("@nombre", SqlDbType.VarChar, 80);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = pobjVeterinario.strNombre;

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

        public SqlDataReader CargarDatos()
        {
            try
            {
                SqlConnection objconConexion = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdCommand = new SqlCommand("catVeterinarioMostrar", objconConexion);
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

        public bool Eliminar(clsVeterinario pobjVeterinario)
        {

            try
            {
                SqlConnection objconConnection = new SqlConnection(this.strconConnectionString);
                SqlCommand cmdComando = new SqlCommand("catVeterinarioEliminar", objconConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter idVeterinario = cmdComando.Parameters.Add("@IDUSER", SqlDbType.Int);
                idVeterinario.Direction = ParameterDirection.Input;
                idVeterinario.Value = pobjVeterinario.intId;

                objconConnection.Open();
                cmdComando.ExecuteNonQuery();
                objconConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}