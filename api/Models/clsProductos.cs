using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Text;

namespace SAM.Models
{
    public class clsProductos
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public float precio { get; set; }
        public int stock { get; set; }
        public byte[] imagen { get; set; }
        public int estatus { get; set; }
        public int idProveedor { get; set; }

        private string strConConnectionString { get; set; }


        public clsProductos()
        {
            this.idProducto = 0;
            this.nombre = "";
            this.descripcion = "";
            this.precio = 0;
            this.stock = 0;
            this.imagen = new byte[0];
            this.estatus = 0;
            this.idProveedor = 0;

            this.strConConnectionString = ConfigurationManager.ConnectionStrings["BDPrueba"].ConnectionString;
        }

        public clsProductos(int idProducto, string nombre, string descripcion, float precio, int stock, byte[] imagen, int estatus, int idProveedor)
        {
            this.idProducto = idProducto;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.precio = precio;
            this.stock = stock;
            this.imagen = imagen;
            this.estatus = estatus;
            this.idProveedor = idProveedor;
        }

        public bool Agregar(clsProductos objProductos)
        {
            try
            {
                SqlConnection objConConnection = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdComando = new SqlCommand("tblProductosAgregar", objConConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter nombre = cmdComando.Parameters.Add("@nombre", SqlDbType.VarChar, 250);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = objProductos.nombre;

                SqlParameter descripcion = cmdComando.Parameters.Add("@descripcion", SqlDbType.VarChar, 250);
                descripcion.Direction = ParameterDirection.Input;
                descripcion.Value = objProductos.descripcion;

                SqlParameter precio = cmdComando.Parameters.Add("@precio", SqlDbType.Float);
                precio.Direction = ParameterDirection.Input;
                precio.Value = objProductos.precio;

                SqlParameter stock = cmdComando.Parameters.Add("@stock", SqlDbType.Int);
                stock.Direction = ParameterDirection.Input;
                stock.Value = objProductos.stock;

                SqlParameter estatus = cmdComando.Parameters.Add("@estatus", SqlDbType.Int);
                estatus.Direction = ParameterDirection.Input;
                estatus.Value = objProductos.estatus;

                SqlParameter idProveedor = cmdComando.Parameters.Add("@idProveedor", SqlDbType.Int);
                idProveedor.Direction = ParameterDirection.Input;
                idProveedor.Value = objProductos.idProveedor;

                objConConnection.Open();
                cmdComando.ExecuteNonQuery();
                objConConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Modificar(clsProductos objProductos)
        {
            try
            {
                SqlConnection objConConnection = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdComando = new SqlCommand("tblProductosModificar", objConConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter idProducto = cmdComando.Parameters.Add("@idProducto", SqlDbType.VarChar, 250);
                idProducto.Direction = ParameterDirection.Input;
                idProducto.Value = objProductos.idProducto;

                SqlParameter nombre = cmdComando.Parameters.Add("@nombre", SqlDbType.VarChar, 250);
                nombre.Direction = ParameterDirection.Input;
                nombre.Value = objProductos.nombre;

                SqlParameter descripcion = cmdComando.Parameters.Add("@descripcion", SqlDbType.VarChar, 250);
                descripcion.Direction = ParameterDirection.Input;
                descripcion.Value = objProductos.descripcion;

                SqlParameter precio = cmdComando.Parameters.Add("@precio", SqlDbType.Float);
                precio.Direction = ParameterDirection.Input;
                precio.Value = objProductos.precio;

                SqlParameter stock = cmdComando.Parameters.Add("@stock", SqlDbType.Int);
                stock.Direction = ParameterDirection.Input;
                stock.Value = objProductos.stock;

                SqlParameter estatus = cmdComando.Parameters.Add("@estatus", SqlDbType.Int);
                estatus.Direction = ParameterDirection.Input;
                estatus.Value = objProductos.estatus;

                SqlParameter idProveedor = cmdComando.Parameters.Add("@idProveedor", SqlDbType.Int);
                idProveedor.Direction = ParameterDirection.Input;
                idProveedor.Value = objProductos.idProveedor;

                objConConnection.Open();
                cmdComando.ExecuteNonQuery();
                objConConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Eliminar(clsProductos objProductos)
        {
            try
            {
                SqlConnection objConConnection = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdComando = new SqlCommand("tblProductosEliminar", objConConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                SqlParameter idProducto = cmdComando.Parameters.Add("@idProducto", SqlDbType.Int);
                idProducto.Direction = ParameterDirection.Input;
                idProducto.Value = objProductos.idProducto;

                SqlParameter estatus = cmdComando.Parameters.Add("@estatus", SqlDbType.Int);
                estatus.Direction = ParameterDirection.Input;
                estatus.Value = objProductos.estatus;

                objConConnection.Open();
                cmdComando.ExecuteNonQuery();
                objConConnection.Close();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public String CargarProductos()
        {
            try
            {
                SqlConnection objConConnection = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdComando = new SqlCommand("tblCargarProductos", objConConnection);
                cmdComando.CommandType = CommandType.StoredProcedure;

                objConConnection.Open();
                cmdComando.CommandTimeout = 300;

                StringBuilder strDatos = new StringBuilder();
                SqlDataReader drRegistros = cmdComando.ExecuteReader();

                strDatos.Append("{" + '"' + "data" + '"' + ":" + "[");
                while (drRegistros.Read())
                    strDatos.Append("{" + '"' + "idProducto" + '"' + ":" + '"' + drRegistros["idProducto"] + '"' + ", "
                                        + '"' + "nombre" + '"' + ":" + '"' + drRegistros["nombre"] + '"' + "}, ");

                strDatos.Remove(strDatos.Length - 2, 2);
                strDatos.Append("]}");
                drRegistros.Close();

                return strDatos.ToString();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string Buscar(string b)
        {
            try
            {
                SqlConnection objconConnection = new SqlConnection(this.strConConnectionString);
                SqlCommand cmdComando = new SqlCommand("tblCargarProductos", objconConnection); // Nombre del storeProcedure
                cmdComando.CommandType = CommandType.StoredProcedure;

                objconConnection.Open();
                cmdComando.CommandTimeout = 300;

                StringBuilder Datos = new StringBuilder();

                SqlDataReader Registros = cmdComando.ExecuteReader(CommandBehavior.CloseConnection);

                Datos.Append("[");
                while (Registros.Read())
                {
                    string drNombre = Registros["nombre"].ToString().ToLower();
                    if (drNombre.Contains(b.ToLower()))
                    {
                        Datos.Append("{" + '"' + "idProducto" + '"' + ":" + Registros["idProducto"] + ","
                                        + '"' + "nombre" + '"' + ":" + Registros["nombre"] + "}, ");
                    }
                }

                Datos.Remove(Datos.Length - 2, 2);
                Datos.Append("]");
                Registros.Close();

                return Datos.ToString();


            }
            catch (Exception e)
            {
                return "Error";
            }
        }
    }
}