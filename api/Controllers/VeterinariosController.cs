using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Data.SqlClient;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;

namespace API.Controllers
{
    public class VeterinariosController : ApiController
    {

        private clsVeterinario objVeterinario;
        private VeterinariosController()
        {
            objVeterinario = new clsVeterinario();
        }

        [HttpPost]
        public HttpResponseMessage Prueba(string pstrMensaje)
        {
            return Request.CreateErrorResponse(HttpStatusCode.NotFound, pstrMensaje);
        }

        [HttpPost]
        public HttpResponseMessage Agregar(string pstrNombre, string pstraPaterno, string pstraMaterno, string pstrCedula, DateTime pdateFechaNac, string pstrCalle, string pstrColonia, string pstrCodigoPostal, string pstrTelefono)
        {
            bool bolResultado;

            objVeterinario.strNombre = pstrNombre;
            objVeterinario.straPaterno = pstraPaterno;
            objVeterinario.straMaterno = pstraMaterno;
            objVeterinario.strCedula = pstrCedula;
            objVeterinario.datefechaNac = pdateFechaNac;
            objVeterinario.strCalle = pstrCalle;
            objVeterinario.strColonia = pstrColonia;
            objVeterinario.strCodigoPostal = pstrCodigoPostal;
            objVeterinario.strTelefono = pstrTelefono;

            bolResultado = objVeterinario.Agregar(objVeterinario);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, bolResultado ? "OK" : "Algo salio mal");
        }

        [HttpPut]
        public HttpResponseMessage Modificar(int pintId, string pstrNombre, string pstraPaterno, string pstraMaterno, string pstrCedula, DateTime pdateFechaNac, string pstrCalle, string pstrColonia, string pstrCodigoPostal, string pstrTelefono)
        {
            bool bolResultado;

            objVeterinario.intId = pintId;
            objVeterinario.strNombre = pstrNombre;
            objVeterinario.straPaterno = pstraPaterno;
            objVeterinario.straMaterno = pstraMaterno;
            objVeterinario.strCedula = pstrCedula;
            objVeterinario.datefechaNac = pdateFechaNac;
            objVeterinario.strCalle = pstrCalle;
            objVeterinario.strColonia = pstrColonia;
            objVeterinario.strCodigoPostal = pstrCodigoPostal;
            objVeterinario.strTelefono = pstrTelefono;

            bolResultado = objVeterinario.Modificar(objVeterinario);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, bolResultado ? "OK" : "Algo salio mal");
        }

        [HttpPut]
        public HttpResponseMessage Eliminar(int pintId)
        {
            bool bolResultado;

            objVeterinario.intId = pintId;

            bolResultado = objVeterinario.Eliminar(objVeterinario);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, bolResultado ? "OK" : "Algo salio mal");
        }

        [HttpGet]
        public string CargarVeterinarios()
        {
            StringBuilder strDatos = new StringBuilder();
            SqlDataReader drRegistros = objVeterinario.CargarDatos();

            strDatos.Append("{" + '"' + "data" + '"' + ":" + "[");
            while (drRegistros.Read())
                strDatos.Append("{" + '"' + "IdVeterinario" + '"' + ":" + '"' + drRegistros["IdVeterinario"]  + '"' + ", " + '"' + "Nombre" + '"' + ":" + '"' + drRegistros["Nombre"] + '"' + ", " + '"' + "Apellido" + '"' + ":" + '"' + drRegistros["aPaterno"] + " " + drRegistros["aMaterno"] + '"' + "}, ");

            strDatos.Remove(strDatos.Length - 2, 2);
            strDatos.Append("]}");
            drRegistros.Close();
            return strDatos.ToString();
        }

        [HttpPost]
        public string BuscarVeterinario(string pstrNombre)
        {
            objVeterinario.strNombre = pstrNombre;
            StringBuilder strDatos = new StringBuilder();
            SqlDataReader drRegistros = objVeterinario.BuscarVeterinario(objVeterinario);

            strDatos.Append("{" + '"' + "data" + '"' + ":" + "[");
            while (drRegistros.Read())
                strDatos.Append("{" + '"' + "IdVeterinario" + '"' + ":" + '"' + drRegistros["IdVeterinario"] + '"' + ", " + '"' + "Nombre" + '"' + ":" + '"' + drRegistros["Nombre"] + '"' + ", " + '"' + "Apellido" + '"' + ":" + '"' + drRegistros["aPaterno"] + " " + drRegistros["aMaterno"] + '"' + "}, ");

            strDatos.Remove(strDatos.Length - 2, 2);
            strDatos.Append("]}");
            drRegistros.Close();
            return strDatos.ToString();
        }
    }
}