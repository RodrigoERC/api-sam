using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Web.Http;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using api.Models;
using System.Text;
using System.Data.SqlClient;

namespace api.Controllers
{
    public class ClienteController : ApiController
    {
        private clsCliente objCliente;
        

        public ClienteController()
        {
            objCliente = new clsCliente();
        }
        // GET: Cliente
        [HttpPost]
        public HttpResponseMessage Prueba()
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Correcto");

        }

        [HttpPost]
        public HttpResponseMessage Agregar(string pstrNombre, string pstrDireccion, string pstrMail, string pstrTelefono)
        {
            string resultado;
            objCliente.pstrNombre = pstrNombre;
            objCliente.pstrTelefono = pstrTelefono;
            objCliente.pstrDireccion = pstrDireccion;
            objCliente.pstrEMail = pstrMail;
            resultado = objCliente.Agregar(objCliente);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, resultado.ToString());

        }

        [HttpPut]
        public HttpResponseMessage Modificar(int idCliente,string pstrNombre, string pstrDireccion, string pstrMail, string pstrTelefono)
        {
            bool resultado;
            objCliente.intId = idCliente;
            objCliente.pstrNombre = pstrNombre;
            objCliente.pstrTelefono = pstrTelefono;
            objCliente.pstrDireccion = pstrDireccion;
            objCliente.pstrEMail = pstrMail;
            resultado = objCliente.Modificar(objCliente);
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, resultado.ToString());
            

        }


        

        [HttpDelete]
        public HttpResponseMessage Eliminar(int pintId)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "ok");

        }

        [HttpGet]
        public string  CargarCliente()
        {
            StringBuilder strDatos = new StringBuilder();
            SqlDataReader drRegistros = objCliente.CargarDatos();

            strDatos.Append("[");
            while (drRegistros.Read())
                strDatos.Append("{" + '"' + "IdCliente" + '"' + ":" + drRegistros["IdCliente"] + ", "+ '"' + "Nombre"+ '"' + ":" + drRegistros["Nombre"]+ "}, ");
                
            strDatos.Remove(strDatos.Length - 2, 2);
            strDatos.Append("]");
            drRegistros.Close();
            return strDatos.ToString();
        }
        [HttpPost]
        public string BuscarCliente(string pstrNombre)
        {
            objCliente.pstrNombre = pstrNombre;
            StringBuilder strDatos = new StringBuilder();
            SqlDataReader drRegistros = objCliente.BuscarCliente(objCliente);

            strDatos.Append("[");
            while (drRegistros.Read())
                strDatos.Append("{" + '"' + "IdCliente" + '"' + ":" + drRegistros["IdCliente"] + ", " + '"' + "Nombre" + '"' + ":" + drRegistros["Nombre"] + "}, ");

            strDatos.Remove(strDatos.Length - 2, 2);
            strDatos.Append("]");
            drRegistros.Close();
            return strDatos.ToString();
        }
    }
}